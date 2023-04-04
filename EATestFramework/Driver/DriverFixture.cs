using EATestFramework.Settings;
using OpenQA.Selenium;

namespace EATestFramework.Driver
{
    public class DriverFixture : IDriverFixture, IDisposable
    {
        IWebDriver _driver;
        private readonly TestSettings _testSettings;
        private readonly IBrowserDriver _browserDriver;

        public DriverFixture(TestSettings testSettings,
                             IBrowserDriver browserDriver)
        {
            _testSettings = testSettings;
            _browserDriver = browserDriver;
            _driver = GetWebDriver();
            _driver.Navigate().GoToUrl(testSettings.ApplicationUrl);
        }

        public IWebDriver Driver => _driver;

        public IWebDriver GetWebDriver()
        {
            return _testSettings.BrowserType switch
            {
                BrowserType.Chrome => _browserDriver.GetChromeDriver(),
                BrowserType.Firefox => _browserDriver.GetFirefoxDriver(),
                _ => _browserDriver.GetChromeDriver()
            };
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
