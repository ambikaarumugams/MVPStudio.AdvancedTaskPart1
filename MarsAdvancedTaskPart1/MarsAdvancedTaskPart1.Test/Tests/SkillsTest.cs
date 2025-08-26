using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent.ProfileComponent.ProfileMenuTabComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class SkillsTest : TestBase.TestBase
    {
        private SkillsComponent? _skillsComponent;

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddSkillsValidData))]
        public void AddSkills_ValidInput(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"SuccessMessage:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.Skill);
                State.SkillsToCleanUp.Add(skill.Skill); //Add skills to clean up
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertAllMessagesContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateSkillsValidData))]
        public void UpdateSkills_ValidInput(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            State.Test.Log(Status.Info, "Starting update skills with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"SuccessMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the skill and level for update using existing skill");
            foreach (var skill in skillsModel.UpdateSkill)
            {
                _skillsComponent.UpdateSkillsAndLevel(skill.ExistingSkill, skill.SkillToUpdate,
                    skill.SkillLevelToUpdate);
                var successMessage = _skillsComponent.GetSuccessMessageForUpdateSkill(skill.SkillToUpdate);
                Console.WriteLine($"SuccessMessage:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.SkillToUpdate);
                State.SkillsToCleanUp.Add(skill.SkillToUpdate);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertAllMessagesContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.DeleteSkillsValidData))]
        public void DeleteSkills_ValidInput(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            State.Test.Log(Status.Info, "Starting delete skills with valid input... ");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"Success Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the skill and level for delete using existing skill");
            foreach (var skillToDelete in skillsModel.DeleteSkill)
            {
                expectedMessages.Add(skillToDelete.SkillToBeDeleted);
                _skillsComponent.DeleteSpecificSkill(skillToDelete.SkillToBeDeleted);
                var deleteSuccessMessage = _skillsComponent.GetSuccessMessageForDeleteSkill(skillToDelete.SkillToBeDeleted);
                Console.WriteLine($"Success Message:{deleteSuccessMessage}");
                actualMessages.Add(deleteSuccessMessage);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertAllMessagesContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateSkillsWithExistingSkillDifferentLevelData))]
        public void UpdateSkillWithExistingInput_ValidNegativeTest(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update skill with existing data....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var addSuccessMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"Success Message:{addSuccessMessage}");
            }

            State.Test.Log(Status.Info, "Enter the skill and level for update using existing skill");
            var existing = skillsModel.UpdateSkill[0].ExistingSkill;
            var update = skillsModel.UpdateSkill[0].SkillToUpdate;
            var level = skillsModel.UpdateSkill[0].SkillLevelToUpdate;

            _skillsComponent.UpdateSkillsAndLevel(existing, update, level);
            var updateSuccessMessage = _skillsComponent.GetSuccessMessageForUpdateSkill(update);
            Console.WriteLine($"Success Message:{updateSuccessMessage}");
            actualMessages.Add(updateSuccessMessage);
            expectedMessages.Add(update);
            State.SkillsToCleanUp.Add(update);

            var actualMessage = actualMessages.FirstOrDefault();
            var expectedMessage = expectedMessages.FirstOrDefault();

            if (actualMessage != null && expectedMessage != null)
            {
                State.Assert.Contains(actualMessage, expectedMessage, $"Actual message contains expected");
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddSkillsWhenSessionExpired))]
        public void AddSkills_SessionExpired(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills when session expired...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.ExpireSession();
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var errorMessage = _skillsComponent.GetErrorMessage();
                Console.WriteLine($"Error Message:{errorMessage}");
                actualMessages.Add(errorMessage);
                expectedMessages.Add(skill.SkillValidation.SkillExpectedMessage);
            }

            foreach (string? expected in expectedMessages)
            {
                State.Assert.ListContainsString(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateSkillsWhenSessionExpired))]
        public void UpdateSkill_SessionExpired(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            State.Test.Log(Status.Info, "Starting update skill when session expired....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"Success Message:{successMessage}");
                State.SkillsToCleanUp.Add(skill.Skill);
            }

            State.Test.Log(Status.Info, "Enter the skill and level for update when session expired");
            foreach (var skill in skillsModel.UpdateSkill)
            {
                _skillsComponent.ExpireSession();
                _skillsComponent.UpdateSkillsAndLevel(skill.ExistingSkill, skill.SkillToUpdate, skill.SkillLevelToUpdate);
                var errorMessage = _skillsComponent.GetErrorMessage();
                Console.WriteLine($"Error Message:{errorMessage}");
                actualMessages.Add(errorMessage);
                _skillsComponent.ClickCancelUpdate();
                expectedMessages.Add(skill.SkillValidation.SkillExpectedMessage);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.ListContainsString(actualMessages, expected);
            }
            _skillsComponent.ClickSignOutButton();
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent.NavigateToTheProfilePage();
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.DeleteSkillsWhenSessionExpired))]
        public void DeleteSkills_SessionExpired(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting delete skill when session expired....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"Success Message:{successMessage}");
                State.SkillsToCleanUp.Add(skill.Skill);
            }

            State.Test.Log(Status.Info, "Enter the skill and level for delete using existing skill");
            foreach (var skill in skillsModel.DeleteSkill)
            {
                _skillsComponent.ExpireSession();
                _skillsComponent.DeleteSpecificSkill(skill.SkillToBeDeleted);
                var deleteErrorMessage = _skillsComponent.GetErrorMessage();
                actualMessages.Add(deleteErrorMessage);
                expectedMessages.Add(skill.SkillValidation.SkillExpectedMessage);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.ListContainsString(actualMessages, expected);
            }

            _skillsComponent.ClickSignOutButton();
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent.NavigateToTheProfilePage();
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.CancelAddSkills))]
        public void CancelAddSkills(SkillsModel skillsModel)
        {
            List<bool> actualMessage = new();
            State.Test.Log(Status.Info, "Starting cancel add skill ......");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.EnterSkillAndLevelToCancelAdd(skill.Skill, skill.SkillLevel);
                Console.WriteLine("Add skill process has cancelled");
                var actual = _skillsComponent.IsSkillNotAdded(skill.Skill);
                actualMessage.Add(actual);
            }

            State.Assert.IsTrue(actualMessage);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.CancelUpdateSkills))]
        public void CancelUpdateSkill(SkillsModel skillsModel)
        {
            List<bool> actualMessage = new();

            State.Test.Log(Status.Info, "Starting cancel update skill....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"Success Message:{successMessage}");
                State.SkillsToCleanUp.Add(skill.Skill);
            }

            State.Test.Log(Status.Info, "Enter the skill and level for update using existing skill");
            foreach (var skill in skillsModel.UpdateSkill)
            {
                _skillsComponent.EnterSkillAndLevelToCancelUpdate(skill.ExistingSkill, skill.SkillToUpdate,
                    skill.SkillLevelToUpdate);
                Console.WriteLine("Update skill process has cancelled");
                var actual = _skillsComponent.IsSkillNotUpdated(skill.SkillToUpdate);
                actualMessage.Add(actual);
            }

            State.Assert.IsTrue(actualMessage);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.LeaveEitherOneOrAllTheFieldsEmptyToAddSkills))]
        public void AddSkills_LeaveEitherOneFieldOrAllTheFieldsAreEmpty(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting leave either one or all the fields empty while adding the skill...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.LeaveTheSkillAndLevelEmptyWithCombinationsForAdd(skill.Skill,
                    skill.SkillLevel);
                var message = _skillsComponent.GetErrorMessage();
                Console.WriteLine($"Message:{message}");
                actualMessages.Add(message);
                _skillsComponent.ClickCancelButton();
                expectedMessages.Add(skill.SkillValidation.SkillExpectedMessage);
                //State.skillsToCleanUp.Add(lang.skill); //Add skills to clean up
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.LeaveEitherOneOrAllTheFieldsAreEmptyToUpdateSkills))]
        public void UpdateSkills_LeaveEitherOneFieldOrAllTheFieldsAreEmpty(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting leave either one or all the fields are empty while updating the skill....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"Message:{successMessage}");
                State.SkillsToCleanUp.Add(skill.Skill); //Add skills to clean up
            }

            State.Test.Log(Status.Info, "Enter the skill and level for update using existing skill");
            foreach (var skill in skillsModel.UpdateSkill)
            {
                _skillsComponent.LeaveTheSkillAndLevelEmptyWithCombinationsForUpdate(skill.ExistingSkill, skill.SkillToUpdate, skill.SkillLevelToUpdate);
                var errorMessage = _skillsComponent.GetErrorMessage();
                actualMessages.Add(errorMessage);
                Console.WriteLine($"Error Message:{errorMessage}");
                _skillsComponent.ClickCancelUpdate();
                expectedMessages.Add(skill.SkillValidation.SkillExpectedMessage);
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddSkillsInvalidData))]
        public void AddSkills_InvalidInput(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with invalid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"Message:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.SkillValidation.SkillExpectedMessage);
                State.SkillsToCleanUp.Add(skill.Skill); //Add skills to clean up
            }

            foreach (string? expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateSkillsInvalidData))]
        public void UpdateSkills_InvalidInput(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update skills with invalid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"Success Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the skill and level for update using existing skill");
            foreach (var skill in skillsModel.UpdateSkill)
            {
                _skillsComponent.UpdateSkillsAndLevel(skill.ExistingSkill, skill.SkillToUpdate,
                    skill.SkillLevelToUpdate);
                var message = _skillsComponent.GetSuccessMessageForUpdateSkill(skill.SkillToUpdate);
                Console.WriteLine($"Message:{message}");
                actualMessages.Add(message);
                expectedMessages.Add(skill.SkillToUpdate);
                State.SkillsToCleanUp.Add(skill.SkillToUpdate);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddSkillLengthyStringTestData))]
        public void AddSkill_LengthyStringTest(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skill name length 1000...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                if (skill.Skill.Equals("{LONG_1000}"))
                {
                    skill.Skill = new string('a', 1000);
                }

                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"SuccessMessage:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.SkillValidation.SkillExpectedMessage);
                State.SkillsToCleanUp.Add(skill.Skill); //Add skills to clean up
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddHugeSkillDestructiveTestData))]
        public void AddHugeSkill_DestructiveTTest(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skill huge name for destructive testing...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                if (skill.Skill.Equals("{LONG_5000}"))
                {
                    skill.Skill = new string('a', 5000);
                }

                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"SuccessMessage:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(skill.SkillValidation.SkillExpectedMessage);
                State.SkillsToCleanUp.Add(skill.Skill); //Add skills to clean up
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateHugeSkillDestructiveTestData))]
        public void UpdateHugeSkill_DestructiveTest(SkillsModel skillsModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update huge skill as a input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);
                var successMessage = _skillsComponent.GetSuccessMessageForAddSkill(skill.Skill);
                Console.WriteLine($"SuccessMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the skill and level for update using existing skill");
            foreach (var skill in skillsModel.UpdateSkill)
            {
                if (skill.SkillToUpdate.Equals("{LONG_5000}"))
                {
                    skill.SkillToUpdate = new string('a', 1000);
                }

                _skillsComponent.UpdateSkillsAndLevel(skill.ExistingSkill, skill.SkillToUpdate, skill.SkillLevelToUpdate);
                var message = _skillsComponent.GetSuccessMessageForUpdateSkill(skill.SkillToUpdate);
                actualMessages.Add(message);
                Console.WriteLine($"Error Message:{message}");
                expectedMessages.Add(skill.SkillValidation.SkillExpectedMessage);
                State.SkillsToCleanUp.Add(skill.SkillToUpdate); //Add skills to clean up
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddSkillsWithExistingSkillAndLevel))]
        public void AddSkill_ExistingSkillAndLevelTest(SkillsModel skillsModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var validationMessage = new List<string>();
            var expectedMessages = new List<string?>();
            State.Test.Log(Status.Info, "Starting add skill with existing skill and level...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);

                // Returns a tuple: (text, type)
                var (messageText, messageType) = _skillsComponent.GetToastMessage();

                actualMessages.Add((messageText, messageType));
                if (string.Equals(messageType, "SUCCESS", StringComparison.OrdinalIgnoreCase))
                {
                    State.SkillsToCleanUp.Add(skill.Skill);
                }
                else if (string.Equals(messageType, "ERROR", StringComparison.OrdinalIgnoreCase) &&
                         !string.IsNullOrWhiteSpace(messageText))
                {
                    validationMessage.Add(messageText);
                    var expected = skill.SkillValidation?.SkillExpectedMessage ?? string.Empty;
                    expectedMessages.Add(expected);
                }
                if (expectedMessages.Count > 0)
                {
                    State.Assert.AssertListContainsAll(validationMessage, expectedMessages);
                }
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddSkillWithExistingSkillAndDifferentLevel))]
        public void AddSkill_ExistingSkillDifferentLevelTest(SkillsModel skillsModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var validationMessage = new List<string>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting add existing skill with different level....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _skillsComponent = new SkillsComponent(State);
            _skillsComponent.NavigateToTheProfilePage();
            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in skillsModel.AddSkill)
            {
                _skillsComponent.AddSkillAndLevel(skill.Skill, skill.SkillLevel);

                // Returns a tuple: (text, type)
                var (messageText, messageType) = _skillsComponent.GetToastMessage();

                actualMessages.Add((messageText, messageType));
                if (string.Equals(messageType, "SUCCESS", StringComparison.OrdinalIgnoreCase))
                {
                    State.SkillsToCleanUp.Add(skill.Skill);
                }
                else if (string.Equals(messageType, "ERROR", StringComparison.OrdinalIgnoreCase) &&
                         !string.IsNullOrWhiteSpace(messageText))
                {
                    validationMessage.Add(messageText);
                    var expected = skill.SkillValidation?.SkillExpectedMessage ?? string.Empty;
                    expectedMessages.Add(expected);
                }
            }

            if (expectedMessages.Count > 0)
            {
                State.Assert.AssertListContainsAll(validationMessage, expectedMessages);
            }
        }
    }
}

