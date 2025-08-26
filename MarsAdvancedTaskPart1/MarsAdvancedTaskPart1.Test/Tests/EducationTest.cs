using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent.ProfileComponent.ProfileMenuTabComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class EducationTest : TestBase.TestBase
    {
        private EducationComponent? _educationComponent;

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsValidData))] //Ad
        public void AddEducationDetails_ValidInput(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add education details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
                actualMessages.Add(successMessage);
                if (educationDetailsToAdd.EducationExpectedMessage != null)
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
                State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsInvalidCollegeUniversityData))]
        public void AddEducationDetails_InvalidCollegeName(EducationModel educationModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting add education details with invalid college name...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var (messageText, messageType) = _educationComponent.GetToastMessage();
                Console.WriteLine($"Message:{messageText},{messageType}");
                Thread.Sleep(5000);
                actualMessages.Add((messageText, messageType));

                if (string.Equals(messageType, "Success", StringComparison.OrdinalIgnoreCase))
                {
                    State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
                }
                else if (string.Equals(messageType, "Error", StringComparison.OrdinalIgnoreCase))
                {
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
                }
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertToastMessageForInvalid(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsInvalidDegreeData))]
        public void AddEducationDetails_InvalidDegree(EducationModel educationModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting add education details with invalid degree ...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var (messageText, messageType) = _educationComponent.GetToastMessage();
                Console.WriteLine($"Message:{messageText},{messageType}");
                Thread.Sleep(5000);
                actualMessages.Add((messageText, messageType));

                if (string.Equals(messageType, "Success", StringComparison.OrdinalIgnoreCase))
                {
                    State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
                }
                else if (string.Equals(messageType, "Error", StringComparison.OrdinalIgnoreCase))
                {
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
                }
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertToastMessageForInvalid(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsNegativeTestingValidData))]
        public void AddEducationDetails_NegativeTestingValidInput(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add education details with negative testing valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var actualMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                if (educationDetailsToAdd.EducationExpectedMessage != null)
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
                State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsLeaveEitherOneOrAllTheFieldsEmpty))]
        public void AddEducationDetails_LeaveEitherOneOrAllTheFieldsEmpty(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add education details with leave either one or all the fields empty...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.LeaveEitherOneOrAllTheFieldsEmptyToAdd(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var actualMessage = _educationComponent.GetErrorMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                if (educationDetailsToAdd.EducationExpectedMessage != null)
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
            }
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsMoreThan250CharactersOfCollegeUniversityName))]
        public void AddEducationDetails_MoreThan250CharactersAsCollegeName(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add education details with string length of 250 characters..");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var actualMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                if (educationDetailsToAdd.EducationExpectedMessage != null)
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
                State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsMoreThan250CharactersOfDegreeName))]
        public void AddEducationDetails_MoreThan250CharactersAsDegree(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();
              
            State.Test.Log(Status.Info, "Starting add education details with string length of 250 characters...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var actualMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                if (educationDetailsToAdd.EducationExpectedMessage != null)
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
                State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsWhenSessionExpired))]
        public void AddEducationDetails_WhenSessionExpired(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add education details when session expired...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.ExpireSession();
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var actualMessage = _educationComponent.GetErrorMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                if (educationDetailsToAdd.EducationExpectedMessage != null)
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
            }
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsDuplicateData))]
        public void AddEducationDetails_DuplicateData(EducationModel educationModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting add education details with duplicate data...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var (messageText, messageType) = _educationComponent.GetToastMessage();
                Console.WriteLine($"Message:{messageText},{messageType}");
                Thread.Sleep(5000);
                actualMessages.Add((messageText, messageType));

                if (string.Equals(messageType, "Success", StringComparison.OrdinalIgnoreCase))
                {
                    State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
                }
                else if (string.Equals(messageType, "Error", StringComparison.OrdinalIgnoreCase))
                {
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
                }
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertToastMessage(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsCancel))]
        public void AddEducationDetails_Cancel(EducationModel educationModel)
        {
            List<bool> actualMessages = new();
            State.Test.Log(Status.Info, "Starting cancel add education details...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();
            State.Test.Log(Status.Info, "Enter the education details to add ...");

            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.CancelAddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                Console.WriteLine("Add education details cancelled");
                var actual = _educationComponent.IsEducationEmpty(educationDetailsToAdd.CollegeUniversityName);
                actualMessages.Add(actual);
            }

            State.Assert.IsTrue(actualMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddEducationDetailsDestructiveTestData))]
        public void AddEducationDetails_DestructiveTest(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add education details with huge string length...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();     
            
            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                if (educationDetailsToAdd.CollegeUniversityName.Equals("{LONG_5000}"))
                {
                    educationDetailsToAdd.CollegeUniversityName = new string('s', 5000);
                }
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
                actualMessages.Add(successMessage);
                if (educationDetailsToAdd.EducationExpectedMessage != null)
                    expectedMessages.Add(educationDetailsToAdd.EducationExpectedMessage);
                State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
            }
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsWithValidData))]
        public void UpdateEducationDetails_ValidInput(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update education details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;

                _educationComponent.UpdateEducationDetails(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessageForUpdate(detailsToUpdate.CollegeUniversityName);
                actualMessages.Add(successMessage);
                if (detailsToUpdate.EducationExpectedMessage != null)
                    expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
                State.EducationToCleanUp.Add(detailsToUpdate.CollegeUniversityName);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsWithInvalidCollegeName))]
        public void UpdateEducationDetails_InvalidCollegeName(EducationModel educationModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var expectedMessages = new List<string>();

            State.Test.Log(Status.Info, "Starting update education details with invalid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;
                _educationComponent.UpdateEducationDetails(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);
                var (messageText, messageType) = _educationComponent.GetToastMessage();
                Console.WriteLine($"Message:{messageText},{messageType}");

                actualMessages.Add((messageText, messageType));

                if (string.Equals(messageType, "Success", StringComparison.OrdinalIgnoreCase))
                {
                    State.EducationToCleanUp.Add(detailsToUpdate.CollegeUniversityName);
                }
                else if (string.Equals(messageType, "Error", StringComparison.OrdinalIgnoreCase))
                {
                    if (detailsToUpdate.EducationExpectedMessage != null)
                        expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
                    State.EducationToCleanUp.Add(existingDetails.CollegeUniversityName);
                }
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertToastMessageForInvalid(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsWithInvalidDegreeName))]
        public void UpdateEducationDetails_InvalidDegreeName(EducationModel educationModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var expectedMessages = new List<string>();

            State.Test.Log(Status.Info, "Starting update education details with invalid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();
            State.Test.Log(Status.Info, "Enter the education details to add ...");

            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;
                _educationComponent.UpdateEducationDetails(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);
                var (messageText, messageType) = _educationComponent.GetToastMessage();
                Console.WriteLine($"Message:{messageText},{messageType}");

                actualMessages.Add((messageText, messageType));

                if (string.Equals(messageType, "Success", StringComparison.OrdinalIgnoreCase))
                {
                    State.EducationToCleanUp.Add(detailsToUpdate.CollegeUniversityName);
                }
                else if (string.Equals(messageType, "Error", StringComparison.OrdinalIgnoreCase))
                {
                    if (detailsToUpdate.EducationExpectedMessage != null)
                        expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
                    State.EducationToCleanUp.Add(existingDetails.CollegeUniversityName);
                }
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertToastMessageForInvalid(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsLeaveEitherOneOrAllTheFieldsEmpty))]
        public void UpdateEducationDetails_LeaveEitherOneOrAllTheFieldsEmpty(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update education details with leave either one or all the fields are empty...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;

                _educationComponent.LeaveEitherOneOrAllTheFieldsEmptyToUpdate(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);
                var errorMessage = _educationComponent.GetErrorMessage();
                actualMessages.Add(errorMessage);
                if (detailsToUpdate.EducationExpectedMessage != null)
                    expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsWithExistingData))]
        public void UpdateEducationDetails_DuplicateData(EducationModel educationModel)
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting update education details with existing details...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree,
                    educationDetailsToAdd.YearOfGraduation);
                var actualMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                State.EducationToCleanUp.Add(educationDetailsToAdd.CollegeUniversityName);
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;
                _educationComponent.UpdateEducationDetails(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);
                if (detailsToUpdate.EducationExpectedMessage != null)
                {
                    var message = _educationComponent.GetErrorMessage();
                    Console.WriteLine($"ErrorMessage:{message}");
                    actualMessages.Add(message);
                    expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
                }
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsDestructiveTestData))]
        public void UpdateEducationDetails_DestructiveTest(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update education details with huge string...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;
                if (detailsToUpdate.CollegeUniversityName.Equals("{LONG_5000}"))
                {
                    detailsToUpdate.CollegeUniversityName = new string('A', 5000);
                }
                _educationComponent.UpdateEducationDetails(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);
                if (detailsToUpdate.EducationExpectedMessage != null)
                {
                    var successMessage = _educationComponent.GetSuccessMessageForUpdate(detailsToUpdate.EducationExpectedMessage);
                    Console.WriteLine($"successMessage:{successMessage}");
                    actualMessages.Add(successMessage);
                }
                if (detailsToUpdate.EducationExpectedMessage != null)
                    expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
                State.EducationToCleanUp.Add(detailsToUpdate.CollegeUniversityName);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsWhenSessionExpired))]
        public void UpdateEducationDetails_WhenSessionExpired(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update education details when session expired...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;

                _educationComponent.ExpireSession();
                _educationComponent.UpdateEducationDetails(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);
                var message = _educationComponent.GetErrorMessage();
                actualMessages.Add(message);
                if (detailsToUpdate.EducationExpectedMessage != null)
                    expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
                _educationComponent.ClickSignOutButton();
                State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
                _educationComponent.NavigateToTheProfilePage();
                State.EducationToCleanUp.Add(existingDetails.CollegeUniversityName);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsWithValidInputNegativeTesting))]
        public void UpdateEducationDetails_ValidInputNegativeTesting(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting Add education details with valid input negative testing...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;

                _educationComponent.UpdateEducationDetails(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);

                var successMessage = _educationComponent.GetSuccessMessage();
                actualMessages.Add(successMessage);
                if (detailsToUpdate.EducationExpectedMessage != null)
                    expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
                State.EducationToCleanUp.Add(detailsToUpdate.CollegeUniversityName);

            }
           
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsMoreThan250CharactersOfCollegeUniversityName))]
        public void UpdateEducationDetails_MoreThan250CharactersOfCollegeName(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update education details with string length 250...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var educationDetailsToAdd = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(educationDetailsToAdd.CollegeUniversityName, educationDetailsToAdd.Country, educationDetailsToAdd.Title, educationDetailsToAdd.Degree, educationDetailsToAdd.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;

                _educationComponent.UpdateEducationDetails(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);

                var successMessage = _educationComponent.GetSuccessMessage();
                actualMessages.Add(successMessage);
                if (detailsToUpdate.EducationExpectedMessage != null)
                    expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
                State.EducationToCleanUp.Add(detailsToUpdate.CollegeUniversityName);

            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateEducationDetailsMoreThan250CharactersOfDegreeName))]
        public void UpdateEducationDetails_MoreThan250CharactersOfDegreeName(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update education details with string length 250....");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var edu = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(edu.CollegeUniversityName, edu.Country, edu.Title, edu.Degree, edu.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the education details to update ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var existingDetails = testItem.EducationDetailsToAdd;
                var detailsToUpdate = testItem.EducationDetailsToUpdate;

                _educationComponent.UpdateEducationDetails(existingDetails.CollegeUniversityName, detailsToUpdate.CollegeUniversityName, detailsToUpdate.Country, detailsToUpdate.Title, detailsToUpdate.Degree, detailsToUpdate.YearOfGraduation);

                var successMessage = _educationComponent.GetSuccessMessage();
                actualMessages.Add(successMessage);
                if (detailsToUpdate.EducationExpectedMessage != null)
                    expectedMessages.Add(detailsToUpdate.EducationExpectedMessage);
                State.EducationToCleanUp.Add(detailsToUpdate.CollegeUniversityName);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.DeleteEducationDetails))]
        public void DeleteEducationDetails(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting delete education details ...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var edu = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(edu.CollegeUniversityName, edu.Country, edu.Title, edu.Degree, edu.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the education details to delete ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var detailsToDelete = testItem.EducationDetailsToDelete;

                _educationComponent.DeleteSpecificEducation(detailsToDelete.CollegeUniversityName);

                var successMessage = _educationComponent.GetSuccessMessage();
                actualMessages.Add(successMessage);
                if (detailsToDelete.EducationExpectedMessage != null)
                    expectedMessages.Add(detailsToDelete.EducationExpectedMessage);
            }
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.DeleteEducationDetailsWhenSessionExpired))]
        public void DeleteEducationDetails_WhenSessionExpired(EducationModel educationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting delete education details when session expired...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent = new EducationComponent(State);
            _educationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the education details to add ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var edu = testItem.EducationDetailsToAdd;
                _educationComponent.AddEducationDetails(edu.CollegeUniversityName, edu.Country, edu.Title, edu.Degree, edu.YearOfGraduation);
                var successMessage = _educationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                State.EducationToCleanUp.Add(edu.CollegeUniversityName);
            }

            State.Test.Log(Status.Info, "Enter the education details to delete ...");
            foreach (var testItem in educationModel.TestItems)
            {
                var detailsToDelete = testItem.EducationDetailsToDelete;
                _educationComponent.ExpireSession();
                _educationComponent.DeleteSpecificEducation(detailsToDelete.CollegeUniversityName);

                var errorMessage = _educationComponent.GetErrorMessage();
                actualMessages.Add(errorMessage);
                if (detailsToDelete.EducationExpectedMessage != null)
                    expectedMessages.Add(detailsToDelete.EducationExpectedMessage);
            }
            _educationComponent.ClickSignOutButton();
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _educationComponent.NavigateToTheProfilePage();
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }
    }
}
