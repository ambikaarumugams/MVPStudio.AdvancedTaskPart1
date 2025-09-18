using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent
{
    public class DashboardComponent
    {
        private readonly TestState _state;

        public DashboardComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _dashboardTab = By.XPath("//a[normalize-space()='Dashboard']");

        //Action Methods
        public void ClickDashboardTab()
        {
            var dashboardTabElement=_state.Wait.WaitUntilElementToBeClickable(_dashboardTab);
            dashboardTabElement.Click();
        }

        public string GetAttributeOfDashboard()
        {

            var dashboardTabElement = _state.Wait.WaitUntilElementToBeClickable(_dashboardTab);
            var hrefValue=dashboardTabElement.GetAttribute("href");
            return hrefValue;
        }
       
    }
}
