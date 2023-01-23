using Convesys.Kernel.Logging;
using Convesys.Kernel.Web;
using Convesys.Platform.Web.HttpClient;
using NUnit.Framework;
using Satistics_API_client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BackchannelCertificateValidator = Convesys.Platform.Web.HttpClient.BackchannelCertificateValidator;

namespace Statistics_API_client_Test_L1
{
    class TestLogger<BackchannelCertificateValidator> : Convesys.Kernel.Logging.IEventLogger<BackchannelCertificateValidator>
    {
        public void Log<TState>(SeverityLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            
        }

        async Task IEventLogger.Log(SeverityLevel level, EventId eventId, Type eventSource, Guid transactionId, string message)
        {
            
        }

        async Task IEventLogger.Log(SeverityLevel level, EventId eventId, Type eventSource, string message)
        {
            
        }

        async Task IEventLogger.Log(SeverityLevel level, EventId eventId, Type eventSource, Guid transactionId, Exception exception)
        {
            
        }

        async Task IEventLogger.Log(SeverityLevel level, EventId eventId, Type eventSource, Exception exception)
        {
            
        }
    }
    public class Tests
    {
        private Convesys.Platform.Web.HttpClient.HttpClient _httpClient;
        
        [SetUp]
        public void Setup()
        {
            var logger = new TestLogger<BackchannelCertificateValidator>();
            var logger1 = new TestLogger<Convesys.Platform.Web.HttpClient.HttpClient>();
            var configProvider = new Convesys.Platform.Web.HttpClient.CertificateValidationConfigurationProvider();
            var varidator = new BackchannelCertificateValidator(configProvider, logger);
            this._httpClient = new Convesys.Platform.Web.HttpClient.HttpClient(varidator, logger1);
        }

        [Test]
        public async Task Test1()
        {
            try
            {
                var configurationManager = new ConfigurationManager();
                var controller = new StatsController(this._httpClient, configurationManager);
                //var context = base.HttpContext;
                var data = "10,20,30,40,60,70,80,99,100,101,112";//context.Request.Form["data"];
                var url = "http://localhost:21533/stats/funcs/skew";
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
                //controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext(new  Microsoft.AspNetCore.Mvc.ActionContext(new Microsoft.AspNetCore.Mvc.ActionContext() { ActionDescriptor = new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor(), HttpContext = new ContextCallback()}));
                //var r = await controller.KSTestPost(data);
                //request.Headers.Add("Content-Type", "json/xml");
                var result = await resourceRetriever.SendAsync(request, CancellationToken.None);

                var dataAsString = await result.Content.ReadAsStringAsync();
                var dataAsStream = await result.Content.ReadAsByteArrayAsync();
                var split = dataAsString.Trim('[').TrimEnd(']').Split(',');
                var testResult = double.Parse(dataAsString);
                
            }
            //ASSERT
            catch (Exception ex)
            {
                throw;
            }
            Assert.Pass();
        }
    }
}