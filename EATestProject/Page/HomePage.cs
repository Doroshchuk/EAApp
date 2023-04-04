using EATestFramework.Driver;
using EATestFramework.Extensions;
using OpenQA.Selenium;

namespace EATestProject.Page
{
    public interface IHomePage
    {
        void CreateProduct();
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

        public void CreateProduct()
        {
            ProductLink.Click();
            CreateLink.Click();
        }

        public void PerformClickOnSpecialValue(string name, string operation)
        {
            TableList.PerformActionOnCell("5", "Name", name, operation);
        }
    }
}
