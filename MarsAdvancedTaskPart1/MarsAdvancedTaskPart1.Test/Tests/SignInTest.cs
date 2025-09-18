using AventStack.ExtentReports;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class SignInTest : TestBase.TestBase
    {
        [Test]
        public void SignIn()
        {
            State.Test.Log(Status.Info, "Starting SignIn Test");
            State.Test.Log(Status.Info, "Enter Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            State.Test.Log(Status.Info, "Welcome message displayed");
            var actualMessage = State.SignInComponent.GetWelcomeMessage();
            State.Assert.IsEqualTo(State.LoginData.ExpectedMessage, actualMessage, $"Actual and expected are equal");
        }
    }
}
