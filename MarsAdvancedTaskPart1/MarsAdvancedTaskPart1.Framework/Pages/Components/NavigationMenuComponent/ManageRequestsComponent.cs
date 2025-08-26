using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent
{
    public class ManageRequestsComponent
    {
        private readonly TestState _state;

        public ManageRequestsComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _manageRequestsTab = By.XPath("//div[@class='ui dropdown link item']");
        private readonly By _receivedRequestsLink = By.XPath("//a[normalize-space()='Received Requests']");
        private readonly By _sendRequestsLink = By.XPath("//a[normalize-space()='Sent Requests']");

        //Action Methods
        public void ClickManageRequestsTab()
        {
            var manageRequestsElement = _state.Wait.WaitUntilElementToBeClickable(_manageRequestsTab);
            manageRequestsElement.Click();
        }

        public void ClickReceiveRequestsLink()
        {
            var receiveRequestsElement = _state.Wait.WaitUntilElementToBeClickable(_receivedRequestsLink);
            receiveRequestsElement.Click();
        }

        public void ClickSendRequestsLink()
        {
            var sendRequestsElement = _state.Wait.WaitUntilElementToBeClickable(_sendRequestsLink);
            sendRequestsElement.Click();
        }

        public string GetAttributeOfReceiveRequestsLink()
        {
            var receiveRequestsElement = _state.Wait.WaitUntilElementToBeClickable(_receivedRequestsLink);
            var hrefValue = receiveRequestsElement.GetAttribute("href");
            return hrefValue;
        }

        public string GetAttributeOfSendRequestsLink()
        {
            var sendRequestsElement = _state.Wait.WaitUntilElementToBeClickable(_sendRequestsLink);
            var hrefValue = sendRequestsElement.GetAttribute("href");
            return hrefValue;
        }
    }
}
