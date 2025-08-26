using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent
{
    public class AccountSettingsComponent
    {
        private readonly TestState _state;
       
        public AccountSettingsComponent(TestState state)
        {
            _state=state;
        }

        //Locators
        private readonly By _welcomeMessageElement = By.XPath("//span[contains(@class, 'dropdown') and contains(normalize-space(), 'Ambika')]");
        private readonly By _accountSettingsElement = By.XPath("//a[normalize-space()='Account Settings']");
        private readonly By _accountTabElement= By.XPath("//a[normalize-space()='Account']");
       // private readonly By _editNameIconElement = By.XPath("//i[@class='grey pencil icon']");

        private readonly By _nameTextBoxElement = By.XPath("//input[@type='text' and @id='Name']");
        private readonly By _saveNameButtonElement = By.XPath("//button[normalize-space()='Save']");
        private readonly By _cancelNameButtonElement = By.XPath("//button[normalize-space()='Cancel']");
        //private readonly By _editPasswordIconElement = By.XPath("//i[@class='grey pencil icon'][1]");
        private readonly By _passwordTextBoxElement = By.XPath("//input[@id='Password']");
        private readonly By _currentPasswordElement = By.XPath("//input[@placeholder='Current Password']");
        private readonly By _newPasswordElement = By.XPath("//input[@placeholder='New Password']");
        private readonly By _confirmPasswordElement = By.XPath("//input[@placeholder='Confirm Password']");
        private readonly By _savePasswordButtonElement = By.XPath("//button[normalize-space()='Save']");
        private readonly By _cancelPasswordButtonElement = By.XPath("//button[normalize-space()='Cancel']");
        private readonly By _notificationTabElement = By.XPath("//a[normalize-space()='Notification']");
        private readonly By _notificationTextElement = By.XPath("//div[contains(text(),'to be implement')]");
        private readonly By _deactiveTabElement = By.XPath("//a[normalize-space()='Deactive']");
        private readonly By _deactivateButtonElement = By.XPath("//button[normalize-space()='Deactivate']");

        private readonly By _successMessage =
            By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']");

        //Action Methods
        public void ClickWelcomeMessageLink()
        {
            _state.Wait.WaitUntilElementToBeClickable(_welcomeMessageElement).Click();
        }

        public void ClickAccountSettingsLink()
        {
            _state.Wait.WaitUntilElementToBeClickable(_accountSettingsElement).Click();
        }

        public void ClickAccountTab()
        {
            _state.Wait.WaitUntilElementToBeClickable(_accountTabElement).Click();
        }

        public void EditName(string name)
        {
            _state.Wait.WaitUntilElementToBeClickable(_nameTextBoxElement).Click();
            _state.Wait.WaitUntilElementToBeClickable(_nameTextBoxElement).Clear();
            _state.Wait.WaitUntilElementIsVisible(_nameTextBoxElement).SendKeys(name);
            _state.Wait.WaitUntilElementToBeClickable(_saveNameButtonElement).Click();
        }

        public void CancelEditName(string name)
        {
            _state.Wait.WaitUntilElementToBeClickable(_nameTextBoxElement).Click();
            _state.Wait.WaitUntilElementIsVisible(_nameTextBoxElement).SendKeys(name);
            _state.Wait.WaitUntilElementToBeClickable(_cancelNameButtonElement).Click();
        }

        public void EditPassword(string currentPassword, string newPassword, string confirmPassword)
        {
            _state.Wait.WaitUntilElementToBeClickable(_passwordTextBoxElement).Click();
            _state.Wait.WaitUntilElementToBeClickable(_currentPasswordElement).SendKeys(currentPassword);
            _state.Wait.WaitUntilElementToBeClickable(_newPasswordElement).SendKeys(newPassword);
            _state.Wait.WaitUntilElementToBeClickable(_confirmPasswordElement).SendKeys(confirmPassword);
            _state.Wait.WaitUntilElementToBeClickable(_savePasswordButtonElement).Click();
        }

        public void CancelEditPassword(string currentPassword, string newPassword, string confirmPassword)
        {
            _state.Wait.WaitUntilElementToBeClickable(_passwordTextBoxElement).Click();
            _state.Wait.WaitUntilElementToBeClickable(_currentPasswordElement).SendKeys(currentPassword);
            _state.Wait.WaitUntilElementToBeClickable(_newPasswordElement).SendKeys(newPassword);
            _state.Wait.WaitUntilElementToBeClickable(_confirmPasswordElement).SendKeys(confirmPassword);
            _state.Wait.WaitUntilElementToBeClickable(_cancelPasswordButtonElement).Click();
        }

        public void ClickNotificationTab()
        {
            ClickWelcomeMessageLink();
            ClickAccountSettingsLink();
            _state.Wait.WaitUntilElementToBeClickable(_notificationTabElement).Click();
        }

        public void DeactivateAccount()
        {
            ClickWelcomeMessageLink();
            ClickAccountSettingsLink();
            _state.Wait.WaitUntilElementToBeClickable(_deactiveTabElement).Click();
            _state.Wait.WaitUntilElementToBeClickable(_deactivateButtonElement).Click();
        }

        public void EditAccountName(string name)
        {
            ClickWelcomeMessageLink();
            ClickAccountSettingsLink();
            ClickAccountTab();
            EditName(name);
        }

        public string GetUsernameFromWelcomeMessage()
        {
            var welcomeMessage = _state.Wait.WaitUntilElementIsVisible(_welcomeMessageElement).Text;
            return welcomeMessage;
        }
        public string GetName()
        {
           var name= _state.Wait.WaitUntilElementIsVisible(_nameTextBoxElement).Text;
           return name;
        }
        
        public void CancelAccountNameEdit(string name)
        {
            ClickWelcomeMessageLink();
            ClickAccountSettingsLink();
            ClickAccountTab();
            CancelEditName(name);
        }

        public string GetNameAfterCancel()
        {

            var name = _state.Wait.WaitUntilElementIsVisible(_nameTextBoxElement).GetAttribute("value");
            return name;
        }

        public void EditAccountPassword(string currentPassword, string newPassword, string confirmPassword)
        {
            ClickWelcomeMessageLink();
            ClickAccountSettingsLink();
            ClickAccountTab();
            EditPassword( currentPassword,  newPassword,  confirmPassword);
        }

        public void CancelAccountPasswordEdit(string currentPassword, string newPassword, string confirmPassword)
        {
            ClickWelcomeMessageLink();
            ClickAccountSettingsLink();
            ClickAccountTab();
            CancelEditPassword(currentPassword, newPassword, confirmPassword);
        }

        public string GetPasswordText()
        {
            var password = _state.Wait.WaitUntilElementIsVisible(_passwordTextBoxElement).GetAttribute("value");
            return password;
        }
        public string GetSuccessMessage()
        {
            var successMessage = _state.Wait.WaitUntilElementIsVisible(_successMessage).Text;
            return successMessage;
        }

        public string GetNotificationText()
        {
            var notificationText = _state.Wait.WaitUntilElementIsVisible(_notificationTextElement).Text;
            return notificationText;
        }
    }
}
