using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class DashBoardTest : TestBase.TestBase
    {
        private DashboardComponent? _dashboardComponent;

        [Test]
        public void SelectDashBoard()
        {
            State.Test.Log(Status.Info, "Starting About footer test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _dashboardComponent = new DashboardComponent(State);

            _dashboardComponent.ClickDashboardTab();
            var currentUrl = State.Driver.Url;
            var expected = _dashboardComponent.GetAttributeOfDashboard();
            State.Assert.IsEqualTo(currentUrl, expected, $"Actual{currentUrl} and {expected} aren't equal");
        }
    }
}
