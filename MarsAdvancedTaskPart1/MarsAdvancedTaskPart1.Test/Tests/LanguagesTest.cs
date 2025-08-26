using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent.ProfileComponent.ProfileMenuTabComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class LanguagesTest : TestBase.TestBase
    {
        private LanguagesComponent? _languagesComponent;

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddLanguagesValidData))]
        public void AddLanguages_ValidInput(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting Add Languages with valid input Test...");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"SuccessMessage:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(lang.Language);
                State.LanguagesToCleanUp.Add(lang.Language); //Add languages to clean up
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertAllMessagesContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateLanguageValidData))]
        public void UpdateLanguages_ValidInput(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update languages with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"SuccessMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the language and level for update using existing language");
            foreach (var lang in languagesModel.UpdateLanguage)
            {
                _languagesComponent.UpdateLanguageAndLevel(lang.ExistingLanguage, lang.LanguageToUpdate,
                    lang.LanguageLevelToUpdate);
                var successMessage = _languagesComponent.GetSuccessMessageForUpdate(lang.LanguageToUpdate);
                Console.WriteLine($"SuccessMessage:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(lang.LanguageToUpdate);
                State.LanguagesToCleanUp.Add(lang.LanguageToUpdate);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertAllMessagesContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.DeleteLanguageValidData))]
        public void DeleteLanguages_ValidInput(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            State.Test.Log(Status.Info, "Starting delete languages with valid input.....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"Success Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the language and level for delete using existing language");
            foreach (var languageToDelete in languagesModel.DeleteLanguage)
            {
                expectedMessages.Add(languageToDelete.LanguageToBeDeleted);
                _languagesComponent.DeleteSpecificLanguage(languageToDelete.LanguageToBeDeleted);
                var deleteSuccessMessage =
                    _languagesComponent.GetSuccessMessageForDelete(languageToDelete.LanguageToBeDeleted);
                Console.WriteLine($"Success Message:{deleteSuccessMessage}");
                actualMessages.Add(deleteSuccessMessage);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertAllMessagesContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateLanguageWithExistingData))]
        public void UpdateLanguageWithExistingInput_ValidNegativeTest(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update languages with existing data...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var addSuccessMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"Success Message:{addSuccessMessage}");
            }

            State.Test.Log(Status.Info, "Enter the language and level for update using existing language");
            var existing = languagesModel.UpdateLanguage[0].ExistingLanguage;
            var update = languagesModel.UpdateLanguage[0].LanguageToUpdate;
            var level = languagesModel.UpdateLanguage[0].LanguageLevelToUpdate;

            _languagesComponent.UpdateLanguageAndLevel(existing, update, level);
            var updateSuccessMessage = _languagesComponent.GetSuccessMessageForUpdate(update);
            Console.WriteLine($"Success Message:{updateSuccessMessage}");
            actualMessages.Add(updateSuccessMessage);
            expectedMessages.Add(update);
            State.LanguagesToCleanUp.Add(update);

            var actualMessage = actualMessages.FirstOrDefault();
            var expectedMessage = expectedMessages.FirstOrDefault();
            if (actualMessage != null && expectedMessage != null)
            {
                State.Assert.Contains(actualMessage, expectedMessage, $"Actual message contains expected");
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddLanguagesInvalidData))]
        public void AddLanguages_InvalidInput(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add languages with invalid input....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"Message:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(lang.Validation.ExpectedMessage);
                State.LanguagesToCleanUp.Add(lang.Language); //Add languages to clean up
            }

            foreach (string? expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateLanguagesInvalidData))]
        public void UpdateLanguages_InvalidInput(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();
            State.Test.Log(Status.Info, "Starting update languages with invalid input....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"Success Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the language and level for update using existing language");
            foreach (var lang in languagesModel.UpdateLanguage)
            {
                _languagesComponent.UpdateLanguageAndLevel(lang.ExistingLanguage, lang.LanguageToUpdate,
                    lang.LanguageLevelToUpdate);
                var message = _languagesComponent.GetSuccessMessageForUpdate(lang.LanguageToUpdate);
                Console.WriteLine($"Message:{message}");
                actualMessages.Add(message);
                expectedMessages.Add(lang.LanguageToUpdate);
                State.LanguagesToCleanUp.Add(lang.LanguageToUpdate);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddLanguageDataWhenSessionExpired))]
        public void AddLanguage_SessionExpired(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting AddLanguages when session expired....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.ExpireSession();
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var errorMessage = _languagesComponent.GetErrorMessage();
                Console.WriteLine($"Error Message:{errorMessage}");
                actualMessages.Add(errorMessage);
                expectedMessages.Add(lang.Validation.ExpectedMessage);
            }

            foreach (string? expected in expectedMessages)
            {
                State.Assert.ListContainsString(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateLanguageDataWhenSessionExpired))]
        public void UpdateLanguage_SessionExpired(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update languages when session expired...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"Success Message:{successMessage}");
                State.LanguagesToCleanUp.Add(lang.Language);
            }

            State.Test.Log(Status.Info, "Enter the language and level for update using existing language");
            foreach (var lang in languagesModel.UpdateLanguage)
            {
                _languagesComponent.ExpireSession();
                _languagesComponent.UpdateLanguageAndLevel(lang.ExistingLanguage, lang.LanguageToUpdate,
                    lang.LanguageLevelToUpdate);
                var errorMessage = _languagesComponent.GetErrorMessage();
                Console.WriteLine($"Error Message:{errorMessage}");
                actualMessages.Add(errorMessage);
                _languagesComponent.ClickCancelUpdate();
                expectedMessages.Add(lang.Validation.ExpectedMessage);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.ListContainsString(actualMessages, expected);
            }

            _languagesComponent.ClickSignOutButton();
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.DeleteLanguageDataWhenSessionExpired))]
        public void DeleteLanguage_SessionExpired(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting delete languages when session expired....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"Success Message:{successMessage}");
                State.LanguagesToCleanUp.Add(lang.Language);
            }

            State.Test.Log(Status.Info, "Enter the language and level for delete using existing language");
            foreach (var lang in languagesModel.DeleteLanguage)
            {
                _languagesComponent.ExpireSession();
                _languagesComponent.DeleteSpecificLanguage(lang.LanguageToBeDeleted);
                var deleteErrorMessage = _languagesComponent.GetErrorMessage();
                actualMessages.Add(deleteErrorMessage);
                expectedMessages.Add(lang.Validation.ExpectedMessage);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.ListContainsString(actualMessages, expected);
            }

            _languagesComponent.ClickSignOutButton();
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.CancelAddLanguageData))]
        public void CancelAddLanguage(LanguageModel languagesModel)
        {
            List<bool> actualMessage = new();
            State.Test.Log(Status.Info, "Starting cancel add languages ....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to cancel add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.EnterLanguageAndLevelToCancelAdd(lang.Language, lang.LanguageLevel);
                _languagesComponent.ClickCancelButton();
                Console.WriteLine("Add language process has cancelled");
                var actual = _languagesComponent.IsLanguageNotAdded(lang.Language);
                actualMessage.Add(actual);
            }

            State.Assert.IsTrue(actualMessage);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.CancelUpdateLanguageData))]
        public void CancelUpdateLanguage(LanguageModel languagesModel)
        {
            List<bool> actualMessage = new();
            State.Test.Log(Status.Info, "Starting cancel update language...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"Success Message:{successMessage}");
                State.LanguagesToCleanUp.Add(lang.Language);
            }

            State.Test.Log(Status.Info, "Enter the language and level for update using existing language");
            foreach (var lang in languagesModel.UpdateLanguage)
            {
                _languagesComponent.EnterLanguageAndLevelToCancelForUpdate(lang.ExistingLanguage, lang.LanguageToUpdate,
                    lang.LanguageLevelToUpdate);
                _languagesComponent.ClickCancelUpdate();
                Console.WriteLine("Update language process has cancelled");
                var actual = _languagesComponent.IsLanguageNotUpdated(lang.LanguageToUpdate);
                actualMessage.Add(actual);
            }

            State.Assert.IsTrue(actualMessage);
        }

        [Test,TestCaseSource(typeof(TestDataProvider),nameof(TestDataProvider.LeaveEitherOneOrAllTheFieldsAreEmptyForAddLanguage))]
        public void AddLanguage_LeaveEitherOneFieldOrAllTheFieldsAreEmpty(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add languages with leave either one or all the fields are empty...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.LeaveTheLanguageAndLevelEmptyWithCombinationsForAdd(lang.Language,
                    lang.LanguageLevel);
                var message = _languagesComponent.GetErrorMessage();
                Console.WriteLine($"Message:{message}");
                actualMessages.Add(message);
                _languagesComponent.ClickCancelButton();
                expectedMessages.Add(lang.Validation.ExpectedMessage);
                //State.LanguagesToCleanUp.Add(lang.Language); //Add languages to clean up
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);

        }

        [Test,TestCaseSource(typeof(TestDataProvider),nameof(TestDataProvider.LeaveEitherOneOrAllTheFieldsAreEmptyForUpdateLanguage))]
        public void UpdateLanguage_LeaveEitherOneFieldOrAllTheFieldsAreEmpty(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update languages with leave either one or all the fields empty....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"Message:{successMessage}");
                State.LanguagesToCleanUp.Add(lang.Language); //Add languages to clean up
            }

            State.Test.Log(Status.Info, "Enter the language and level for update using existing language");
            foreach (var lang in languagesModel.UpdateLanguage)
            {
                _languagesComponent.LeaveTheLanguageAndLevelEmptyWithCombinationsForUpdate(lang.ExistingLanguage,
                    lang.LanguageToUpdate, lang.LanguageLevelToUpdate);
                var errorMessage = _languagesComponent.GetErrorMessage();
                actualMessages.Add(errorMessage);
                Console.WriteLine($"Error Message:{errorMessage}");
                _languagesComponent.ClickCancelUpdate();
                expectedMessages.Add(lang.Validation.ExpectedMessage);
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddHugeLanguageDestructiveTestData))]
        public void AddHugeLanguages_DestructiveTest(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add languages with huge string as input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level");
            foreach (var lang in languagesModel.AddLanguage)
            {
                if (lang.Language.Equals("{LONG_1000}"))
                {
                    lang.Language = new string('a', 1000);
                }

                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"SuccessMessage:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(lang.Validation.ExpectedMessage);
                State.LanguagesToCleanUp.Add(lang.Language); //Add languages to clean up
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateHugeLanguageDestructiveTestData))]
        public void UpdateHugeLanguages_DestructiveTest(LanguageModel languagesModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update languages with huge string as input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level to add");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);
                var successMessage = _languagesComponent.GetSuccessMessageForAddNewLanguage(lang.Language);
                Console.WriteLine($"SuccessMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the language and level for update using existing language");
            foreach (var lang in languagesModel.UpdateLanguage)
            {
                if (lang.LanguageToUpdate.Equals("{LONG_1000}"))
                {
                    lang.LanguageToUpdate = new string('a', 1000);
                }

                _languagesComponent.UpdateLanguageAndLevel(lang.ExistingLanguage, lang.LanguageToUpdate,
                    lang.LanguageLevelToUpdate);
                var message = _languagesComponent.GetSuccessMessageForUpdate(lang.LanguageToUpdate);
                actualMessages.Add(message);
                Console.WriteLine($"Error Message:{message}");
                expectedMessages.Add(lang.Validation.ExpectedMessage);
                State.LanguagesToCleanUp.Add(lang.LanguageToUpdate); //Add languages to clean up
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test,TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddLanguageWithExistingLanguageTestData))]
        public void AddLanguageWithExistingLanguageTest(LanguageModel languagesModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var validationMessage = new List<string>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting add languages with existing input....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);

                // Suppose this returns a tuple: (text, type)
                var (messageText, messageType) = _languagesComponent.GetToastMessage();

                actualMessages.Add((messageText, messageType));
                if (string.Equals(messageType, "SUCCESS", StringComparison.OrdinalIgnoreCase))
                {
                    // Positive row → add to cleanup, no message assertion
                    State.LanguagesToCleanUp.Add(lang.Language);
                }
                else if (string.Equals(messageType, "ERROR", StringComparison.OrdinalIgnoreCase) &&
                         !string.IsNullOrWhiteSpace(messageText))
                {
                    validationMessage.Add(messageText);
                    var expected = lang.Validation?.ExpectedMessage ?? string.Empty;
                    expectedMessages.Add(expected);
                }
            }

            // Assert only if we collected negative rows
            if (expectedMessages.Count > 0)
            {
                State.Assert.AssertListContainsAll(validationMessage, expectedMessages);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddLanguageWithExistingLanguageAndLevelTestData))]
        public void AddLanguageWithExistingLanguageAndLevelTest(LanguageModel languagesModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var validationMessage = new List<string>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting add languages with existing language and level....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _languagesComponent = new LanguagesComponent(State);
            _languagesComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the language and level");
            foreach (var lang in languagesModel.AddLanguage)
            {
                _languagesComponent.AddNewLanguageAndLevel(lang.Language, lang.LanguageLevel);

                // Suppose this returns a tuple: (text, type)
                var (messageText, messageType) = _languagesComponent.GetToastMessage();

                actualMessages.Add((messageText, messageType));
                if (string.Equals(messageType, "SUCCESS", StringComparison.OrdinalIgnoreCase))
                {
                    // Positive row → add to cleanup, no message assertion
                    State.LanguagesToCleanUp.Add(lang.Language);
                }
                else if (string.Equals(messageType, "ERROR", StringComparison.OrdinalIgnoreCase) &&
                         !string.IsNullOrWhiteSpace(messageText))
                {
                    validationMessage.Add(messageText);
                    var expected = lang.Validation?.ExpectedMessage ?? string.Empty;
                    expectedMessages.Add(expected);
                }

                // Assert only if we collected negative rows
                if (expectedMessages.Count > 0)
                {
                    State.Assert.AssertListContainsAll(validationMessage, expectedMessages);
                }
            }
        }
    }
}
