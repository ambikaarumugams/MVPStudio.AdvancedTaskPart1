using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent
{
    public class ChatComponent
    {
        private readonly TestState _state;

        public ChatComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _chatLinkElement = By.XPath("//a[normalize-space()='Chat']");
        private readonly By _chatContentElement = By.XPath("//div[@class='content']");
        
        //Action Method
        public string GetChatContent()
        {
            _state.Wait.WaitUntilElementToBeClickable(_chatLinkElement).Click();
            var chatContent=_state.Wait.WaitUntilElementIsVisible(_chatContentElement).Text;
            return chatContent;
        }
    }
}
