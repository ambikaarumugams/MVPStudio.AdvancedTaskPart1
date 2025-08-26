using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent
{
    public class ManageListingsComponent
    {
        private readonly TestState _state;

        public ManageListingsComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _manageListingsTab = By.XPath("//a[normalize-space()='Manage Listings']");

        //Action Methods
        public void ClickManageListingsTab()
        {
            var manageListingsElement =_state.Wait.WaitUntilElementToBeClickable(_manageListingsTab);
            manageListingsElement.Click();
        }

        public string GetAttributeOfManageListings()
        {
            var manageListingsElement = _state.Wait.WaitUntilElementToBeClickable(_manageListingsTab);
            var hrefValue=manageListingsElement.GetAttribute("href");
            return hrefValue;
        }
    }
}
