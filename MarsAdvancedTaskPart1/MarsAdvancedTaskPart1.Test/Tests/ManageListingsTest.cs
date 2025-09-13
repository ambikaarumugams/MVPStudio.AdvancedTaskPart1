using System.Diagnostics.CodeAnalysis;
using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    public class ManageListingsTest : TestBase.TestBase
    {
        private ManageListingsComponent _manageListingsComponent;
        private ShareSkillComponent _shareSkillComponent;

        [Test]
        public void SelectManageListings()
        {
            State.Test.Log(Status.Info, "Starting Manage Listings test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _manageListingsComponent = new ManageListingsComponent(State);

            _manageListingsComponent.ClickManageListingsTab();
            var currentUrl = State.Driver.Url;
            var expected = _manageListingsComponent.GetAttributeOfManageListings();
            State.Assert.IsEqualTo(currentUrl, expected, $"Actual{currentUrl} and {expected} aren't equal");
            Console.WriteLine($"{currentUrl}, {expected}");
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ManageListings_ViewAddShareSkillDetails))]
        public void ManageListings_ViewAddShareSkillDetails(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            State.Test.Log(Status.Info, "Starting Manage Listings test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _manageListingsComponent = new ManageListingsComponent(State);
            _shareSkillComponent = new ShareSkillComponent(State);

            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();  //Scroll the page to the center to make share skill visible
                _shareSkillComponent.ClickShareSkill();
                _shareSkillComponent.EnterTitle(skill.Title);
                _shareSkillComponent.EnterDescription(skill.Description);
                _shareSkillComponent.SelectCategory(skill.Category);
                _shareSkillComponent.SelectSubCategory(skill.SubCategory);

                foreach (var tag in skill.Tags)
                {
                    _shareSkillComponent.AddTag(tag);
                }
                _shareSkillComponent.SelectServiceType(skill.ServiceType);
                _shareSkillComponent.SelectLocationType(skill.LocationType);

                _shareSkillComponent.ClickCalendarAndSelectCurrentDate();
                _shareSkillComponent.ClickWeekLink();
                _shareSkillComponent.SelectSkillTradeType(skill.SkillTradeType);

                foreach (var skillTag in skill.SkillExchangeTags)
                {
                    _shareSkillComponent.AddSkillExchangeTag(skillTag);
                }

                foreach (var workSample in skill.WorkSamples)
                {
                    var fullPath = Path.GetFullPath(workSample);
                    if (!File.Exists(fullPath))
                    {
                        throw new FileNotFoundException("File not found:" + fullPath);
                    }
                    _shareSkillComponent.UploadWorkSample(fullPath);
                }
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                Thread.Sleep(6000);
                var errorMessage = _shareSkillComponent.GetWorkSamplesErrorText();
                Console.WriteLine($"Error message for work samples:{errorMessage}");
                Thread.Sleep(6000);
                State.ShareSkillCleanUp.Add(skill.Title);
                _shareSkillComponent.ClickCancel();  //Click the cancel button to delete from manage listings
            }
            _manageListingsComponent.ClickManageListingsTab();
            var table = _manageListingsComponent.GetManageListingsTable();
            foreach (var row in table)
            {
                Console.WriteLine(string.Join("|", row));
                expectedMessages.Add(string.Join("|", row));
            }
            _shareSkillComponent.ClickViewButton();
            var actual = _manageListingsComponent.GetTextFromViewManageListings();
            Console.WriteLine($"Actual message from view skill:{actual}");
            var actualTitle=_manageListingsComponent.GetTitle();
            actualMessages.Add(actualTitle);

            foreach (var expected in expectedMessages)
            {
                Assert.That(expectedMessages, Does.Contain(expected));
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ManageListings_EditShareSkill))]
        public void ManageListings_EditShareSkill(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            State.Test.Log(Status.Info, "Starting Manage Listings test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _manageListingsComponent = new ManageListingsComponent(State);
            _shareSkillComponent = new ShareSkillComponent(State);

            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();  //Scroll the page to the center to make share skill visible
                _shareSkillComponent.ClickShareSkill();
                _shareSkillComponent.EnterTitle(skill.Title);
                _shareSkillComponent.EnterDescription(skill.Description);
                _shareSkillComponent.SelectCategory(skill.Category);
                _shareSkillComponent.SelectSubCategory(skill.SubCategory);

                foreach (var tag in skill.Tags)
                {
                    _shareSkillComponent.AddTag(tag);
                }
                _shareSkillComponent.SelectServiceType(skill.ServiceType);
                _shareSkillComponent.SelectLocationType(skill.LocationType);

                _shareSkillComponent.ClickCalendarAndSelectCurrentDate();
                _shareSkillComponent.ClickWeekLink();
                _shareSkillComponent.SelectSkillTradeType(skill.SkillTradeType);

                foreach (var skillTag in skill.SkillExchangeTags)
                {
                    _shareSkillComponent.AddSkillExchangeTag(skillTag);
                }

                foreach (var workSample in skill.WorkSamples)
                {
                    var fullPath = Path.GetFullPath(workSample);
                    if (!File.Exists(fullPath))
                    {
                        throw new FileNotFoundException("File not found:" + fullPath);
                    }
                    _shareSkillComponent.UploadWorkSample(fullPath);
                }
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                Thread.Sleep(6000);
                var errorMessage = _shareSkillComponent.GetWorkSamplesErrorText();
                Console.WriteLine($"Error message for work samples:{errorMessage}");
                Thread.Sleep(6000);
                _shareSkillComponent.ClickCancel();  //Click the cancel button to delete from manage listings
            }
            
            _manageListingsComponent.ClickManageListingsTab();
           _manageListingsComponent.ClickEditIcon(); 

            // Take first edit skill from JSON
            var editSkill = shareSkillModel.EditSkills[0];
            _shareSkillComponent.EditShareSkill(editSkill.Title, editSkill.Description,editSkill.Category,editSkill.SubCategory);
            _shareSkillComponent.ClickSave();
            var success = _shareSkillComponent.GetSuccessMessage();
            actualMessages.Add(success);
            expectedMessages.Add(editSkill.ExpectedToastMessage);
            State.ShareSkillCleanUp.Add(editSkill.Title);
            foreach (var expected in expectedMessages)
            {
                Assert.That(expectedMessages, Does.Contain(expected));
            }
        }
    }
}

