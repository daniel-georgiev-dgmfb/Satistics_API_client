using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Twilight.Kernel.Logging;
using Twilight.Kernel.Spatial;
using Twilight.Kernel.Web;

namespace Satistics_API_client
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpatialController : ControllerBase
    {
        private Twilight.Platform.Web.HttpClient.HttpClient _httpClient;
        private ConfigurationManager _configurationManager;
        private ILocationService _locationService;
        private IEventLogger<SpatialController> _logger;
        public SpatialController(Twilight.Platform.Web.HttpClient.HttpClient httpClient, ILocationService locationService, ConfigurationManager configurationManager, IEventLogger<SpatialController> logger)
        {
            this._httpClient = httpClient;
            this._configurationManager = configurationManager;
            this._locationService = locationService;
            this._logger = logger;
        }

        [HttpPost("euclideandistance")]
        public async Task<double> EuclideanDistance([FromForm] string readingsX, [FromForm] string readingsY)
        {
            try
            {
                var baseUrl = this._configurationManager["statServerBaseUri"];

                var url = String.Format("{0}{1}", baseUrl, "stats/spatial/euclideandistance");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readingsx", readingsX);
                dir.Add("readingsy", readingsY);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new FormUrlEncodedContent(dir)
                };

                //request.Headers.Add("Content-Type", "json/xml");
                var result = await resourceRetriever.SendAsync(request, CancellationToken.None);

                var dataAsString = await result.Content.ReadAsStringAsync();
                var dataAsStream = await result.Content.ReadAsByteArrayAsync();
                var split = dataAsString.Trim('[').TrimEnd(']').Split(',');
                var testResult = double.Parse(dataAsString);
                return testResult;
            }
            //ASSERT
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("distance")]
        public async Task<double> GetDistance([FromForm] float readingsX, [FromForm] float readingsY, [FromForm] float readingsX1, [FromForm] float readingsY1)
        {
            try
            {
                await this._logger.Log(SeverityLevel.Trace, new EventId(0), typeof(SpatialController), String.Format("Call: {0}, {1}, {2}, {3}", readingsX, readingsY, readingsX1, readingsY1));
                var distance = await this._locationService.CalculateDistance(Tuple.Create(readingsX, readingsY), Tuple.Create(readingsX1, readingsY1));
                await this._logger.Log(SeverityLevel.Trace, new EventId(0), typeof(SpatialController), String.Format("Distance: {0}.", distance));
                return distance;
            }
            
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}