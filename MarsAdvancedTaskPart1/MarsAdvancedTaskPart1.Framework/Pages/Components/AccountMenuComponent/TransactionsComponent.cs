using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.AccountMenuComponent
{
    public class TransactionsComponent
    {
        private readonly TestState _state;
       
        public TransactionsComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _welcomeMessageElement = By.XPath("//span[contains(@class, 'dropdown') and contains(normalize-space(), 'Ambika')]");
        private readonly By _transactionsElement = By.XPath("//a[normalize-space()='Transaction']");
        private readonly By _transactionsTableElement = By.XPath("//table[@class='ui single line table']//thead//tr");
        private readonly By _currentBalanceValueElement = By.XPath("//div[@class='value']");
        private readonly By _currentBalanceLabelElement = By.XPath("//div[@class='label']");
        
        //Action Methods
        public void ClickWelcomeMessageLink()
        {
            _state.Wait.WaitUntilElementToBeClickable(_welcomeMessageElement).Click();
        }

        public void ClickTransactionElement()
        {
            _state.Wait.WaitUntilElementToBeClickable(_transactionsElement).Click();
        }

        public string GetTableData()
        {
            var tableData=_state.Wait.WaitUntilElementIsVisible(_transactionsTableElement).Text;
            return tableData;
        }

        public string GetCurrentBalanceValue()
        {
            var currentBalance = _state.Wait.WaitUntilElementIsVisible(_currentBalanceValueElement).Text;
            return currentBalance;
        }

        public string GetCurrentBalanceLabel()
        {
            var getCurrentBalanceLabel = _state.Wait.WaitUntilElementIsVisible(_currentBalanceLabelElement).Text;
            return getCurrentBalanceLabel;
        }
    }
}
