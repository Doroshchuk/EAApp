using ProductAPI.Repository;

namespace EATestBDD.StepDefinitions
{
    [Binding]
    public class ReusableSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IProductRepository _productRepository;

        public ReusableSteps(ScenarioContext scenarioContext, IProductRepository productRepository)
        {
            _scenarioContext = scenarioContext;
            _productRepository = productRepository;
        }

        [Then(@"I delete the product (.*) for cleanup")]
        public void ThenIDeleteTheProductHeadphonesForCleanup(string productName)
        {
            _productRepository.DeleteProduct(productName);
        }

        [Given(@"I ensure the following product is created")]
        public void GivenIEnsureTheFollowingProductIsCreated(Table table)
        {
            var product = table.CreateInstance<Product>();
            _productRepository.AddProduct(product);
        }

    }
}
