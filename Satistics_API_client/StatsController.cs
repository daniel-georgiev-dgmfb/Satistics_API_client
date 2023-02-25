using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Twilight.Kernel.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Satistics_API_client
{
    [Route("api/stats")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private Twilight.Platform.Web.HttpClient.HttpClient _httpClient;
        private ConfigurationManager _configurationManager;

        public StatsController(Twilight.Platform.Web.HttpClient.HttpClient httpClient, ConfigurationManager configurationManager)
        {
            this._httpClient = httpClient;
            this._configurationManager = configurationManager;
        }
        
        [HttpPost("kstest")]
        public async Task<Tuple<double, double>> KSTestPost([FromForm]string readings)
        {
            try
            {
                
                var context = base.HttpContext;
                readings = context.Request.Form["readings"];
                //var baseUrl = this._configurationManager["statServerBaseUri"];
                var baseUrl = new ConfigurationManager()["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/tests/kstest");
                
#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = false;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", readings);
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
                if (split.Length != 2)
                    throw new FormatException("length");
                var value1 = double.Parse(split[0].Trim());
                var value2 = double.Parse(split[1].Trim());
                var testResult = new Tuple<double, double>(value1, value2);
                return testResult;
            }
            //ASSERT
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("skew")]
        public async Task<double> SkewPost([FromQuery] string data)
        {
            //string data = "1,2,3,4,5,6,7";
            try
            {
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/skew");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("kurtosis")]
        public async Task<double> KurtosisPost([FromQuery] string data)
        {
            try
            {
                //var context = base.HttpContext;
                //data = context.Request.Form["data"];
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/kurtosis");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("median")]
        public async Task<double> MedianPost([FromQuery] string data)
        {
            try
            {
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/median");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("mean")]
        public async Task<double> MeanPost([FromQuery] string data)
        {
            try
            {
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/mean");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("geometricmean")]
        public async Task<double> GeometricMeanPost([FromQuery] string data)
        {
            try
            {
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/geometricmean");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("harmonicmean")]
        public async Task<double> HarmonicMeanPost([FromQuery] string data)
        {
            try
            {
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/harmonicmean");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("variance")]
        public async Task<double> VariancePost([FromQuery] string data)
        {
            try
            {
                var context = base.HttpContext;
                //data = context.Request.Form["data"];
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/variance");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("covariance")]
        public async Task<double> CovariancePost([FromQuery] string data)
        {
            try
            {
                var context = base.HttpContext;
                //data = context.Request.Form["data"];
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/covariance");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("pearsoncoeficient")]
        public async Task<Tuple<double, double>> PearsonCoeficientPost([FromQuery] string readingsx, [FromQuery]string readingsy)
        {
            try
            {
                var context = base.HttpContext;
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/pearsoncoefficient");

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readingsx", readingsx);
                dir.Add("readingsy", readingsy);
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
                var value1 = double.Parse(split[0]);
                var value2 = double.Parse(split[1]);
                //var testResult = double.Parse(dataAsString);
                return Tuple.Create(value1, value2);
            }
            //ASSERT
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("mode")]
        public async Task<Tuple<double,double>> ModePost([FromQuery] string data, [FromQuery] string axis)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(axis))
                    axis = "None";
                var context = base.HttpContext;
                //data = context.Request.Form["data"];
                var baseUrl = this._configurationManager["statServerBaseUri"];
                var url = String.Format("{0}{1}", baseUrl, "stats/funcs/mode");
                
#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
                dir.Add("axis", axis);
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
                var split = dataAsString.Trim('[').TrimEnd(']').Trim('"').Trim('{').Trim('}').Split(':');
                if (split.Length != 2)
                    throw new FormatException("length");
                //var foo1 = split[0].Trim('"');
                //var foo2 = split[1].Replace('"', ' ').Trim();
                var value1 = double.Parse(split[0].Trim('"'));
                var value2 = double.Parse(split[1].Replace('"', ' ').Trim());
                var testResult = new Tuple<double, double>(value1, value2);
                //var testResult = double.Parse(dataAsString);
                return testResult;
            }
            //ASSERT
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("entropy")]
        public async Task<double> EntropyPost([FromQuery] string data)
        {
            try
            {
                var context = base.HttpContext;
                //data = context.Request.Form["data"];
                var url = "http://localhost:4449/stats/funcs/entropy";
                //var url = "https://localhost:44331/api/Stats/kstest";

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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
                //var split = dataAsString.Trim('[').TrimEnd(']').Trim('"').Trim('{').Trim('}').Split(':');
                //var split = dataAsString.Trim('[').TrimEnd(']').Split(',');
                var entropy = double.Parse(dataAsString);
                //if (split.Length != 2)
                //    throw new FormatException("length");
                //var foo1 = split[0].Trim('"');
                //var foo2 = split[1].Replace('"', ' ').Trim();
                //var entropy = double.Parse(split[0].Trim('"'));
                //var value2 = double.Parse(split[1].Replace('"', ' ').Trim());
                //var testResult = new Tuple<double, double>(value1, value2);
                //var testResult = double.Parse(dataAsString);
                return entropy;
            }
            //ASSERT
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("standarddeviation")]
        public async Task<double> StandardDeviantionPost([FromQuery] string data)
        {
            try
            {
                var context = base.HttpContext;
                //data = context.Request.Form["data"];
                var url = "http://localhost:4449/stats/funcs/sdeviation";
                //var url = "https://localhost:44331/api/Stats/kstest";

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("standarderror")]
        public async Task<double> StandardErrorPost([FromQuery] string data)
        {
            try
            {
                //var context = base.HttpContext;
                //data = context.Request.Form["data"];
                var url = "http://localhost:4449/stats/funcs/standarderror";
#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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

        [HttpPost("ttest")]
        public async Task<Tuple<double, double>> TTestPost([FromForm] string data)
        {
            try
            {
                var context = base.HttpContext;
                data = context.Request.Form["data"];
                var url = "http://localhost:4449/stats/tests/ttest";
                //var url = "https://localhost:44331/api/Stats/kstest";

#if DEBUG
                this._httpClient.RequireHttps = false;
#else
                this._httpClient.RequireHttps = true;
#endif
                IResourceRetriever resourceRetriever = this._httpClient;
                var dir = new Dictionary<string, string>();
                dir.Add("readings", data);
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
                var value1 = double.Parse(split[0]);
                var value2 = double.Parse(split[1]);
                return Tuple.Create(value1, value2);
            }
            //ASSERT
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
