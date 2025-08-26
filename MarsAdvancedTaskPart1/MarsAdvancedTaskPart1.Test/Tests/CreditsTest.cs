using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components;
using MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class CreditsTest:TestBase.TestBase
    {
        private CreditsComponent? _credits;
       
        [Test]
        public void Credits()
        {
            State.Test.Log(Status.Info, "Starting Credits Test");
            _credits = new CreditsComponent(State);
            State.Test.Log(Status.Info, "Enter Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username,State.LoginData.Password);
            _credits.ClickWelcomeMessage();
            State.Test.Log(Status.Info, "Click the Credits Link");
            _credits.ClickCreditLink();
            Console.WriteLine("It remains on the profile page");
        }
    }
}
