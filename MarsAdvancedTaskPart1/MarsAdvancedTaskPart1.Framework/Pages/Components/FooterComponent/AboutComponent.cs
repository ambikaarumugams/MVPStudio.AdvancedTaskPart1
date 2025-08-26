using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.FooterComponent
{
    public class AboutComponent
    {
        private readonly TestState _state;

        public AboutComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _profileTab = By.XPath("//a[normalize-space()='Profile']");
        private readonly By _aboutTab = By.XPath("//h3[normalize-space()='About']");
        private readonly By _careersLink = By.XPath("//a[normalize-space()='Careers']");
        private readonly By _pressAndNewsLink = By.XPath("//a[normalize-space()='Press & News']");
        private readonly By _partnershipsLink = By.XPath("//a[normalize-space()='Partnerships']");
        private readonly By _privacyAndPolicyLink = By.XPath("//a[normalize-space()='Privacy Policy']");
        private readonly By _termsAndServiceLink = By.XPath("//a[normalize-space()='Terms of Service']");

        //Action Methods
        public void NavigateToTheProfilePage()    //Navigate to the profile page
        {
            var profileElement = _state.Wait.WaitUntilElementToBeClickable(_profileTab);
            profileElement.Click();
        }

        public void ClickAboutTab()
        {
            var aboutTabElement = _state.Wait.WaitUntilElementToBeClickable(_aboutTab);
            aboutTabElement.Click();
        }

        public void ClickCareersLink()
        {
            var careersLinkElement = _state.Wait.WaitUntilElementToBeClickable(_careersLink);
            careersLinkElement.Click();
        }

        public void ClickPressAndNewsLink()
        {
            var pressAndNewsLinkElement = _state.Wait.WaitUntilElementToBeClickable(_pressAndNewsLink);
            pressAndNewsLinkElement.Click();
        }

        public void ClickPartnershipsLink()
        {
            var partnershipsLinkElement = _state.Wait.WaitUntilElementToBeClickable(_partnershipsLink);
            partnershipsLinkElement.Click();
        }

        public void ClickPrivacyAndPolicyLink()
        {
            var privacyAndPolicyLinkElement = _state.Wait.WaitUntilElementToBeClickable(_privacyAndPolicyLink);
            privacyAndPolicyLinkElement.Click();
        }

        public void ClickTermsAndServiceLink()
        {
            var termsAndServicesLinkElement = _state.Wait.WaitUntilElementToBeClickable(_termsAndServiceLink);
            termsAndServicesLinkElement.Click();
        }

    }
}
