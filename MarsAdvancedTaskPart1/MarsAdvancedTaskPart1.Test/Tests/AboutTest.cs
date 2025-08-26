using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components.FooterComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    public class AboutTest : TestBase.TestBase
    {
        private AboutComponent? _aboutComponent;

        [Test]
        public void SelectAboutFooterTab()
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string>();
            State.Test.Log(Status.Info, "Starting About footer test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _aboutComponent = new AboutComponent(State);
            _aboutComponent.NavigateToTheProfilePage();

            var aboutLinks = new Dictionary<Action, string>
            {
                { ()=> _aboutComponent.ClickAboutTab(),"About"},
                { ()=>_aboutComponent.ClickCareersLink(),"Careers"},
                { ()=>_aboutComponent.ClickPressAndNewsLink(),"Press & News"},
                { ()=> _aboutComponent.ClickPartnershipsLink(),"Partnerships"},
                { ()=>_aboutComponent.ClickPrivacyAndPolicyLink(),"Privacy & Policy"},
                { ()=>_aboutComponent.ClickTermsAndServiceLink(),"Terms & Service"}
            };

            foreach (var aboutLink in aboutLinks)
            {
                aboutLink.Key.Invoke();
                State.Test.Log(Status.Info, $"Clicked on {aboutLink.Value} link. It shows loading....");
                string actualUrl = State.Driver.Url; // get current URL
                actualMessages.Add(actualUrl);
                expectedMessages.Add(aboutLink.Value);
            }
            State.Assert.AssertListContainsAll(actualMessages, expectedMessages);
        }
    }
}

