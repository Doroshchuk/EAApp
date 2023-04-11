using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Api = ProductAPI;

namespace EAIntegrationTest
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _webApplicationFactory;

        public UnitTest1(WebApplicationFactory<Api.Startup> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
        }

        //[Fact]
        //public void TestWithHttpClient()
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:5000/");

        //    var response = client.Send(new HttpRequestMessage(HttpMethod.Get, "Product/GetProducts"));

        //    //response.Content.ReadAsStringAsync().Result;

        //    response.EnsureSuccessStatusCode();
        //}

        [Fact]
        public async Task TestWithWebAppFactory()
        {
            var webClient = _webApplicationFactory.CreateClient();
            var products = await webClient.GetAsync("Product/GetProducts");
            var result = products.Content.ReadAsStringAsync().Result;
            result.Should().Contain("Keyboard");
        }

        [Fact]
        public async Task TestWithGeneratedCode()
        {
            var webClient = _webApplicationFactory.CreateClient();
            var product = new ProductAPI("http://localhost:44334/", webClient);  
            var results = await product.GetProductsAsync();
            results.Should().HaveCount(4);
        }
    }
}