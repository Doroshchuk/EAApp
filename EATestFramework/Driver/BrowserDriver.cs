using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Firefox;

namespace EATestFramework.Driver
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        Safari,
        Edge
    }

    public class BrowserDriver : IBrowserDriver
    {
        public IWebDriver GetChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        public IWebDriver GetFirefoxDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }
    }
}
