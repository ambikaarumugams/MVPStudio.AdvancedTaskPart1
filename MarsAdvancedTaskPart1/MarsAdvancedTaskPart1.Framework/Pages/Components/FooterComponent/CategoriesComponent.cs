using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;
using System.Reflection.Metadata.Ecma335;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.FooterComponent
{
    public class CategoriesComponent
    {
        private readonly TestState _state;

        public CategoriesComponent(TestState state)
        {
            _state = state;
        }

        //Locators

        private readonly By _profileTab = By.XPath("//a[normalize-space()='Profile']");
        private readonly By _categoriesTab = By.XPath("//h3[normalize-space()='Categories']");
        private readonly By _graphicsAndDesignLink = By.XPath("//a[normalize-space()='Graphics Design']");
        private readonly By _digitalMarketingLink = By.XPath("//a[normalize-space()='Digital Marketing']");
        private readonly By _writingAndTranslationLink = By.XPath("//a[normalize-space()='Writing & Translation']");
        private readonly By _videoAndAnimationLink = By.XPath("//a[normalize-space()='Video & Animation']");
        private readonly By _musicAndAudioLink = By.XPath("//a[normalize-space()='Music Audio']");
        private readonly By _programmingTechLink = By.XPath("//a[normalize-space()='Programming Tech']");
        private readonly By _businessLink = By.XPath("//a[normalize-space()='Business']");
        private readonly By _funAndLifestyleLink = By.XPath("//a[normalize-space()='Fun & Lifestyle']");
        private readonly By _siteMapLink = By.XPath("//a[normalize-space()='Sitemap']");
        private readonly By _inlineLoader = By.XPath("//div[@class='ui active text centered inline loader']");

        //Action Methods
        public void NavigateToTheProfilePage()    //Navigate to the profile page
        {
            var profileElement = _state.Wait.WaitUntilElementToBeClickable(_profileTab);
            profileElement.Click();
        }

        public void ClickCategoriesTab()
        {
            var categoriesTabElement = _state.Wait.WaitUntilElementToBeClickable(_categoriesTab);
            categoriesTabElement.Click();
        }

        public void ClickGraphicsDesignLink()
        {
            var graphicsAndDesignLinkElement = _state.Wait.WaitUntilElementToBeClickable(_graphicsAndDesignLink);
            graphicsAndDesignLinkElement.Click();
        }

        public void ClickDigitalMarketingLink()
        {
            var digitalMarketingLinkElement = _state.Wait.WaitUntilElementToBeClickable(_digitalMarketingLink);
            digitalMarketingLinkElement.Click();
        }

        public void ClickWritingAndTranslationLink()
        {
            var writingAndTranslationLinkElement = _state.Wait.WaitUntilElementToBeClickable(_writingAndTranslationLink);
            writingAndTranslationLinkElement.Click();
        }

        public void ClickVideoAndAnimationLink()
        {
            var videoAndAnimationLinkElement = _state.Wait.WaitUntilElementToBeClickable(_videoAndAnimationLink);
            videoAndAnimationLinkElement.Click();
        }

        public void ClickMusicAndAudioLink()
        {
            var musicAndAudioLinkElement = _state.Wait.WaitUntilElementToBeClickable(_musicAndAudioLink);
            musicAndAudioLinkElement.Click();
        }

        public void ClickProgrammingTechLink()
        {
            var programmingTechLinkElement = _state.Wait.WaitUntilElementToBeClickable(_programmingTechLink);
            programmingTechLinkElement.Click();
        }

        public void ClickBusinessLink()
        {
            var businessLinkElement = _state.Wait.WaitUntilElementToBeClickable(_businessLink);
            businessLinkElement.Click();
        }

        public void ClickFunAndLifestyleLink()
        {
            var funAndLifestyleLinkElement = _state.Wait.WaitUntilElementToBeClickable(_funAndLifestyleLink);
            funAndLifestyleLinkElement.Click();
        }

        public void ClickSiteMapLink()
        {
            var siteMapLinkElement = _state.Wait.WaitUntilElementToBeClickable(_siteMapLink);
            siteMapLinkElement.Click();
        }

        public bool IsCategoriesVisible()
        {
            try
            {
                var inlineLoaderElement = _state.Wait.WaitUntilElementIsVisible(_inlineLoader);
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
