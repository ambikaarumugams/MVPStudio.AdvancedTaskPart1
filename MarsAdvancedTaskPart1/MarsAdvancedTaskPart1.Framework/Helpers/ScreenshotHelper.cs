using OpenQA.Selenium;
namespace MarsAdvancedTaskPart1.Framework.Helpers
{
    public class ScreenshotHelper
    {
        private readonly IWebDriver _driver;

        public ScreenshotHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        //public string GetLatestScreenShot { get; private set; }

        public string CaptureAsBase64()
        {
            try
            {
                var screenshot = ((ITakesScreenshot) _driver).GetScreenshot();
                //GetLatestScreenShot= screenshot.AsBase64EncodedString;
                return screenshot.AsBase64EncodedString;
            }
            catch
            {
                return null;
            }
        }

        public string CaptureToFile()
        {
            try
            {
                var fileName = $"Screenshot_{DateTime.Now:yyyyMMMMdd_HHmmss}.png";
                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Screenshots");
                Directory.CreateDirectory(folder);
                var fullPath = Path.Combine(folder, fileName);

                var screenshot = ((ITakesScreenshot) _driver).GetScreenshot();
                screenshot.SaveAsFile(fullPath);
                return fullPath;
            }
            catch 
            {
                return null;
            }
        }
    }
}
