namespace EATestBDD.Page
{
    public interface IHomePage
    {
        void ClickProduct();
        void ClickCreate();
        void PerformClickOnSpecialValue(string name, string operation);
    }

    public class HomePage : IHomePage
    {
        private IWebDriver _driver;

        public HomePage(IDriverFixture driverFixture)
        {
            _driver = driverFixture.Driver;
        }

        public IWebElement TableList => _driver.FindElement(By.CssSelector(".table"));

        public IWebElement ProductLink => _driver.FindElement(By.LinkText("Product"));

        public IWebElement CreateLink => _driver.FindElement(By.LinkText("Create"));

        public void ClickProduct() => ProductLink.Click();

        public void ClickCreate() => CreateLink.Click();

        public void PerformClickOnSpecialValue(string name, string operation)
        {
            TableList.PerformActionOnCell("5", "Name", name, operation);
        }
    }
}
