using Convesys.Kernel.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Satistics_API_client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ConfigurationManager = Satistics_API_client.ConfigurationManager;

[Route("api/math")]
[ApiController]
public class MathController : ControllerBase
{
    private ConfigurationManager _configurationManager;
    private Convesys.Platform.Web.HttpClient.HttpClient _httpClient;
    public MathController(Convesys.Platform.Web.HttpClient.HttpClient httpClient, ConfigurationManager configurationManager)
    {
        this._httpClient = httpClient;
        this._configurationManager = configurationManager;
    }
    [HttpPost("integrate")]
    public async Task<double> IntegratePost([FromForm] string readingsX, [FromForm] string readingsY, [FromForm] string dx)
    {
        try
        {
            var baseUrl = this._configurationManager["statServerBaseUri"];
            
            var url = String.Format("{0}{1}", baseUrl, "stats/funcs/integrate");

#if DEBUG
            this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
            IResourceRetriever resourceRetriever = this._httpClient;
            var dir = new Dictionary<string, string>();
            dir.Add("readingsx", readingsX);
            dir.Add("readingsy", readingsY);
            dir.Add("dx", dx);
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

    [HttpPost("hash")]
    public async Task<string> HashPost([FromForm] string data, [FromForm] string hashAlg)
    {
        try
        {
            var baseUrl = this._configurationManager["statServerBaseUri"];

            var url = String.Format("{0}{1}", baseUrl, "/cryptography/funcs/hash");

#if DEBUG
            this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
            IResourceRetriever resourceRetriever = this._httpClient;
            var dir = new Dictionary<string, string>();
            dir.Add("data", data);
            dir.Add("hashAlg", hashAlg);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new FormUrlEncodedContent(dir)
            };

            //request.Headers.Add("Content-Type", "json/xml");
            var result = await resourceRetriever.SendAsync(request, CancellationToken.None);

            var dataAsString = await result.Content.ReadAsStringAsync();
            
            return dataAsString;
        }
        //ASSERT
        catch (Exception ex)
        {
            throw;
        }
    }
}