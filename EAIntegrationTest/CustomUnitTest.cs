using EAIntegrationTest.Library;
using FluentAssertions;
using ProductAPI;

namespace EAIntegrationTest
{
    public class CustomUnitTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _customWebApplicationFactory;

        public CustomUnitTest(CustomWebApplicationFactory<Startup> customWebApplicationFactory)
        {
            _customWebApplicationFactory = customWebApplicationFactory;
        }

        [Fact]
        public async Task TestWithCustomWebAppFactory()
        {
            var webClient = _customWebApplicationFactory.CreateDefaultClient();
            var product = new ProductAPI("http://localhost:44334/", webClient);
            var results = await product.GetProductsAsync();
            results.Should().HaveCount(4);
        } 
    }
}
