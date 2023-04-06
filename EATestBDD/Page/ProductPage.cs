namespace EATestBDD.Page
{
    public interface IProductPage
    {
        void FillInProductDetails(Product product);
        void EditProduct(Product product);
        Product GetProductDetails();
    }

    public class ProductPage : IProductPage
    {
        private IWebDriver _driver;

        public ProductPage(IDriverFixture driverFixture)
        {
            _driver = driverFixture.Driver;
        }

        public IWebElement NameTextField => _driver.FindElement(By.Id("Name"));

        public IWebElement DescriptionTextField => _driver.FindElement(By.Id("Description"));

        public IWebElement PriceTextField => _driver.FindElement(By.Id("Price"));

        public IWebElement ProductTypeDropDownList => _driver.FindElement(By.Id("ProductType"));

        public IWebElement CreateButton => _driver.FindElement(By.Id("Create"));

        public IWebElement SaveButton => _driver.FindElement(By.Id("Save"));

        public void FillInProductDetails(Product product)
        {
            NameTextField.SendKeys(product.Name);
            DescriptionTextField.SendKeys(product.Description);
            PriceTextField.SendKeys(product.Price.ToString());
            ProductTypeDropDownList.SelectDropDownByText(product.ProductType.ToString());
            CreateButton.Submit();
        }

        public Product GetProductDetails()
        {
            return new Product()
            {
                Name = NameTextField.Text,
                Description = DescriptionTextField.Text,
                Price = int.Parse(PriceTextField.Text),
                ProductType = (ProductType)Enum.Parse(typeof(ProductType),
                                    ProductTypeDropDownList.GetAttribute("innerText"))
            };
        }

        public void EditProduct(Product product)
        {
            NameTextField.ClearAndEnterText(product.Name);
            DescriptionTextField.ClearAndEnterText(product.Description);
            PriceTextField.ClearAndEnterText(product.Price.ToString());
            SaveButton.Click();
        }
    }
}
