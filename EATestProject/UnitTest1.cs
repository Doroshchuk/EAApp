using AutoFixture.Xunit2;
using EATestProject.Model;
using EATestProject.Page;
using FluentAssertions;

namespace EATestProject
{
    public class UnitTest1
    {
        IHomePage _homePage;
        IProductPage _productPage;

        public UnitTest1(IHomePage homePage, IProductPage createProductPage)
        {
            _homePage = homePage;
            _productPage = createProductPage;
        }

        [Theory, AutoData]
        public void Test1(Product product)
        {
            _homePage.CreateProduct();
            _productPage.FillInProductDetails(product);
            _homePage.PerformClickOnSpecialValue(product.Name, "Details");
            var actualProduct = _productPage.GetProductDetails();
            actualProduct.Should()
                            .BeEquivalentTo(product, option => option.Excluding(x => x.Id));
        }
    }
}