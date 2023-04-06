using ProductAPI.Repository;

namespace EATestBDD.StepDefinitions
{
    [Binding]
    public sealed class ProductSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IHomePage _homePage;
        private readonly IProductPage _productPage;
        private readonly IProductRepository _productRepository;

        public ProductSteps(ScenarioContext scenarioContext, IHomePage homePage, IProductPage productPage, IProductRepository productRepository)
        {
            _scenarioContext = scenarioContext;
            _homePage = homePage;
            _productPage = productPage;
            _productRepository = productRepository;
        }

        [Given(@"I click the Product menu")]
        public void GivenIClickTheProductMenu()
        {
            _homePage.ClickProduct();
        }

        [Given(@"I click the ""([^""]*)"" link")]
        public void GivenIClickTheLink(string create)
        {
            _homePage.ClickCreate();
        }

        [Given(@"I create product with following details")]
        public void GivenICreateProductWithFollowingDetails(Table table)
        {
            var product = table.CreateInstance<Product>();
            _productPage.FillInProductDetails(product);
            _scenarioContext.Set<Product>(product);
        }

        [When(@"I click the (.*) link of the newly created product")]
        public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct(string operation)
        {
            var product = _scenarioContext.Get<Product>();
            _homePage.PerformClickOnSpecialValue(product.Name, operation);
        }

        [Then(@"I see all the product details are created as expected")]
        public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
        {
            var product = _scenarioContext.Get<Product>();
            var actualProduct = _productPage.GetProductDetails();
            actualProduct.Should()
                            .BeEquivalentTo(product, option => option.Excluding(x => x.Id));
        }

    }
}
