using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net;

namespace FactsLibrary.Api.Test
{
    [TestClass]
    public class HttServerTests
    {
        [TestMethod]
        public void HttpServerSmokeTest()
        {
            // Arrange.
            var config = new HttpConfiguration();
            RouteConfig.RegisterRoutes(config);
            WebApiConfig.Register(config);
            
            // Act.
            var message = new HttpRequestMessage();
            message.RequestUri = new Uri("http://localhost/odata/CountryFacts");
            var response = GetResponseAsync(config, message);

            // Assert.
            Assert.AreEqual<HttpStatusCode>(HttpStatusCode.OK, response.Result.StatusCode);
            
        }

        internal static async Task<HttpResponseMessage> GetResponseAsync(
            HttpConfiguration config, HttpRequestMessage request)
        {

            using (var httpServer = new HttpServer(config))
            using (var client = HttpClientFactory.Create(innerHandler: httpServer))
            {

                return await client.SendAsync(request);
            }
        }
    }
}
