using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent
{
    public class ChangePasswordComponent
    {
        private readonly TestState _state;

        public ChangePasswordComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _welcomeMessageElement = By.XPath("//span[contains(@class, 'dropdown') and contains(normalize-space(), 'Ambika')]");
        private readonly By _changePasswordElement = By.XPath("//a[normalize-space()='Change Password']");
        private readonly By _currentPasswordElement = By.XPath("//input[@placeholder='Current Password']");
        private readonly By _newPasswordElement = By.XPath("//input[@placeholder='New Password']");
        private readonly By _confirmPasswordElement = By.XPath("//input[@placeholder='Confirm Password']");
        private readonly By _saveButtonElement = By.XPath("//button[@role='button']");

        private readonly By _successMessageElement =
            By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']");

        //Action Methods
        public void ClickWelcomeMessage()
        {
            _state.Wait.WaitUntilElementToBeClickable(_welcomeMessageElement).Click();
        }

        public void ClickChangePassword()
        {
            _state.Wait.WaitUntilElementIsVisible(_changePasswordElement).Click();
        }

        public void EnterCurrentPassword(string currentPassword)
        {
            _state.Wait.WaitUntilElementIsVisible(_currentPasswordElement).SendKeys(currentPassword);
        }

        public void EnterNewPassword(string newPassword)
        {
            _state.Wait.WaitUntilElementIsVisible(_newPasswordElement).SendKeys(newPassword);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            _state.Wait.WaitUntilElementIsVisible(_confirmPasswordElement).SendKeys(confirmPassword);
        }

        public void ClickSaveButton()
        {
            _state.Wait.WaitUntilElementToBeClickable(_saveButtonElement).Click();
        }

        public string GetSuccessMessage()
        {
            var successMessage =_state.Wait.WaitUntilElementIsVisible(_successMessageElement).Text;
            return successMessage;
        }

        public void ChangePassword(string currentPassword, string newPassword,string confirmPassword)
        {
            ClickWelcomeMessage();
            ClickChangePassword();
            EnterCurrentPassword(currentPassword);
            EnterNewPassword(newPassword);
            EnterConfirmPassword(confirmPassword);
            ClickSaveButton();
        }
    }
}



