using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Practices.Unity;
using FactsLibrary.Core;
using System.Web.Mvc;
using System.Web.Http.Controllers;

namespace FactsLibrary.Api.Test
{
    [TestClass]
    public class HttServerTests
    {
        public IUnityContainer UnityContainer { get; set; }
        public UnityControllerFactory ControllerFactory { get; set; }

        [TestInitialize]
        public void IntializeTest()
        {
            this.UnityContainer = new UnityContainer();
            this.UnityContainer.RegisterType<ICountryFactsRepository, MockCountryFactsRepository>();
            this.UnityContainer.RegisterType<IHttpActionInvoker,ApiControllerActionInvoker>();
            this.ControllerFactory = new UnityControllerFactory(this.UnityContainer);
            ControllerBuilder.Current.SetControllerFactory(this.ControllerFactory);
        }

        [TestMethod]
        public void HttpServerSmokeTest()
        {
            // Arrange.
            var config = new HttpConfiguration();
            RouteConfig.RegisterRoutes(config);
            WebApiConfig.Register(config);
            config.DependencyResolver = new UnityResolver(this.UnityContainer);

            //ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(this.UnityContainer));
            //config.DependencyResolver = (System.Web.Http.Dependencies.IDependencyResolver)this.UnityContainer;

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
            {
                using (var client = HttpClientFactory.Create(innerHandler: httpServer))
                {

                    return await client.SendAsync(request);
                }
            }
           
        }
    }
}
