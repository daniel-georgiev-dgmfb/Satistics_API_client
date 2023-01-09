using Convesys.Kernel.Web;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Satistics_API_client
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpatialController : ControllerBase
    {
        private Convesys.Platform.Web.HttpClient.HttpClient _httpClient;
        private ConfigurationManager _configurationManager;
        public SpatialController(Convesys.Platform.Web.HttpClient.HttpClient httpClient, ConfigurationManager configurationManager)
        {
            this._httpClient = httpClient;
            this._configurationManager = configurationManager;
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
    }
}
