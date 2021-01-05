using System;
using Xunit;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using GymShopAPI.BLL.Controllers;
using GymShopAPI.BLL;
using Newtonsoft.Json;

namespace ProductServiceIntegrationtests
{
    public class IntergrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;


        public IntergrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Test the intergration of the Drink controller to Send a Get request to a specified url
        /// </summary>
        /// <param name="endpoint">The url to call to</param>
        /// <returns></returns>
        [Theory]
        [InlineData("/Categories")]
        [InlineData("/products/1")]
        [InlineData("/categories/main")]
        public async Task CheckHeaderProductDefaultRoutes(string endpoint)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(endpoint);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
