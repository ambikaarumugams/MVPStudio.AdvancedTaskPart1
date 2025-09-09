using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    public class ManageRequestsTest:TestBase.TestBase
    {

        private ManageRequestsComponent _manageRequestsComponent;

        [Test]
        public void SelectReceiveRequestsRequests()
        {
            var actualMessages=new List<string>();
            var expectedMessages=new List<string>();
            State.Test.Log(Status.Info, "Starting About footer test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _manageRequestsComponent = new ManageRequestsComponent(State);

            _manageRequestsComponent.ClickManageRequestsTab();
            _manageRequestsComponent.ClickReceiveRequestsLink();
            var currentUrl = State.Driver.Url;
            expectedMessages.Add(currentUrl);
            var receiveRequestHrefValue= _manageRequestsComponent.GetAttributeOfReceiveRequestsLink();
            actualMessages.Add(receiveRequestHrefValue);
            var textOfReceivedRequest=_manageRequestsComponent.GetTextReceivedRequest();
            Console.WriteLine($"Received request page message:{textOfReceivedRequest}");
            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }

        [Test]
        public void SelectSendRequestsRequests()
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string>();
            State.Test.Log(Status.Info, "Starting About footer test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _manageRequestsComponent = new ManageRequestsComponent(State);

            _manageRequestsComponent.ClickManageRequestsTab();
            _manageRequestsComponent.ClickSendRequestsLink();
            var currentUrl = State.Driver.Url;
            expectedMessages.Add(currentUrl);
            var sendRequestHrefValue = _manageRequestsComponent.GetAttributeOfSendRequestsLink();
            actualMessages.Add(sendRequestHrefValue);

            var textOfSentRequest = _manageRequestsComponent.GetTextSentRequest();
            Console.WriteLine($"Sent request page message:{textOfSentRequest}");

            State.Assert.ListsMatch(actualMessages, expectedMessages);
        }
    }
}
