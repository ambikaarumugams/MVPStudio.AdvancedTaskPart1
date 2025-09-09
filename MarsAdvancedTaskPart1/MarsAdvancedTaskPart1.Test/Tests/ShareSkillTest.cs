using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent.ProfileComponent.ProfileMenuTabComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    public class ShareSkillTest : TestBase.TestBase
    {
        private ShareSkillComponent? _shareSkillComponent;

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_UsingSkillExchangeValidInput))]
        public void ShareSkills_UsingSkillExchangeValidInput(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills using skill exchange...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details...");

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
                    string fullPath = Path.GetFullPath(workSample);
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
                Console.WriteLine($"Error message for worksamples:{errorMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.ExpectedToastMessage);
                Thread.Sleep(6000);
                State.ShareSkillCleanUp.Add(skill.Title);
                _shareSkillComponent.ClickCancel();  //Click the cancel button to delete from manage listings
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_UsingCreditValidInput))]  //Failed not able to select the credit radio button
        public void ShareSkills_UsingCreditValidInput(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();
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
                //_shareSkillComponent.ChooseCredit(skill.SkillTradeType);
                _shareSkillComponent.SetCreditAmount(skill.Credit);
                foreach (var workSample in skill.WorkSamples)
                {
                    string fullPath = Path.GetFullPath(workSample);
                    if (!File.Exists(fullPath))
                    {
                        throw new FileNotFoundException("File not found:" + fullPath);
                    }
                    _shareSkillComponent.UploadWorkSample(fullPath);
                }
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage();
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.ExpectedToastMessage);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidTitleSpecialCharacters))]
        public void ShareSkills_InvalidTitleSpecialCharacters(ShareSkillModel shareSkillModel)
        {
            List<string?> actualMessages = new();
            List<string?> expectedMessages = new();
            List<string?> actualFieldMessages = new();
            List<string?> expectedFieldMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid title - SpecialCharacters...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();
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
                    string fullPath = Path.GetFullPath(workSample);
                    if (!File.Exists(fullPath))
                    {
                        throw new FileNotFoundException("File not found:" + fullPath);
                    }
                    _shareSkillComponent.UploadWorkSample(fullPath);
                }
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var errorMessage = _shareSkillComponent.GetErrorMessage();
                Console.WriteLine($"Pop up Message:{errorMessage}");
                Thread.Sleep(5000);
                actualMessages.Add(errorMessage);

                var fieldErrorText = _shareSkillComponent.GetTextOfTitleFieldErrorMessage();
                Console.Write($"Field error message:{fieldErrorText}");
                actualFieldMessages.Add(fieldErrorText);

                expectedMessages.Add(skill.ExpectedToastMessage);
                expectedFieldMessages.Add(skill.ExpectedFieldErrorMessage);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
            State.Assert.AssertListContainsAll(actualFieldMessages, expectedFieldMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidTitleStartsWithNumbers))] //Starts with numbers and random strings
        public void ShareSkills_InvalidTitleStartsWithNumbers(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid Title starts with numbers...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();
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
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage();  //Not able to capture the success message, it goes to the manage listings page immediately
                Console.WriteLine($"Message:{successMessage}");
                actualMessages.Add(successMessage);
                var addedSkillFromManageListings= _shareSkillComponent.GetRecentlyAddedSkillTitleFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                expectedMessages.Add(skill.ExpectedToastMessage);
                actualMessages.Add(addedSkillFromManageListings);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidTitleRandomStrings))]
        public void ShareSkills_InvalidTitleRandomStrings(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid Title - RandomStrings...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
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

                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.ExpectedToastMessage);
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillTitleFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                actualMessages.Add(addedSkillFromManageListings);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidTitleFirstCharacterWhiteSpace))]
        public void ShareSkills_InvalidTitleFirstCharacterWhiteSpace(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            List<string?> actualFieldMessages = new();
            List<string?> expectedFieldMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid Title first character as a whitespace...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ClickShareSkill();
                if(skill.Title.Equals("<space>"))
                {
                    skill.Title = "  ";
                }
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

                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var errorMessage = _shareSkillComponent.GetErrorMessage();
                Console.WriteLine($"Message:{errorMessage}");
                actualMessages.Add(errorMessage);
                expectedMessages.Add(skill.ExpectedToastMessage);
                var fieldErrorText = _shareSkillComponent.GetTextOfTitleFieldErrorMessage();
                Console.Write($"Field error message:{fieldErrorText}");
                actualFieldMessages.Add(fieldErrorText);
                expectedFieldMessages.Add(skill.ExpectedFieldErrorMessage);
            }
            State.Assert.ListsMatch(actualMessages, expectedMessages);
            State.Assert.AssertListContainsAll(actualFieldMessages, expectedFieldMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_BoundaryTestingForTitleMoreThan100Characters))]
        public void ShareSkills_BoundaryTestingForTitleMoreThan100Characters(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills - Title has more than 100 characters...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");

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
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                //var successMessage = _shareSkillComponent.GetSuccessMessage(); //Not able to capture the success message
                //Console.WriteLine($"Message:{successMessage}");
                //actualMessages.Add(successMessage);
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillTitleFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                Console.WriteLine("The Title field limit <=100 characters including space.");
                actualMessages.Add(addedSkillFromManageListings);
                expectedMessages.Add(skill.Title);
                State.ShareSkillCleanUp.Add(addedSkillFromManageListings);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_BoundaryTestingForTitleLessThan100Characters))]
        public void ShareSkills_BoundaryTestingForTitleLessThan100Characters(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills - Title has less than 100 characters......");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");

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
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                //var successMessage = _shareSkillComponent.GetSuccessMessage(); //Not able to capture the success message
                //Console.WriteLine($"Message:{successMessage}");
                //actualMessages.Add(successMessage);
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillTitleFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                Console.WriteLine("The Title field limit <=100 characters including space.");
                actualMessages.Add(addedSkillFromManageListings);
                expectedMessages.Add(skill.Title);
                State.ShareSkillCleanUp.Add(addedSkillFromManageListings);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_BoundaryTestingForTitle100Characters))]
        public void ShareSkills_BoundaryTestingForTitle100Characters(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills - Title has 100 characters...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");

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
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                //var successMessage = _shareSkillComponent.GetSuccessMessage(); //Not able to capture the success message
                //Console.WriteLine($"Message:{successMessage}");
                //actualMessages.Add(successMessage);
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillTitleFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                Console.WriteLine("The Title field limit <=100 characters including space.");
                actualMessages.Add(addedSkillFromManageListings);
                expectedMessages.Add(skill.Title);
                State.ShareSkillCleanUp.Add(addedSkillFromManageListings);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidDescriptionWithSpecialCharacters))]
        public void ShareSkills_InvalidDescriptionWithSpecialCharacters(ShareSkillModel shareSkillModel)
        {
            List<string?> actualMessages = new();
            List<string?> expectedMessages = new();
            List<string?> actualFieldMessages = new();
            List<string?> expectedFieldMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid description that has special characters...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details...");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();
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
                    string fullPath = Path.GetFullPath(workSample);
                    if (!File.Exists(fullPath))
                    {
                        throw new FileNotFoundException("File not found:" + fullPath);
                    }
                    _shareSkillComponent.UploadWorkSample(fullPath);
                }
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var errorMessage = _shareSkillComponent.GetErrorMessage();
                Console.WriteLine($"Pop up Message:{errorMessage}");
                Thread.Sleep(5000);
                actualMessages.Add(errorMessage);

                var fieldErrorText = _shareSkillComponent.GetTextOfDescriptionFieldError();
                Console.Write($"Field error message:{fieldErrorText}");
                actualFieldMessages.Add(fieldErrorText);

                expectedMessages.Add(skill.ExpectedToastMessage);
                expectedFieldMessages.Add(skill.ExpectedFieldErrorMessage);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
            State.Assert.AssertListContainsAll(actualFieldMessages, expectedFieldMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidDescriptionWithNumbers))] //Starts with numbers and random strings
        public void ShareSkills_InvalidDescriptionWithNumbers(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid description that includes numbers...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details...");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();
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
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage();  //Not able to capture the success message, it goes to the manage listings page immediately
                Console.WriteLine($"Message:{successMessage}");
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillDescriptionFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                actualMessages.Add(addedSkillFromManageListings);
                expectedMessages.Add(skill.Title);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidDescriptionWithRandomStrings))]
        public void ShareSkills_InvalidDescriptionWithRandomStrings(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid description includes random string...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
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

                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.ExpectedToastMessage);
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillDescriptionFromManageListings();
                    Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                actualMessages.Add(addedSkillFromManageListings);
                expectedMessages.Add(skill.Description);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidDescriptionStartsWithNumbers))]
        public void ShareSkills_InvalidDescriptionStartsWithNumbers(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid description that starts with numbers...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
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

                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.ExpectedToastMessage);
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillDescriptionFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                actualMessages.Add(addedSkillFromManageListings);
                expectedMessages.Add(skill.Description);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidDescriptionFirstCharacterWhiteSpace))]
        public void ShareSkills_InvalidDescriptionWithFirstCharacterWhiteSpace(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            List<string?> actualFieldMessages = new();
            List<string?> expectedFieldMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid description starts first character as a white space...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ClickShareSkill();
                _shareSkillComponent.EnterTitle(skill.Title);

                if (skill.Description.Equals("<space>"))
                {
                    skill.Description = "  ";
                }
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

                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var errorMessage = _shareSkillComponent.GetErrorMessage();
                Console.WriteLine($"Message:{errorMessage}");
                actualMessages.Add(errorMessage);
                expectedMessages.Add(skill.ExpectedToastMessage);
                var fieldErrorText = _shareSkillComponent.GetTextOfTitleFieldErrorMessage();
                Console.Write($"Field error message:{fieldErrorText}");
                actualFieldMessages.Add(fieldErrorText);
                expectedFieldMessages.Add(skill.ExpectedFieldErrorMessage);
            }
            State.Assert.ListsMatch(actualMessages, expectedMessages);
            State.Assert.AssertListContainsAll(actualFieldMessages, expectedFieldMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_BoundaryTestingForDescriptionMoreThan600Characters))]  //I believe the description field accepts more than 600 characters
        public void ShareSkills_BoundaryTestingForDescriptionMoreThan600Characters(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with description has more than 600 characters...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details...");

            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();  //Scroll the page to the center to make share skill visible
                _shareSkillComponent.ClickShareSkill();
                _shareSkillComponent.EnterTitle(skill.Title);
                _shareSkillComponent.EnterDescription(skill.Description);
                var length = (skill.Description).Length;
                Console.WriteLine($"Length of the Description:{length}");
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
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                //var successMessage = _shareSkillComponent.GetSuccessMessage(); //Not able to capture the success message
                //Console.WriteLine($"Message:{successMessage}");
                //actualMessages.Add(successMessage);
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillDescriptionFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                Console.WriteLine("The Description field limit <=600 including space.");
                actualMessages.Add(addedSkillFromManageListings);
                expectedMessages.Add(skill.Description);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_BoundaryTestingForDescriptionLessThan600Characters))]
        public void ShareSkills_BoundaryTestingForDescriptionLessThan600Characters(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with description has less than 600 characters...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");

            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();  //Scroll the page to the center to make share skill visible
                _shareSkillComponent.ClickShareSkill();
                _shareSkillComponent.EnterTitle(skill.Title);
                _shareSkillComponent.EnterDescription(skill.Description);
                var length = (skill.Description).Length;
                Console.WriteLine($"Length of the Description:{length}");
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
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                //var successMessage = _shareSkillComponent.GetSuccessMessage(); //Not able to capture the success message
                //Console.WriteLine($"Message:{successMessage}");
                //actualMessages.Add(successMessage);
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillDescriptionFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                Console.WriteLine("The Description field limit <=600 including space.");
                actualMessages.Add(addedSkillFromManageListings);
                expectedMessages.Add(skill.Description);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_BoundaryTestingForDescription600Characters))]
        public void ShareSkills_BoundaryTestingForDescription600Characters(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with with description has 600 characters...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");

            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();  //Scroll the page to the center to make share skill visible
                _shareSkillComponent.ClickShareSkill();
                _shareSkillComponent.EnterTitle(skill.Title);
                _shareSkillComponent.EnterDescription(skill.Description);
                var length = (skill.Description).Length;
                Console.WriteLine($"Length of the Description:{length}");  
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
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                //var successMessage = _shareSkillComponent.GetSuccessMessage(); //Not able to capture the success message
                //Console.WriteLine($"Message:{successMessage}");
                //actualMessages.Add(successMessage);
                var addedSkillFromManageListings = _shareSkillComponent.GetRecentlyAddedSkillDescriptionFromManageListings();
                Console.WriteLine($"Added skill from manage listings:{addedSkillFromManageListings}");
                Console.WriteLine("The Description field limit <=600 characters including space.");
                actualMessages.Add(addedSkillFromManageListings);
                expectedMessages.Add(skill.Description);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidTags))]
        public void ShareSkills_InvalidTags(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid tags...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");

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
                    actualMessages.Add(tag.ToString());
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
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage(); //Not able to capture the success message
                Console.WriteLine($"Message:{successMessage}");
                var actual=_shareSkillComponent.GetRecentlyAddedSkillTitleFromManageListings();
                actualMessages.Add($"Title:{actual}");
                expectedMessages.Add(skill.ExpectedToastMessage);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }


        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_ServiceLocationType))]
        public void ShareSkills_ServiceLocationType(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with combinations of service and location type...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details...");

            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();  //Scroll the page to the center to make share skill visible otherwise it clicks the my account menu tab
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
                expectedMessages.Add($"SeriveType: {skill.ServiceType}");
                _shareSkillComponent.SelectLocationType(skill.LocationType);
                expectedMessages.Add($"LocationType: {skill.LocationType}");

                _shareSkillComponent.ClickCalendarAndSelectCurrentDate();
                _shareSkillComponent.ClickWeekLink();
                _shareSkillComponent.SelectSkillTradeType(skill.SkillTradeType);

                foreach (var skillTag in skill.SkillExchangeTags)
                {
                    _shareSkillComponent.AddSkillExchangeTag(skillTag);
                }
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                //var successMessage = _shareSkillComponent.GetSuccessMessage(); //Not able to capture the success message
                //Console.WriteLine($"Message:{successMessage}");
                //var actual = _shareSkillComponent.GetRecentlyAddedSkillTitleFromManageListings();
                //actualMessages.Add($"Title:{actual}");
                _shareSkillComponent.ClickViewButton();
                var serviceType =_shareSkillComponent.GetServiceTypeText();
                actualMessages.Add($"0-Hourly,1-One-off: {serviceType}");
                var locationType=_shareSkillComponent.GetLocationTypeText();
                actualMessages.Add($"0-On-site,1-Online: {locationType}");
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.ListsMatch(actualMessages, expectedMessages);
            Console.WriteLine("Always select service type as Hourly and location type as Online. Radio button don't select the other options One-off, On-site");
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_AddEvents))]
        public void ShareSkills_AddEvents(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            List<string?> shareSkillCleanUp = new();

            State.Test.Log(Status.Info, "Starting add skills with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");

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
                _shareSkillComponent.ClickWorkWeekLink();
                _shareSkillComponent.OpenEventSlot(3,2);
                foreach (var calendarEvent in skill.Events)
                {
                    _shareSkillComponent.SaveEventDetails(calendarEvent.Title, calendarEvent.StartDateTime, calendarEvent.EndDateTime,calendarEvent.Repeat, calendarEvent.Description, calendarEvent.Owner);

                }
                _shareSkillComponent.SelectSkillTradeType(skill.SkillTradeType);

                foreach (var skillTag in skill.SkillExchangeTags)
                {
                    _shareSkillComponent.AddSkillExchangeTag(skillTag);
                }
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                var errorMessage = _shareSkillComponent.GetWorkSamplesErrorText();
                Console.WriteLine($"Error message for worksamples:{errorMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.ExpectedToastMessage);
                Thread.Sleep(6000);
                shareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }


        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_LeaveEitherOneOrAllTheRequiredFieldsAreEmpty))]
        public void ShareSkills_LeaveEitherOneOrAllTheRequiredFieldsAreEmpty(ShareSkillModel shareSkillModel)
        {
            List<string?> actualMessages = new();
            List<string?> expectedMessages = new();
            List<string?> actualFieldMessages = new();
            List<string?> expectedFieldMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with leave either one or all the required fields are empty...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();
            State.Test.Log(Status.Info, "Enter the skill details...");

            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ScrollToCenterOfThePage();
                _shareSkillComponent.ClickShareSkill();

                // Pass values with named arguments; pass active: null to skip setting it
                _shareSkillComponent.LeaveEitherOneOrAllRequiredFieldsEmpty(
                    title: skill.Title,
            description: skill.Description,
            category: skill.Category,
            subCategory: skill.SubCategory,
            tags: skill.Tags,
            serviceType: skill.ServiceType,
            locationType: skill.LocationType,
            skillTradeType: skill.SkillTradeType,
            skillExchangeTags: skill.SkillExchangeTags,
            credit: skill.Credit,
            active: skill.Active
                );

                _shareSkillComponent.ClickSave();

                var errorMessage = _shareSkillComponent.GetErrorMessage();
                Console.WriteLine($"Pop up Message: {errorMessage}");
                Thread.Sleep(5000); // consider replacing with an explicit wait
                actualMessages.Add(errorMessage);

                if (string.IsNullOrWhiteSpace(skill.Title))
                {
                    var titleError = _shareSkillComponent.GetTextOfTitleFieldErrorMessage();
                    Console.WriteLine($"Title field error:{titleError}");
                    actualFieldMessages.Add(titleError);
                }

                if (string.IsNullOrWhiteSpace(skill.Description))
                {
                    var descriptionError = _shareSkillComponent.GetTextOfDescriptionFieldError();
                    Console.Write($"Description field error: {descriptionError}");
                    actualFieldMessages.Add(descriptionError);
                }

                if (string.IsNullOrWhiteSpace(skill.Category))
                {
                    var categoryError = _shareSkillComponent.GetTextOfFieldErrorMessageForCategory();
                    Console.WriteLine($"Category field error:{categoryError}");
                    actualFieldMessages.Add(categoryError);
                }

                // check list is null/empty or contains only blanks
                var hasAnyNonEmptyTag = skill.Tags != null && skill.Tags.Any(t => !string.IsNullOrWhiteSpace(t));
                if (!hasAnyNonEmptyTag)
                {
                    var tagsError = _shareSkillComponent.GetTextOfFieldErrorMessageForTags();
                    Console.WriteLine($"Tags field error:{tagsError}");
                    actualFieldMessages.Add(tagsError);
                }

                var hasAnyNonEmptySkillTag = skill.SkillExchangeTags != null && skill.SkillExchangeTags.Any(t => !string.IsNullOrWhiteSpace(t));
                if (!hasAnyNonEmptySkillTag)
                {
                    var skillExchangeTagsError = _shareSkillComponent.GetTextOfFieldErrorMessageForSkillTags();    
                    Console.WriteLine($"Skilltags field error:{skillExchangeTagsError}");
                    actualFieldMessages.Add(skillExchangeTagsError);
                }
                expectedMessages.Add(skill.ExpectedToastMessage);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_InvalidSkillExchangeTags))]
        public void ShareSkills_InvalidSkillExchangeTags(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid skill exchange tags...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details....");

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
                    actualMessages.Add(skillTag.ToString());
                }
                _shareSkillComponent.SetActiveStatus(skill.Active);
                _shareSkillComponent.ClickSave();
                var successMessage = _shareSkillComponent.GetSuccessMessage(); //Not able to capture the success message
                Console.WriteLine($"Message:{successMessage}");
                var actual = _shareSkillComponent.GetRecentlyAddedSkillTitleFromManageListings();
                Console.WriteLine($"Manage Listings:{actual}");
                expectedMessages.Add(skill.ExpectedToastMessage);
                State.ShareSkillCleanUp.Add(skill.Title);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_WorkSamples))]
        public void ShareSkill_WorkSamples(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills using skill exchange...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill details...");

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
                    string fullPath = Path.GetFullPath(workSample);
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
                var errorMessage = _shareSkillComponent.GetWorkSamplesErrorText();
                Console.WriteLine($"Error message for worksamples:{errorMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.ExpectedToastMessage);
                Thread.Sleep(6000);
                State.ShareSkillCleanUp.Add(skill.Title);
                _shareSkillComponent.ClickCancel();  //Click the cancel button to delete from manage listings
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_EventDetailsDaily))]
        public void ShareSkill_EventDetailsDaily(EventModel eventDetails)
        {
            State.Test.Log(Status.Info, "Starting add events in skill share...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the event details...");
            State.Test.Log(Status.Info, $"Creating event: {eventDetails.EventTitle}");


            _shareSkillComponent.ClickShareSkill();
            _shareSkillComponent.ClickCalendarAndSelectCurrentDate();

            _shareSkillComponent.OpenEventSlot(3, 4);

            _shareSkillComponent.SaveEvent(eventDetails);

            Console.WriteLine($"ExpectedMessage:{eventDetails.ExpectedMessageForEvent}, but event hasn't saved. ");
        }




































    }
}
