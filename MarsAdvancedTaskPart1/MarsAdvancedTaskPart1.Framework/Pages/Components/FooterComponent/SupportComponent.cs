using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.FooterComponent
{
    public class SupportComponent
    {

        private readonly TestState _state;

        public SupportComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _profileTab = By.XPath("//a[normalize-space()='Profile']");
        private readonly By _supportTab = By.XPath("//h3[normalize-space()='Support']");
        private readonly By _contactAndSupportLink = By.XPath("//a[normalize-space()='Contact Support']");
        private readonly By _helpAndEducationLink = By.XPath("//a[normalize-space()='Help & Education']");
        private readonly By _trustAndSafetyLink = By.XPath("//a[normalize-space()='Trust & Safety']");
        private readonly By _sellingOnMarsLink = By.XPath("//a[normalize-space()='Selling on Mars']");
        private readonly By _buyingOnMarsLink = By.XPath("//a[normalize-space()='Buying on Mars']");

        //Action Methods
        public void NavigateToTheProfilePage()    //Navigate to the profile page
        {
            var profileElement = _state.Wait.WaitUntilElementToBeClickable(_profileTab);
            profileElement.Click();
        }

        public void ClickSupportTab()
        {
            var supportTabElement = _state.Wait.WaitUntilElementToBeClickable(_supportTab);
            supportTabElement.Click();
        }

        public void ClickContactAndSupportLink()
        {
            var contactAndSupportLinkElement = _state.Wait.WaitUntilElementToBeClickable(_contactAndSupportLink);
            contactAndSupportLinkElement.Click();
        }

        public void ClickHelpAndEducationLink()
        {
            var helpAndEducationLinkElement = _state.Wait.WaitUntilElementToBeClickable(_helpAndEducationLink);
            helpAndEducationLinkElement.Click();
        }

        public void ClickTrustAndSafetyLink()
        {
            var trustAndSafetyLinkElement = _state.Wait.WaitUntilElementToBeClickable(_trustAndSafetyLink);
            trustAndSafetyLinkElement.Click();
        }

        public void ClickSellingOnMarsLink()
        {
            var sellingOnMarsLinkElement = _state.Wait.WaitUntilElementToBeClickable(_sellingOnMarsLink);
            sellingOnMarsLinkElement.Click();
        }

        public void ClickBuyingOnMarsLink()
        {
            var buyingOnMarsLinkElement = _state.Wait.WaitUntilElementToBeClickable(_buyingOnMarsLink);
            buyingOnMarsLinkElement.Click();
        }

    }
}
