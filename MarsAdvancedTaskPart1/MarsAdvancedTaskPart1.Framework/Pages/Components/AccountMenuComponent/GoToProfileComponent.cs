using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Browser;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent
{
    public class GoToProfileComponent
    {
        private readonly TestState _state;
        
        public GoToProfileComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _welcomeMessageElement = By.XPath("//span[contains(@class, 'dropdown') and contains(normalize-space(), 'Ambika')]");
        private readonly By _goToProfileElement = By.XPath("//a[normalize-space()='Go to Profile']");
        private readonly By _profileTitleElement = By.XPath("//div[@class='title']");

        //Action Methods
        public void ClickWelcomeMessageLink()
        {
            _state.Wait.WaitUntilElementToBeClickable(_welcomeMessageElement).Click();
        }

        public void ClickGoToProfileLink()
        {
            _state.Wait.WaitUntilElementIsVisible(_goToProfileElement).Click();
        }

        public string GetProfileTitle()
        {
            var profileTitle=  _state.Wait.WaitUntilElementIsVisible(_profileTitleElement).Text;
            return profileTitle;
        }
    }
}
