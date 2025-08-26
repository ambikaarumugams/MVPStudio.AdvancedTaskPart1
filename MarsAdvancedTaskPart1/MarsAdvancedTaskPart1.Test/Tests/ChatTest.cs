using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class ChatTest : TestBase.TestBase
    {
        private ChatComponent? _chat;

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ChatData))]
        public void Chat(ChatModel chat)
        {
            State.Test.Log(Status.Info, "Starting AccountTestings Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _chat = new ChatComponent(State);
            State.Test.Log(Status.Info, "Get the content from the chat");
            var actual = _chat.GetChatContent();
            State.Assert.Contains(actual, chat.ExpectedMessageForChat, "Expected and Actual are Equal");
        }
    }
}
