using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent.ProfileComponent.ProfileOverviewComponent
{
    public class ProfileOverviewComponent
    {
        private readonly TestState _state;
        public ProfileOverviewComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _profileTab = By.XPath("//a[normalize-space()='Profile']");
        private readonly By _profileImage = By.XPath("//img[@alt='....Loading']");
        private readonly By _fullName = By.XPath("//div[@class='title']");
        private readonly By _userNameDropDownIcon = By.XPath("//div[@class='header']//div[@class='title']//i[@class='dropdown icon']");
        private readonly By _firstNameField = By.XPath("//input[@name='firstName']");
        private readonly By _lastNameField = By.XPath("//input[@name='lastName']");
        private readonly By _saveButton = By.XPath("//button[normalize-space()='Save']");
        private readonly By _availabilityEditIcon = By.XPath("//div[@class='right floated content']//i[@class='right floated outline small write icon'][1]");
        private readonly By _availabilityDropdown = By.XPath("//select[@name='availabiltyType']");
        private readonly By _cancelAvailabilitySelectIcon = By.XPath("//div[@class='right floated content']//i[contains(@class,'remove icon')]");
        private readonly By _hoursEditIcon = By.XPath("//strong[normalize-space()='Hours']/following::i[contains(@class,'write icon')][1]");
        private readonly By _hoursDropDown = By.XPath("//select[@name='availabiltyHour']");
        private readonly By _hoursCancelIcon = By.XPath("//select[@name='availabilityHour']/following-sibling::i[contains(@class,'remove icon')]");
        private readonly By _earnTargetDropDown = By.XPath("//select[@name='availabiltyTarget']");
        private readonly By _earnTargetEditIcon = By.XPath("//strong[normalize-space()='Earn Target']/following::i[contains(@class,'write icon')][1]");
        private readonly By _earnTargetCancelIcon = By.XPath("//select[@name='availabiltyTarget']/following-sibling::i[contains(@class,'remove icon')]");
        private readonly By _successMessage = By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']");
        private readonly By _errorMessage =
           By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']");

        //Action Methods
        public void NavigateToTheProfilePage()    //Navigate to the profile page
        {
            //Profile 
            var profileElement = _state.Wait.WaitUntilElementToBeClickable(_profileTab);
            profileElement.Click();
        }

        public void ClickUserNameArrow()
        {
            var userNameDropDownElement = _state.Wait.WaitUntilElementToBeClickable(_userNameDropDownIcon);
            userNameDropDownElement.Click();
        }

        public void SaveUserName(string firstName, string lastName)
        {
            var firstNameElement = _state.Wait.WaitUntilElementIsVisible(_firstNameField);
            firstNameElement.Clear();
            firstNameElement.SendKeys(firstName);
            var lastNameElement = _state.Wait.WaitUntilElementIsVisible(_lastNameField);
            lastNameElement.Clear();
            lastNameElement.SendKeys(lastName);
            var saveButtonElement = _state.Wait.WaitUntilElementToBeClickable(_saveButton);
            saveButtonElement.Click();
        }

        public string GetFullName()
        {
            try
            {
                var fullNameElement = _state.Wait.WaitUntilElementIsVisible(_fullName);
                return fullNameElement.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void LeaveEitherOneOrAllTheFieldsAreEmptyForUserNameUpdate(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                var firstNameElement = _state.Wait.WaitUntilElementIsVisible(_firstNameField);
                firstNameElement.Clear();
                if (firstName.Equals("<Empty>", StringComparison.OrdinalIgnoreCase))    //Condition for empty space
                {
                    firstName = "    ";
                }
                firstNameElement.SendKeys(firstName);
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                var lastNameElement = _state.Wait.WaitUntilElementIsVisible(_lastNameField);
                lastNameElement.Clear();
                if (lastName.Equals("<Empty>", StringComparison.OrdinalIgnoreCase))    //Condition for empty space
                {
                    lastName = "    ";
                }
                lastNameElement.SendKeys(lastName);
            }

            var saveButtonElement = _state.Wait.WaitUntilElementToBeClickable(_saveButton);
            saveButtonElement.Click();
        }


        public void SelectAvailabilityOption(string availability)
        {
            var availabilityEditIconElement = _state.Wait.WaitUntilElementToBeClickable(_availabilityEditIcon);
            availabilityEditIconElement.Click();

            var selectAvailabilityTypeDropDown = _state.Wait.WaitUntilElementToBeClickable(_availabilityDropdown);

            SelectElement selectElement = new SelectElement(selectAvailabilityTypeDropDown);
            selectElement.SelectByText(availability);
        }

        public void CancelSelectAvailabilityOption()
        {
            var availabilityEditIconElement = _state.Wait.WaitUntilElementToBeClickable(_availabilityEditIcon);
            availabilityEditIconElement.Click();

            var cancelSelectAvailability = _state.Wait.WaitUntilElementToBeClickable(_cancelAvailabilitySelectIcon);
            cancelSelectAvailability.Click();
        }

        public string GetAvailability()
        {
            try
            {
                var availabilityEditIconElement = _state.Wait.WaitUntilElementToBeClickable(_availabilityEditIcon);
                availabilityEditIconElement.Click();

                var getAvailabilityElement = _state.Wait.WaitUntilElementIsVisible(_availabilityDropdown);
                return getAvailabilityElement.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void SelectHoursOption(string hours)
        {
            var hoursEditIconElement = _state.Wait.WaitUntilElementToBeClickable(_hoursEditIcon);
            hoursEditIconElement.Click();

            var selectHoursDropDown = _state.Wait.WaitUntilElementToBeClickable(_hoursDropDown);
            selectHoursDropDown.Click();
            Thread.Sleep(3000);

            SelectElement selectElement = new SelectElement(selectHoursDropDown);
            selectElement.SelectByText(hours);
        }

        public void CancelSelectHoursOption()
        {
            var hoursEditIconElement = _state.Wait.WaitUntilElementToBeClickable(_hoursEditIcon);
            hoursEditIconElement.Click();

            var cancelHoursSelectElement = _state.Wait.WaitUntilElementToBeClickable(_hoursCancelIcon);
            cancelHoursSelectElement.Click();
        }

        public string GetHours()
        {
            try
            {
                var hoursEditIconElement = _state.Wait.WaitUntilElementToBeClickable(_hoursEditIcon);
                hoursEditIconElement.Click();
                var getHoursElement = _state.Wait.WaitUntilElementIsVisible(_hoursDropDown);
                return getHoursElement.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void SelectTargetOption(string target)
        {
            var targetEditIconElement = _state.Wait.WaitUntilElementToBeClickable(_earnTargetEditIcon);
            targetEditIconElement.Click();

            var selectEarnTargetDropDownElement = _state.Wait.WaitUntilElementToBeClickable(_earnTargetDropDown);

            SelectElement selectElement = new SelectElement(selectEarnTargetDropDownElement);
            selectElement.SelectByText(target);
        }

        public void CancelSelectTargetOption()
        {
            var targetEditIconElement = _state.Wait.WaitUntilElementToBeClickable(_earnTargetEditIcon);
            targetEditIconElement.Click();

            var cancelTargetElement = _state.Wait.WaitUntilElementToBeClickable(_earnTargetCancelIcon);
            cancelTargetElement.Click();
        }

        public string GetEarnTarget()
        {
            try
            {
                var targetEditIconElement = _state.Wait.WaitUntilElementToBeClickable(_earnTargetEditIcon);
                targetEditIconElement.Click();
                var getEarnTargetElement = _state.Wait.WaitUntilElementIsVisible(_earnTargetDropDown);
                return getEarnTargetElement.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string GetSuccessMessage()
        {
            try
            {
                var successMessageElement = _state.Wait.WaitUntilElementIsVisible(_successMessage);
                return successMessageElement.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string GetErrorMessage()
        {
            try
            {
                var errorMessageElement = _state.Wait.WaitUntilElementIsVisible(_errorMessage);
                return errorMessageElement.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void ExpireSession() //To delete the token to get the session timeout message
        {
            try
            {
                _state.Driver.Manage().Cookies.DeleteCookieNamed("marsAuthToken");
            }
            catch
            {
            }
        }
    }
}
