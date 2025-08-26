using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent
{
    public class CreditsComponent
    {
        private readonly TestState _state;
       
        //Constructor
        public CreditsComponent(TestState state) 
        {
            _state = state;
        }

        //Locator
        private readonly By _welcomeMessageElement = By.XPath("//span[contains(@class, 'dropdown') and contains(normalize-space(), 'Ambika')]");
        private readonly By _creditsLinkElement = By.XPath("//a[normalize-space()='Credits : 100']");

        //Action Methods
        public void ClickWelcomeMessage()
        {
            _state.Wait.WaitUntilElementToBeClickable(_welcomeMessageElement).Click();
        }

        public void ClickCreditLink()
        {
            _state.Wait.WaitUntilElementIsVisible(_creditsLinkElement).Click();
        }
    }
}
