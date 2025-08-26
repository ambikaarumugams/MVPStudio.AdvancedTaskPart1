using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components;
using MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class ChangePasswordTest:TestBase.TestBase
    {
        private ChangePasswordComponent? _changePassword;

        [Test,TestCaseSource(typeof(TestDataProvider),nameof(TestDataProvider.ChangePasswordData))]
        public void ChangePasswordMethod(ChangePasswordModel changePassword)
        {
            State.Test.Log(Status.Info, "Starting Change Password Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username,State.LoginData.Password);

            _changePassword = new ChangePasswordComponent(State);
            _changePassword.ClickWelcomeMessage();
            State.Test.Log(Status.Info, "Enter password details for changing the password");
            _changePassword.ChangePassword(changePassword.CurrentPassword,changePassword.NewPassword,changePassword.ConfirmPassword);
            var actualMessage=_changePassword.GetSuccessMessage();
            State.Assert.IsEqualTo(actualMessage,changePassword.ExpectedMessage,$"Actual and Expected are Equal");
        }
    }
}
