using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class NotificationTest:TestBase.TestBase
    {
        private NotificationComponent? _notification;

        [Test]
        public void Notification()
        {
            State.Test.Log(Status.Info, "Starting AccountSettings Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _notification = new NotificationComponent(State);
            State.Test.Log(Status.Info, "Click the notification and get the message");
          
           
            var actual =_notification.GetNotificationMessage();
            Console.WriteLine(actual);
        }
    }
}
