using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;
using System.Globalization;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components
{
    public class ShareSkillComponent
    {
        private readonly TestState _state;

        public ShareSkillComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _profileTab = By.XPath("//a[normalize-space()='Profile']");
        private readonly By _shareSkillTab = By.XPath("//a[normalize-space()='Share Skill']");
        private readonly By _tagsInputBox = By.XPath("//div[@class='ReactTags__tagInput']/input[contains(@aria-label,'Add new tag')]");
        //private readonly By _serviceTypeRadioButton1 = By.XPath("//div[@class='ui radio checkbox']//input[@name='serviceType' and @value='0']");
        //private readonly By _serviceTypeRadioButton2 = By.XPath("//div[@class='ui radio checkbox']//input[@name='serviceType' and @value='1']");
        //private readonly By _locationTypeRadioButton1 = By.XPath("//div[@class='ui radio checkbox']//input[@name='locationType' and @value='0']");
        //private readonly By _locationTypeRadioButton2 = By.XPath("//div[@class='ui radio checkbox']//input[@name='locationType' and @value='1']");
        private readonly By _calendar = By.XPath("//span[@class='k-icon k-i-calendar']");


        //a[@class='k-link k-nav-prev']
        //a[@class='k-link k-nav-next']
        private readonly By _workWeekTab = By.XPath("//li[contains(@class,'k-current-view')]//a[contains(@role,'button')][normalize-space()='Work Week']");
        private readonly By _dayLink = By.XPath("//a[normalize-space()='Day']");
        private readonly By _workWeekLink = By.XPath("//li[contains(@class,'k-state-default k-view-workweek k-state-selected')]//a[contains(@role,'button')][normalize-space()='Work Week']");
        private readonly By _weekLink = By.XPath("//a[normalize-space()='Week']");
        private readonly By _monthLink = By.XPath("//a[normalize-space()='Month']");
        private readonly By _agendaLink = By.XPath("//a[normalize-space()='Agenda']");
        private readonly By _timeLineLink = By.XPath("//a[normalize-space()='Timeline']");
        private readonly By _showBusinessHoursTab = By.XPath("//a[normalize-space()='Show business hours']");
        private readonly By _skillTradeRadioButton1 = By.XPath("//input[@name='skillTrades' and @value='true']/following-sibling::label");
        private readonly By _skillTradeRadioButton2 = By.XPath("//input[@name='skillTrades' and @value='false']/following-sibling::label");
        private readonly By _skillExchangeTagInputBox = By.XPath("//div[contains(@class,'twelve wide column')]//div[contains(@class,'')]//div[contains(@class,'form-wrapper')]//input[contains(@placeholder,'Add new tag')]");
        private readonly By _creditTextBox = By.XPath("//input[@placeholder='Amount']");
        private readonly By _workSamplesIcon = By.XPath("//i[@class='huge plus circle icon padding-25']");
        private readonly By _activeRadioButton1 = By.XPath("//input[@name='isActive' and @value='true']/following-sibling::label");
        private readonly By _activeRadioButton2 = By.XPath("//input[@name='isActive' and @value='false']/following-sibling::label");

        private readonly By _saveButton = By.XPath("//input[@value='Save']");
        private readonly By _cancelButton = By.XPath("//input[@value='Cancel']");

        //Action Methods
        public void NavigateToTheProfilePage()
        {
            var profileElement = _state.Wait.WaitUntilElementToBeClickable(_profileTab);
            profileElement.Click();
        }

        public void ClickShareSkill()
        {
            var shareSkillElement = _state.Wait.WaitUntilElementToBeClickable(_shareSkillTab);
            shareSkillElement.Click();
        }
        public void AddTag(string tag)
        {
            var tagsInputBox = _state.Wait.WaitUntilElementToBeClickable(_tagsInputBox);
            tagsInputBox.SendKeys(tag + Keys.Enter);
        }

        public void ServiceType(string value)
        {
            var serviceType = _state.Wait.WaitUntilElementToBeClickable(By.XPath($"//input[@name='serviceType' and @value='{value}']/following-sibling::label"));
            serviceType.Click();
        }
     
         
        public void LocationType(string value)
        {
            var LocationType = _state.Wait.WaitUntilElementToBeClickable(By.XPath($"//input[@name='locationType' and @value='{value}']/following-sibling::label"));
            LocationType.Click();
        }
       

        public void SetStartDate(string MmDdyyyy)
        {
            var startDateElement = _state.Wait.WaitUntilElementIsVisible(_calendar);
            startDateElement.Click();
            startDateElement.SendKeys(MmDdyyyy);
        }

        public void SelectDate(string dateString)
        {
            var target = DateTime.Parse(dateString); //

            // open calendar input first
            var currentMonthYear = _state.Wait.WaitUntilElementIsVisible(_calendar);

            while (true)
            {
                string headerText = currentMonthYear.Text; 

                DateTime current = DateTime.ParseExact(headerText, "MMMM yyyy", CultureInfo.InvariantCulture);

                if (current.Year == target.Year && current.Month == target.Month)
                    break;

                if (current > target)
                {
                    _state.Driver.FindElement(By.XPath("//a[contains(@class,'k-nav-prev')]")).Click();
                }
                else
                {
                    _state.Driver.FindElement(By.XPath("//a[contains(@class,'k-nav-next')]")).Click();
                }

                currentMonthYear = _state.Wait.WaitUntilElementIsVisible(By.XPath("//a[contains(@class,'k-nav-fast')]"));
            }

            // Click the day

            var dayCell = _state.Wait.WaitUntilElementIsVisible(By.XPath($"//table[contains(@class,'k-month')]//td[normalize-space(text())='{target.Day}']"));
            dayCell.Click();
        }

        public void ChooseSkillExchange()
        {
            _state.Wait.WaitUntilElementToBeClickable(_skillTradeRadioButton1).Click(); 
        }

        public void ChooseCredit()
        {
            _state.Wait.WaitUntilElementToBeClickable(_skillTradeRadioButton2).Click();
        }

        public void AddSkillExchangeTag(string tag)
        {
            var skillExchangeTextBox=_state.Wait.WaitUntilElementIsVisible(_skillExchangeTagInputBox);
            skillExchangeTextBox.SendKeys(tag + Keys.Enter);
        }

        public void SetCreditAmount(string amount)
        {
            var creditTextBoxElement = _state.Wait.WaitUntilElementIsVisible(_creditTextBox);
            creditTextBoxElement.Clear(); 
            creditTextBoxElement.SendKeys(amount);
        }

        public void UploadWorkSample(string filePath)
        {
            _state.Wait.WaitUntilElementIsVisible(_workSamplesIcon).SendKeys(filePath);
        }

        public void SetActiveYes()
        {
            _state.Wait.WaitUntilElementToBeClickable(_activeRadioButton1).Click();
        }

        public void SetActiveNo()
        {
            _state.Wait.WaitUntilElementToBeClickable(_activeRadioButton2).Click();
        }

        public void ClickSave()
        {
            _state.Wait.WaitUntilElementToBeClickable(_saveButton).Click();
        }

        public void ClickCancel()
        {
            _state.Wait.WaitUntilElementToBeClickable(_cancelButton).Click();
        }
    }
}
