using EATestFramework.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace EATestFramework.Driver
{
    public class DriverFixture : IDriverFixture, IDisposable
    {
        RemoteWebDriver _driver;
        private readonly TestSettings _testSettings;
        private readonly IBrowserDriver _browserDriver;

        public DriverFixture(TestSettings testSettings,
                             IBrowserDriver browserDriver)
        {
            _testSettings = testSettings;
            _browserDriver = browserDriver;
            _driver = new RemoteWebDriver(_testSettings.SeleniumGridUrl, GetBrowserOptions());
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

        private dynamic GetBrowserOptions()
        {
            switch(_testSettings.BrowserType)
            {
                case BrowserType.Firefox:
                    {
                        var fireFoxOptions = new FirefoxOptions();
                        fireFoxOptions.AddAdditionalOption("se:recordVideo", true);
                        return fireFoxOptions;
                    }
                case BrowserType.Edge:
                    return new EdgeOptions();
                case BrowserType.Safari:
                    return new SafariOptions();
                case BrowserType.Chrome:
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddAdditionalOption("se:recordVideo", true);
                        return chromeOptions;
                    }
                default:
                    return new ChromeOptions();
            }
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
