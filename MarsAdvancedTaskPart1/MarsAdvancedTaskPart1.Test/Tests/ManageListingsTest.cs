using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    public class ManageListingsTest:TestBase.TestBase
    {
        private ManageListingsComponent _manageListingsComponent;

        [Test]
        public void SelectManageListings()
        {
            State.Test.Log(Status.Info, "Starting About footer test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _manageListingsComponent = new ManageListingsComponent(State);

            _manageListingsComponent.ClickManageListingsTab();
            var currentUrl = State.Driver.Url;
            var expected = _manageListingsComponent.GetAttributeOfManageListings();
            State.Assert.IsEqualTo(currentUrl, expected, $"Actual{currentUrl} and {expected} aren't equal");
        }
    }
}
