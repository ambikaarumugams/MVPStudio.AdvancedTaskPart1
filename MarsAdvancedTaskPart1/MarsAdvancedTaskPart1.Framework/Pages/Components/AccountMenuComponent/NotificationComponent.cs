using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent
{
    public class NotificationComponent
    {
        private readonly TestState _state;

        public NotificationComponent(TestState state)
        {
            _state=state;
        }
        //Locators
        private readonly By _notificationTabElement =
            By.XPath("//div[@class='ui top left pointing dropdown item active visible']");
        private readonly By _notificationDropdownElement=By.XPath("//i[@class='dropdown icon']");

        //Action Methods
        public void ClickNotificationsTab()
        {
            _state.Wait.WaitUntilElementToBeClickable(_notificationTabElement).Click();
        }

        public string GetNotificationMessage()
        { 
            var notificationMessage = _state.Wait.WaitUntilElementIsVisible(_notificationDropdownElement).Text;
            return notificationMessage;
        }
    }
}
