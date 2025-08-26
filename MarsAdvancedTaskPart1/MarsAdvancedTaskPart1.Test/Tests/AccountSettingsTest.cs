using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class AccountSettingsTest:TestBase.TestBase
    {
        private AccountSettingsComponent? _accountSettings;

        [Test,TestCaseSource(typeof(TestDataProvider),nameof(TestDataProvider.AccountSettingsData))]
        public void AccountSettings_EditName(AccountSettingsModel accountSettings)
        {
            State.Test.Log(Status.Info, "Starting AccountSettings Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _accountSettings = new AccountSettingsComponent(State);
            //Name update
            State.Test.Log(Status.Info, "Enter the username to edit");
            _accountSettings.EditAccountName(accountSettings.Name);

            var actual = _accountSettings.GetName();
            var expected = accountSettings.Name;
            State.Assert.IsEqualTo(expected,actual,"Name should be updated");
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AccountSettingsData))]
        public void AccountSettings_EditPassword(AccountSettingsModel accountSettings)
        {
            State.Test.Log(Status.Info, "Starting AccountTestings Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _accountSettings = new AccountSettingsComponent(State);
           
            //Password update
            State.Test.Log(Status.Info, "Enter password details");
            _accountSettings.EditAccountPassword(accountSettings.Password.CurrentPassword,
                accountSettings.Password.NewPassword,
                accountSettings.Password.ConfirmPassword);
            var actualMessage = _accountSettings.GetSuccessMessage();
            State.Assert.IsEqualTo(accountSettings.Password.ExpectedMessage, actualMessage, "Password has updated successfully");
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AccountSettingsData))]
        public void AccountSettings_CancelEditName(AccountSettingsModel accountSettings)
        {
            State.Test.Log(Status.Info, "Starting AccountTestings Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _accountSettings = new AccountSettingsComponent(State);
            State.Test.Log(Status.Info, "Click the cancel button");
            _accountSettings.CancelAccountNameEdit(accountSettings.Name);
            var actual = _accountSettings.GetNameAfterCancel();
            State.Assert.IsEqualTo(accountSettings.Name,actual,"Actual and Expected are same");
        }

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AccountSettingsData))]
        public void AccountSettings_CancelEditPassword(AccountSettingsModel accountSettings)
        {
            State.Test.Log(Status.Info, "Starting AccountTestings Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _accountSettings = new AccountSettingsComponent(State);
           
           _accountSettings.CancelAccountPasswordEdit(accountSettings.Password.CurrentPassword,
                accountSettings.Password.NewPassword,
                accountSettings.Password.ConfirmPassword);

            var actualMessage = _accountSettings.GetPasswordText();
            State.Assert.IsEqualTo(accountSettings.Password.CurrentPassword, actualMessage, "Actual and Expected are Equal");
        }

        [Test]
        public void AccountSettings_Notification()
        {
            State.Test.Log(Status.Info, "Starting AccountTestings Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _accountSettings = new AccountSettingsComponent(State);
            _accountSettings.ClickNotificationTab();
            var actual = _accountSettings.GetNotificationText();
            State.Assert.IsNotNullOrEmpty(actual,"Notification hasn't implemented yet");
        }

        [Test,TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.AccountSettingsData))]
        public void AccountSettings_Deactive(AccountSettingsModel accountSettings)
        {
            State.Test.Log(Status.Info, "Starting AccountTestings Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);

            _accountSettings = new AccountSettingsComponent(State);
            State.Test.Log(Status.Info, "Click the Deactivate button");
            _accountSettings.DeactivateAccount();
            var actual = _accountSettings.GetSuccessMessage();
            State.Assert.IsEqualTo(accountSettings.ExpectedMessageForDeactivateAccount, actual,"Expected and Actual are equal");
        }
    }
}
