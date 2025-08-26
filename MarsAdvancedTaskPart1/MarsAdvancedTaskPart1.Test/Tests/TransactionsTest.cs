using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class TransactionsTest : TestBase.TestBase
    {
        private TransactionsComponent? _transactions;
        [Test]
        public void Transactions()
        {
            State.Test.Log(Status.Info, "Starting Transactions Test");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _transactions = new TransactionsComponent(State);
            _transactions.ClickWelcomeMessageLink();
            State.Test.Log(Status.Info, "Clicking the transactions link");
            _transactions.ClickTransactionElement();
            var actualMessage1 = _transactions.GetTableData();
            var actualMessage2 = _transactions.GetCurrentBalanceValue();
            var actualMessage3 = _transactions.GetCurrentBalanceLabel();
            Console.WriteLine(actualMessage1, actualMessage2, actualMessage3);
        }
    }
}
