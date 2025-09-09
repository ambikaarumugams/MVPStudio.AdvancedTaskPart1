using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Drivers;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent.ProfileComponent.ProfileMenuTabComponent;
using NUnit.Framework.Interfaces;
using MyExtent = AventStack.ExtentReports.ExtentReports;

namespace MarsAdvancedTaskPart1.Test.TestBase
{
    public class TestBase
    {
        protected TestState State;
        protected MyExtent Extent;
        protected ExtentTest Test;
        protected Settings Config;  //Initialized in the test state

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Config = JsonHelper.ReadJson<Settings>("settings.json");  //Load json data from settings.json
            Extent = ExtentManager.GetExtent(Config);
            Console.WriteLine($"Report: {ExtentManager.ReportPath}");
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine($"Starting test run at {DateTime.Now}");
            var driver = WebDriverFactory.CreateDriver(Config.Browser); //Start browser
            Extent = ExtentManager.GetExtent(Config);//Extent report configured and attached
            Test = Extent.CreateTest(TestContext.CurrentContext.Test.Name); // now test is ready
            State = new TestState(driver, Test, Config);

            State.Driver.Navigate().GoToUrl(Config.Environment.BaseUrl);
            State.Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMsg = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    string screenshotBase64 = State.Screenshot.CaptureAsBase64();
                    Test.Fail("Test Failed:" + errorMsg)
                        .AddScreenCaptureFromBase64String(screenshotBase64, "Failure Screenshot");
                    break;
                case TestStatus.Passed:
                    Test.Pass("Test passed");
                    break;
                default:
                    Test.Warning("Test ended with unexpected state");
                    break;
            }

            var categories = TestContext.CurrentContext.Test.Properties["Category"];

            if (categories.Contains("language"))
            {
                var languagesComponent = new LanguagesComponent(State);
                foreach (var language in State.LanguagesCleanUp)
                {
                    try
                    {
                        languagesComponent.DeleteSpecificLanguage(language);
                        Console.WriteLine($"[CleanUp] Deleted language:{language}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[CLEANUP FAILED] Language: {language} — {ex.Message}");
                    }
                }

                Test.Log(Status.Info, $"CleanUp Completed");
                //State.LanguagesCleanUp.Clear(); // Reset for next test
            }
            else if (categories.Contains("skills"))
            {
                var skillsComponent = new SkillsComponent(State);
                foreach (var skill in State.SkillsCleanUp)
                {
                    try
                    {
                        skillsComponent.DeleteSpecificSkill(skill);
                        Console.WriteLine($"[CleanUp] Deleted Skills:{skill}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[CLEANUP FAILED] Skills: {skill} — {ex.Message}");
                    }
                }
                Test.Log(Status.Info, $"CleanUp Completed");
            }
            else if (categories.Contains("education"))
            {
                var educationComponent = new EducationComponent(State);
                foreach (var education in State.EducationCleanUp)
                {
                    try
                    {
                        educationComponent.DeleteSpecificEducation(education);
                        Console.WriteLine($"[CleanUp] Deleted Education:{education}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[CLEANUP FAILED] Education: {education} — {ex.Message}");
                    }
                }
                Test.Log(Status.Info, $"CleanUp Completed");
            }
            else if (categories.Contains("certification"))
            {
                var certificationComponent = new CertificationComponent(State);
                foreach (var certification in State.CertificationCleanUp)
                {
                    try
                    {
                        if (certification != null) certificationComponent.DeleteSpecificCertification(certification);
                        Console.WriteLine($"[CleanUp] Deleted Certification:{certification}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[CLEANUP FAILED] Certification: {certification} — {ex.Message}");
                    }
                }
                Test.Log(Status.Info, $"CleanUp Completed");
            }
            else if (categories.Contains("shareSkill"))
            {
                var shareSkillComponent = new ShareSkillComponent(State);
                foreach (var shareSkillTitle in State.ShareSkillCleanUp)
                {
                    try
                    {
                        if (shareSkillTitle != null) shareSkillComponent.DeleteSpecificSharedSkill(shareSkillTitle);
                        Console.WriteLine($"[CleanUp] Deleted Share skill:{shareSkillTitle}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[CLEANUP FAILED] Share Skill: {shareSkillTitle} — {ex.Message}");
                    }
                }
                Test.Log(Status.Info, $"CleanUp Completed");
            }
            State?.Driver?.Quit(); //Closes browser completely
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentManager.Flush();
            Console.WriteLine($"Report generated at: {ExtentManager.ReportPath}");
        }
    }
}
