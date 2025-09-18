using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent.ProfileComponent.ProfileOverviewComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class ProfileOverviewTest : TestBase.TestBase
    {
        private ProfileOverviewComponent? _profileOverviewComponent;

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewValidEntireFlow))]
        public void ProfileOverview_ValidDisplayName(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.ClickUserNameArrow();
                _profileOverviewComponent.SaveUserName(details.FirstName, details.LastName);
                var actual = _profileOverviewComponent.GetFullName();
                actualMessages.Add(actual);
                expectedMessages.Add(details.DisplayNameExpectedMessage);
                _profileOverviewComponent.SelectAvailabilityOption(details.Availability);
                var successAvailability = _profileOverviewComponent.GetSuccessMessage();
                actualMessages.Add(successAvailability);
                expectedMessages.Add(details.AvailabilityExpectedMessage);
                _profileOverviewComponent.SelectHoursOption(details.Hours);
                var successHours = _profileOverviewComponent.GetSuccessMessage();
                actualMessages.Add(successHours);
                expectedMessages.Add(details.HoursExpectedMessage);
                _profileOverviewComponent.SelectTargetOption(details.EarnTarget);
                var successEarnTarget = _profileOverviewComponent.GetSuccessMessage();
                actualMessages.Add(successEarnTarget);
                expectedMessages.Add(details.EarnTargetExpectedMessage);
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewValidUserName))]
        public void ProfileOverview_ValidUserName(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.ClickUserNameArrow();
                _profileOverviewComponent.SaveUserName(details.FirstName, details.LastName);
                var actual = _profileOverviewComponent.GetFullName();
                actualMessages.Add(actual);
                expectedMessages.Add(details.DisplayNameExpectedMessage);
            }
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewInvalidUserName))]
        public void ProfileOverview_InvalidUserName(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.ClickUserNameArrow();
                _profileOverviewComponent.SaveUserName(details.FirstName, details.LastName);
                var actual = _profileOverviewComponent.GetFullName();
                actualMessages.Add(actual);
                expectedMessages.Add(details.DisplayNameExpectedMessage);
            }

            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);

        }


        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewLeaveEitherOneOrAllTheFieldsEmpty))]
        public void ProfileOverview_LeaveEitherOneOrAllTheFieldsEmpty(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.ClickUserNameArrow();
                _profileOverviewComponent.LeaveEitherOneOrAllTheFieldsAreEmptyForUserNameUpdate(details.FirstName, details.LastName);
                var actual = _profileOverviewComponent.GetFullName();
                actualMessages.Add(actual);
                expectedMessages.Add(details.DisplayNameExpectedMessage);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewAddValidUserNameWhenSessionExpired))]
        public void ProfileOverview_AddValidUserNameWhenSessionExpired(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.ExpireSession();
                _profileOverviewComponent.ClickUserNameArrow();
                _profileOverviewComponent.SaveUserName(details.FirstName, details.LastName);
                var actual = _profileOverviewComponent.GetFullName();
                actualMessages.Add(actual);
                expectedMessages.Add(details.DisplayNameExpectedMessage);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewUpdateAvailability))]
        public void ProfileOverview_UpdateAvailability(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.SelectAvailabilityOption(details.Availability);
                var actual = _profileOverviewComponent.GetSuccessMessage();
                actualMessages.Add(actual);
                expectedMessages.Add(details.AvailabilityExpectedMessage);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewCancelAvailabilityUpdate))]
        public void ProfileOverview_CancelAvailabilityUpdate(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.CancelSelectAvailabilityOption();
                var actual = _profileOverviewComponent.GetAvailability();
                actualMessages.Add(actual);
                expectedMessages.Add(details.AvailabilityExpectedMessage);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewAvailabilityUpdateWhenSessionExpired))]
        public void ProfileOverview_UpdateAvailabilityWhenSessionExpired(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.ExpireSession();
                _profileOverviewComponent.SelectAvailabilityOption(details.Availability);
                var actual = _profileOverviewComponent.GetErrorMessage();
                actualMessages.Add(actual);
                expectedMessages.Add(details.AvailabilityExpectedMessage);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewUpdateHours))]
        public void ProfileOverview_UpdateHours(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.SelectHoursOption(details.Hours);
                var actual = _profileOverviewComponent.GetSuccessMessage();
                actualMessages.Add(actual);
                expectedMessages.Add(details.HoursExpectedMessage);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewCancelHoursUpdate))]
        public void ProfileOverview_CancelHoursUpdate(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.CancelSelectHoursOption();
                var actual = _profileOverviewComponent.GetHours();
                actualMessages.Add(actual);
                expectedMessages.Add(details.HoursExpectedMessage);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewUpdateHoursWhenSessionExpired))]
        public void ProfileOverview_UpdateHoursWhenSessionExpired(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.ExpireSession();
                _profileOverviewComponent.SelectHoursOption(details.Hours);
                var actual = _profileOverviewComponent.GetErrorMessage();
                actualMessages.Add(actual);
                expectedMessages.Add(details.HoursExpectedMessage);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewUpdateEarnTarget))]
        public void ProfileOverview_UpdateEarnTarget(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.SelectTargetOption(details.EarnTarget);
                var actual = _profileOverviewComponent.GetSuccessMessage();
                actualMessages.Add(actual);
                expectedMessages.Add(details.EarnTargetExpectedMessage);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewCancelEarnTargetUpdate))]
        public void ProfileOverview_CancelEarnTargetUpdate(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.CancelSelectTargetOption();
                var actual = _profileOverviewComponent.GetEarnTarget();
                actualMessages.Add(actual);
                expectedMessages.Add(details.EarnTargetExpectedMessage);
            }

            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ProfileOverviewUpdateEarnTargetWhenSessionExpired))]
        public void ProfileOverview_UpdateEarnTargetWhenSessionExpired(ProfileOverviewModel profileOverviewModel)
        {
            List<string> actualMessages = new();
            List<string> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add username details with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _profileOverviewComponent = new ProfileOverviewComponent(State);
            _profileOverviewComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the user name details to add ...");
            foreach (var details in profileOverviewModel.ProfileDetails)
            {
                _profileOverviewComponent.ExpireSession();
                _profileOverviewComponent.SelectTargetOption(details.EarnTarget);
                var actual = _profileOverviewComponent.GetErrorMessage();
                actualMessages.Add(actual);
                expectedMessages.Add(details.EarnTargetExpectedMessage);
            }
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertMultipleContain(actualMessages, expected);
            }
        }
    }
}
