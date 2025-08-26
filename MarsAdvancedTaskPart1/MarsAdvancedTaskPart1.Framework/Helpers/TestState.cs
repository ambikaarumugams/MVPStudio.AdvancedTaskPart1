using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MarsAdvancedTaskPart1.Framework.Helpers
{
    public class TestState
    {
        public IWebDriver Driver { get; set; }
        public WaitHelper Wait { get; set; }
        public AssertHelper Assert { get; set; }
        public ScreenshotHelper Screenshot { get; set; }
        public ExtentTest Test { get; set; }
        public JsonHelper Json { get; set; }
        public Actions Actions { get; set; }
        public Settings Config { get; }
        public SignInComponent SignInComponent { get; private set; }
        public LoginModel LoginData { get; set; }
        public List<string?> LanguagesToCleanUp { get; } = new();
        public List<string?> SkillsToCleanUp { get; } = new();
        public List<string?> EducationToCleanUp { get; } = new();
        public List<string?> CertificationToCleanUp { get; } = new();


        public TestState(IWebDriver driver, ExtentTest test, Settings config)
        {
            Driver = driver;
            Test = test;
            Wait = new WaitHelper(driver);
            Screenshot = new ScreenshotHelper(driver);
            Assert = new AssertHelper(this);
            Json = new JsonHelper();
            Config = config;
            Actions = new Actions(Driver);
            SignInComponent = new SignInComponent(this);
            LoginData = JsonHelper.ReadJson<LoginModel>("TestData/LoginTestData.json");
        }
    }
}
