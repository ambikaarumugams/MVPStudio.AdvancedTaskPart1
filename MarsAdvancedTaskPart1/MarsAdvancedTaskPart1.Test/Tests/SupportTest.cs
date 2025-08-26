using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components.FooterComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class SupportTest : TestBase.TestBase
    {
        private SupportComponent? _supportComponent;
        [Test]
        public void SelectSupportFooterTab()
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string>();
            State.Test.Log(Status.Info, "Starting About footer test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _supportComponent = new SupportComponent(State);
            _supportComponent.NavigateToTheProfilePage();

            var supportLinks = new Dictionary<Action, string>
            {
                { ()=> _supportComponent.ClickContactAndSupportLink(),"Contact Support"},
                { ()=>_supportComponent.ClickHelpAndEducationLink(),"Help & Education"},
                { ()=>_supportComponent.ClickTrustAndSafetyLink(),"Trust & Safety"},
                { ()=> _supportComponent.ClickSellingOnMarsLink(),"Selling on Mars"},
                { ()=>_supportComponent.ClickBuyingOnMarsLink(),"Buying on Mars"}
            };

            foreach (var supportLink in supportLinks)
            {
                supportLink.Key.Invoke();
                State.Test.Log(Status.Info, $"Clicked on {supportLink.Value} link. It shows loading....");
                string actualUrl = State.Driver.Url; // get current URL
                actualMessages.Add(actualUrl);
                expectedMessages.Add(supportLink.Value);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }
    }
}
