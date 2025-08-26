using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent.ProfileComponent.ProfileMenuTabComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class CertificationTest : TestBase.TestBase
    {
        private CertificationComponent? _certificationComponent;

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsValidData))] //Add
        public void AddCertificationDetails_ValidInput(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add certification details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
                State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsInvalidCertificateOrAwardData))]
        public void AddCertificationDetails_InvalidCertificateOrAward(CertificationModel certificationModel)
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting add certification details with invalid certificate or award...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward, certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
                State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsInvalidCertificateFromData))]
        public void AddCertificationDetails_InvalidCertificateFrom(CertificationModel certificationModel)
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting add certification details with invalid certificate from...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward, certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
                State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsCertificateOrAwardAndCertificateMismatchData))]
        public void AddCertificationDetails_CertificateOrAwardAndCertificateMismatch(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add certification details with mismatch of certificate or award and ceritified from...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward, certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var actualMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
                State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsLeaveEitherOneOrAllTheFieldsEmptyData))]
        public void AddCertificationDetails_LeaveEitherOneOrAllTheFieldsEmpty(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add certification details with leave one or all the fields empty...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.LeaveEitherOneOrAllTheFieldsEmptyForAdd(
                    certificationDetailsToAdd.CertificateOrAward, certificationDetailsToAdd.CertifiedFrom,
                    certificationDetailsToAdd.Year);
                var actualMessage = _certificationComponent.GetErrorMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
                _certificationComponent.ClickCancelButton();
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsMoreThan250CharactersOfCertificateOrAwardData))]
        public void AddCertificationDetails_MoreThan250CharactersAsCharactersOfCertificateOrAward(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add certification details with 250 characters of certificate or award...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                if (certificationDetailsToAdd.CertificateOrAward.Equals("{LONG_255}"))
                {
                    certificationDetailsToAdd.CertificateOrAward = new string('s', 255);
                }

                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward, certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var actualMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
                State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsMoreThan250CharactersOfCertificateFromData))]
        public void AddCertificationDetails_MoreThan250CharactersAsCertificateFrom(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add certification details with 250 characters of certificate from...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                if (certificationDetailsToAdd.CertifiedFrom.Equals("{LONG_300}"))
                {
                    certificationDetailsToAdd.CertifiedFrom = new string('s', 300);
                }

                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward, certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var actualMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
                State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsWhenSessionExpired))]
        public void AddCertificationDetails_WhenSessionExpired(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add certification details when session expired..");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.ExpireSession();
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var actualMessage = _certificationComponent.GetErrorMessage();
                Console.WriteLine($"Message:{actualMessage}");
                actualMessages.Add(actualMessage);
                expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsDuplicateData))]
        public void AddCertificationDetails_DuplicateData(CertificationModel certificationModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting add certification details with duplicate data...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward, certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var (messageText, messageType) = _certificationComponent.GetToastMessage();
                Console.WriteLine($"Message:{messageText},{messageType}");
                Thread.Sleep(5000);
                actualMessages.Add((messageText, messageType));

                if (string.Equals(messageType, "Success", StringComparison.OrdinalIgnoreCase))
                {
                    State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
                }
                else if (string.Equals(messageType, "Error", StringComparison.OrdinalIgnoreCase))
                {
                    expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
                }
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertToastMessage(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsCancel))]
        public void AddCertificationDetails_Cancel(CertificationModel certificationModel)
        {
            List<bool> actualMessages = new();
            State.Test.Log(Status.Info, "Starting cancel add certification details ...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.CancelAddCertificationDetails(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                Console.WriteLine("Add certification details cancelled");
                var actual = _certificationComponent.IsCertificationEmpty(certificationDetailsToAdd.CertificateOrAward);
                actualMessages.Add(actual);
            }

            State.Assert.IsTrue(actualMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AddCertificationDetailsDestructiveTestingData))]
        public void AddCertificationDetails_DestructiveTest(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add certification details with huge string length...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                if (certificationDetailsToAdd.CertificateOrAward.Equals("{LONG_5000}"))
                {
                    certificationDetailsToAdd.CertificateOrAward = new string('s', 5000);
                }

                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
                actualMessages.Add(successMessage);
                expectedMessages.Add(certificationDetailsToAdd.ExpectedMessage);
                State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsValidData))]
        public void UpdateCertificationDetails_ValidInput(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update certification details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;

                _certificationComponent.UpdateCertificationDetails(existingDetails.CertificateOrAward,
                    detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var successMessage =
                    _certificationComponent.GetSuccessMessageForUpdate(detailsToUpdate.CertificateOrAward);
                actualMessages.Add(successMessage);
                expectedMessages.Add(detailsToUpdate.ExpectedMessage);
                State.CertificationToCleanUp.Add(detailsToUpdate.CertificateOrAward);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsInvalidCertificateOrAwardData))]
        public void UpdateCertificationDetails_InvalidCertificateOrAward(CertificationModel certificationModel)
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string>();

            State.Test.Log(Status.Info, "Starting update certification details with invalid certificate or award...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;

                _certificationComponent.UpdateCertificationDetails(existingDetails.CertificateOrAward, detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var successMessage = _certificationComponent.GetSuccessMessageForUpdate(detailsToUpdate.CertificateOrAward);
                actualMessages.Add(successMessage);
                expectedMessages.Add(detailsToUpdate.ExpectedMessage);
                State.CertificationToCleanUp.Add(detailsToUpdate.CertificateOrAward);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsInvalidCertificateFromData))]
        public void UpdateCertificationDetails_InvalidCertificateFrom(CertificationModel certificationModel)
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string>();

            State.Test.Log(Status.Info, "Starting update certification details with invalid certificate from...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;

                _certificationComponent.UpdateCertificationDetails(existingDetails.CertificateOrAward, detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var successMessage =
                    _certificationComponent.GetSuccessMessageForUpdate(detailsToUpdate.CertificateOrAward);
                actualMessages.Add(successMessage);
                expectedMessages.Add(detailsToUpdate.ExpectedMessage);
                State.CertificationToCleanUp.Add(detailsToUpdate.CertificateOrAward);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test,
         TestCaseSource(typeof(TestDataProvider),
             nameof(TestDataProvider.UpdateCertificationDetailsLeaveEitherOneOrAllTheFieldsEmptyData))]
        public void UpdateCertificationDetails_LeaveEitherOneOrAllTheFieldsEmpty(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update certification details with leave either one or all the fields empty ...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
                State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;

                _certificationComponent.LeaveEitherOneOrAllTheFieldsEmptyForUpdate(existingDetails.CertificateOrAward,
                    detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var errorMessage = _certificationComponent.GetErrorMessage();
                actualMessages.Add(errorMessage);
                expectedMessages.Add(detailsToUpdate.ExpectedMessage);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsCertificateOrAwardAndCertifiedFromMismatch))]
        public void UpdateCertificationDetails_CertificateOrAwardAndCertifiedFromMismatch(CertificationModel certificationModel)
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string?>();

            State.Test.Log(Status.Info, "Starting Add certification details with certificate or award and certificate from mismatch...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;

                _certificationComponent.UpdateCertificationDetails(existingDetails.CertificateOrAward, detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var message = _certificationComponent.GetSuccessMessageForUpdate(detailsToUpdate.CertificateOrAward);
                actualMessages.Add(message);
                expectedMessages.Add(detailsToUpdate.ExpectedMessage);
                State.CertificationToCleanUp.Add(detailsToUpdate.CertificateOrAward);
            }

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsDestructiveTesting))]
        public void UpdateCertificationDetails_DestructiveTest(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update certification details with huge string...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;
                if (detailsToUpdate.CertificateOrAward.Equals("{LONG_5000}"))
                {
                    detailsToUpdate.CertificateOrAward = new string('A', 5000);
                }

                _certificationComponent.UpdateCertificationDetails(existingDetails.CertificateOrAward,
                    detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var message = _certificationComponent.GetSuccessMessageForUpdate(detailsToUpdate.CertificateOrAward);
                actualMessages.Add(message);
                expectedMessages.Add(detailsToUpdate.ExpectedMessage);
                State.CertificationToCleanUp.Add(detailsToUpdate.CertificateOrAward);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsWhenSessionExpired))]
        public void UpdateCertificationDetails_WhenSessionExpired(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update certification details when session expired...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;

                _certificationComponent.ExpireSession();
                _certificationComponent.UpdateCertificationDetails(existingDetails.CertificateOrAward, detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var message = _certificationComponent.GetErrorMessage();
                actualMessages.Add(message);
                expectedMessages.Add(detailsToUpdate.ExpectedMessage);
                _certificationComponent.ClickSignOutButton();
                State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
                _certificationComponent.NavigateToTheProfilePage();
                State.CertificationToCleanUp.Add(existingDetails.CertificateOrAward);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsDuplicateData))]
        public void UpdateCertificationDetails_Duplicate(CertificationModel certificationModel)
        {
            var actualMessages = new List<(string Message, string Type)>();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update certification details with duplicate data...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;
                _certificationComponent.UpdateCertificationDetails(existingDetails.CertificateOrAward, detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var (messageText, messageType) = _certificationComponent.GetToastMessage();
                Console.WriteLine($"Message:{messageText},{messageType}");
                actualMessages.Add((messageText, messageType));

                if (string.Equals(messageType, "Success", StringComparison.OrdinalIgnoreCase))
                {
                    State.CertificationToCleanUp.Add(existingDetails.CertificateOrAward);
                }
                else if (string.Equals(messageType, "Error", StringComparison.OrdinalIgnoreCase))
                {
                    expectedMessages.Add(detailsToUpdate.ExpectedMessage);
                }
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertToastMessage(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsMoreThan250CharactersOfCertificateOrAward))]
        public void UpdateCertificationDetails_MoreThan250CharactersOfCertificateOrAward(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update certification details with 250 characters of certificate or award...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;
                if (detailsToUpdate.CertificateOrAward.Equals("{LONG_300}"))
                {
                    detailsToUpdate.CertificateOrAward = new string('s', 300);
                }

                _certificationComponent.UpdateCertificationDetails(existingDetails.CertificateOrAward, detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var message = _certificationComponent.GetSuccessMessage();
                actualMessages.Add(message);
                expectedMessages.Add(detailsToUpdate.ExpectedMessage);
                State.CertificationToCleanUp.Add(detailsToUpdate.CertificateOrAward);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsMoreThan250CharactersOfCertificateFrom))]
        public void UpdateCertificationDetails_MoreThan250CharactersOfCertifiedFrom(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting update certification details with 250 characters of certified from...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;
                if (detailsToUpdate.CertifiedFrom.Equals("{LONG_300}"))
                {
                    detailsToUpdate.CertifiedFrom = new string('s', 300);
                }

                _certificationComponent.UpdateCertificationDetails(existingDetails.CertificateOrAward,
                    detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                var message = _certificationComponent.GetSuccessMessage();
                actualMessages.Add(message);
                expectedMessages.Add(detailsToUpdate.ExpectedMessage);
                State.CertificationToCleanUp.Add(detailsToUpdate.CertificateOrAward);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.UpdateCertificationDetailsCancel))]
        public void UpdateCertificationDetails_Cancel(CertificationModel certificationModel)
        {
            List<string>? actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting cancel update certification details...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the certification details to add ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to update ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var existingDetails = testItem.CertificationDetailsToAdd;
                var detailsToUpdate = testItem.CertificationDetailsToUpdate;

                _certificationComponent.CancelUpdateCertificationDetails(existingDetails.CertificateOrAward,
                    detailsToUpdate.CertificateOrAward, detailsToUpdate.CertifiedFrom, detailsToUpdate.Year);
                actualMessages.Add(existingDetails.CertificateOrAward);
                expectedMessages.Add(detailsToUpdate.CertificateOrAward);
                State.CertificationToCleanUp.Add(existingDetails.CertificateOrAward);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.IsNotEqualTo(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.DeleteCertificationDetails))]
        public void DeleteCertificationDetails(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting delete certification details ...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();
            State.Test.Log(Status.Info, "Enter the certification details to add ...");

            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
            }

            State.Test.Log(Status.Info, "Enter the certification details to delete ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var detailsToDelete = testItem.CertificationDetailsToDelete;

                _certificationComponent.DeleteSpecificCertification(detailsToDelete.CertificateOrAward);

                var successMessage = _certificationComponent.GetSuccessMessage();
                actualMessages.Add(successMessage);
                if (detailsToDelete.ExpectedMessage != null)
                    expectedMessages.Add(detailsToDelete.ExpectedMessage);
            }
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.DeleteCertificationDetailsWhenSessionExpired))]
        public void DeletecertificationDetails_WhenSessionExpired(CertificationModel certificationModel)
        {
            List<string> actualMessages = new();
            List<string>? expectedMessages = new();

            State.Test.Log(Status.Info, "Starting delete certification details when session expired...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _certificationComponent = new CertificationComponent(State);
            _certificationComponent.NavigateToTheProfilePage();
            State.Test.Log(Status.Info, "Enter the certification details to add ...");

            foreach (var testItem in certificationModel.TestItems)
            {
                var certificationDetailsToAdd = testItem.CertificationDetailsToAdd;
                _certificationComponent.AddCertifications(certificationDetailsToAdd.CertificateOrAward,
                    certificationDetailsToAdd.CertifiedFrom, certificationDetailsToAdd.Year);
                var successMessage = _certificationComponent.GetSuccessMessage();
                Console.WriteLine($"successMessage:{successMessage}");
                State.CertificationToCleanUp.Add(certificationDetailsToAdd.CertificateOrAward);
            }

            State.Test.Log(Status.Info, "Enter the certification details to delete ...");
            foreach (var testItem in certificationModel.TestItems)
            {
                var detailsToDelete = testItem.CertificationDetailsToDelete;
                _certificationComponent.ExpireSession();
                _certificationComponent.DeleteSpecificCertification(detailsToDelete.CertificateOrAward);

                var errorMessage = _certificationComponent.GetErrorMessage();
                actualMessages.Add(errorMessage);
                if (detailsToDelete.ExpectedMessage != null)
                    expectedMessages.Add(detailsToDelete.ExpectedMessage);
            }
            _certificationComponent.ClickSignOutButton();
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _certificationComponent.NavigateToTheProfilePage();
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }
    }
}



