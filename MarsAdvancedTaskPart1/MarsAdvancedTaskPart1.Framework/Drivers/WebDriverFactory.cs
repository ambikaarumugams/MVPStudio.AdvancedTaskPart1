using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Drivers
{
    using MarsAdvancedTaskPart1.Framework.Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;

    public class WebDriverFactory
    {
        public static IWebDriver CreateDriver(BrowserSettings browser)
        {
            IWebDriver driver;

            switch (browser.Type.ToLowerInvariant())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (browser.Headless)
                        chromeOptions.AddArgument("--headless=new"); 
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (browser.Headless)
                        firefoxOptions.AddArgument("--headless");      
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    if (browser.Headless)
                        edgeOptions.AddArgument("--headless=new");   
                    driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser.Type}");
            }
            return driver;
        }
    }
}