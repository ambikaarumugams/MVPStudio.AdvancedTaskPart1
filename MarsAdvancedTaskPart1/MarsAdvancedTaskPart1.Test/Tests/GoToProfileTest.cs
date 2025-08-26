using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components;
using MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class GoToProfileTest:TestBase.TestBase
    {
        private  GoToProfileComponent? _goToProfile;

       [Test]
        public void GoToProfilePage()
        {
            State.Test.Log(Status.Info, "Starting GoToProfile test");
            _goToProfile = new GoToProfileComponent(State);
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent .SignIn(State.LoginData.Username,State.LoginData.Password);
            _goToProfile.ClickWelcomeMessageLink();
            State.Test.Log(Status.Info, "Click GoToProfile link");
            _goToProfile.ClickGoToProfileLink();
            var actual= _goToProfile.GetProfileTitle();
            State.Assert.IsNotNullOrEmpty(actual,$"Actual message isn't null or empty");
        }
    }
}
