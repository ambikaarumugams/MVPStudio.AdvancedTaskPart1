using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using MarsAdvancedTaskPart1.Framework.Helpers;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent.ProfileComponent.ProfileMenuTabComponent
{
    public class EducationComponent
    {
        private readonly TestState _state;

        //Constructor
        public EducationComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        //Add
        private readonly By _profileTab = By.XPath("//a[normalize-space()='Profile']");
        private readonly By _educationTab = By.XPath("//form[@class='ui form']//a[normalize-space()='Education']");
        private readonly By _addNewButton = By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//div[contains(@class,'ui teal button')][normalize-space()='Add New']");
        private readonly By _educationTable = By.XPath("//div[@data-tab='third']//table[@class='ui fixed table']");
        private readonly By _collegeUniversityNameField = By.XPath("//input[@placeholder='College/University Name']");
        private readonly By _countryDropDown = By.XPath("//select[@name='country']");
        private readonly By _titleDropDown = By.XPath("//select[@name='title']");
        private readonly By _degreeField = By.XPath("//input[@placeholder='Degree']");
        private readonly By _yearOfGraduationDropDown = By.XPath("//select[@name='yearOfGraduation']");
        private readonly By _addButton = By.XPath("//input[@value='Add']");
        private readonly By _cancelButton = By.XPath("//input[@value='Cancel']");

        //Edit
        private readonly By _collegeUniversityNameForUpdate = By.XPath(".//input[@placeholder='College/University Name']");
        private readonly By _countryDropDownForUpdate = By.XPath(".//select[@name='country']");
        private readonly By _titleDropDownForUpdate = By.XPath(".//select[@name='title']");
        private readonly By _degreeFieldForUpdate = By.XPath(".//input[@placeholder='Degree']");
        private readonly By _yearOfGraduationDropDownForUpdate = By.XPath(".//select[@name='yearOfGraduation']");
        private readonly By _updateButton = By.XPath(".//input[@value='Update']");
        private readonly By _cancelUpdateButton = By.XPath("//input[@value='Cancel']");
        private readonly By _signOut = By.XPath("//button[normalize-space()='Sign Out']");

        private readonly By _successMessage =
            By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']");

        private readonly By _errorMessage =
            By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']");

        //Action Methods
        public void NavigateToTheProfilePage()  //Navigate to the education page 
        {
            var profileElement = _state.Wait.WaitUntilElementToBeClickable(_profileTab);
            profileElement.Click();

            var educationElement = _state.Wait.WaitUntilElementToBeClickable(_educationTab);
            educationElement.Click();
        }

        public void ClickAddNewButton()
        {
            //Click "Add New" button
            var addNewElement = _state.Wait.WaitUntilElementToBeClickable(_addNewButton);
            addNewElement.Click();
        }

        public void AddEducationDetails(string? universityName, string countryName, string title, string degree, string year) //Add education details
        {
            ClickAddNewButton();
            //Enter College/University Name
            var enterCollegeUniversityName = _state.Wait.WaitUntilElementToBeClickable(_collegeUniversityNameField);
            enterCollegeUniversityName.SendKeys(universityName);

            //Select the country name using drop down
            var selectCountryDropDown = _state.Wait.WaitUntilElementToBeClickable(_countryDropDown);

            SelectElement selectCountry = new SelectElement(selectCountryDropDown);
            selectCountry.SelectByText(countryName);

            //Select the title using drop down
            var titleDropDown = _state.Wait.WaitUntilElementToBeClickable(_titleDropDown);

            SelectElement selectTitle = new SelectElement(titleDropDown);
            selectTitle.SelectByText(title);

            //Enter the degree
            var degreeElement = _state.Wait.WaitUntilElementToBeClickable(_degreeField);
            degreeElement.SendKeys(degree);

            //Select the year of graduation drop down
            var selectYearOfGraduationDropDown = _state.Wait.WaitUntilElementToBeClickable(_yearOfGraduationDropDown);

            SelectElement selectYear = new SelectElement(selectYearOfGraduationDropDown);
            selectYear.SelectByText(year);
            ClickAddButton();
        }

        public void ClickAddButton()
        {
            //Click "Add" button
            var addButton = _state.Wait.WaitUntilElementToBeClickable(_addButton);
            addButton.Click();
        }

        public string GetSuccessMessage() //Get success Message
        {
            try
            {
                Thread.Sleep(3000);
                var successMessage = _state.Wait.WaitUntilElementIsVisible(_successMessage);
                return successMessage.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void ClickSignOutButton()
        {
            _state.Wait.WaitUntilElementToBeClickable(_signOut).Click();
        }

        public void DeleteSpecificEducation(string? educationToBeDeleted)  //Delete specific education
        {
            var educationTable = _state.Wait.WaitUntilElementToBeClickable(_educationTable);
            var row = educationTable.FindElement(By.XPath($".//tr[td[2]='{educationToBeDeleted}']")); //University name is in the second column
            var deleteIcon = row.FindElement(By.XPath(".//i[contains(@class,'remove icon')]"));
            deleteIcon.Click();
        }

        public string GetErrorMessage()  //Get error message
        {
            try
            {
                var errorMessage = _state.Wait.WaitUntilElementIsVisible(_errorMessage);
                return errorMessage.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public (string MessageText, string MessageType) GetToastMessage()  //Tuples to get both success and error 
        {
            try
            {
                var wait = new WebDriverWait(_state.Driver, TimeSpan.FromSeconds(3));

                var toastMessageElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'ns-type-') and contains(@class,'ns-show')]")));
                Thread.Sleep(3000);
                var messageText = toastMessageElement.Text.Trim();
                var classAttribute = string.Empty;
                var messageType = string.Empty;

                classAttribute = toastMessageElement.GetAttribute("class");
                if (classAttribute != null)
                {
                    messageType = classAttribute.Contains("ns-type-success") ? "success" :
                                  classAttribute.Contains("ns-type-error") ? "error" : "none";
                }
                return (messageText, messageType);
            }
            catch
            {
                return ("", "error");
            }
        }

        public void LeaveEitherOneOrAllTheFieldsEmptyToAdd(string universityName, string countryName, string title, string degree, string year)  //Leave either one or all the fields empty
        {
            ClickAddNewButton();

            //Enter College/University Name
            var enterCollegeUniversityName = _state.Wait.WaitUntilElementToBeClickable(_collegeUniversityNameField);
            if (!string.IsNullOrWhiteSpace(universityName))
            {
                enterCollegeUniversityName.SendKeys(universityName);
            }
            //Select the country name using drop down
            var selectCountryDropDown = _state.Wait.WaitUntilElementToBeClickable(_countryDropDown);

            SelectElement selectCountry = new SelectElement(selectCountryDropDown);
            if (!string.IsNullOrWhiteSpace(countryName))
            {
                selectCountry.SelectByText(countryName);
            }
            else
            {
                selectCountry.SelectByIndex(0);
            }
            //Select the title using drop down
            var titleDropDown = _state.Wait.WaitUntilElementToBeClickable(_titleDropDown);

            SelectElement selectTitle = new SelectElement(titleDropDown);
            if (!string.IsNullOrWhiteSpace(title))
            {
                selectTitle.SelectByText(title);
            }
            else
            {
                selectTitle.SelectByIndex(0);
            }
            //Enter the degree
            var degreeElement = _state.Wait.WaitUntilElementToBeClickable(_degreeField);
            if (!string.IsNullOrWhiteSpace(degree))
            {
                degreeElement.SendKeys(degree);
            }
            //Select the year of graduation drop down
            var selectYearOfGraduationDropDown = _state.Wait.WaitUntilElementToBeClickable(_yearOfGraduationDropDown);

            SelectElement selectYear = new SelectElement(selectYearOfGraduationDropDown);
            if (!string.IsNullOrWhiteSpace(year))
            {
                selectYear.SelectByText(year);
            }
            else
            {
                selectYear.SelectByIndex(0);
            }
            ClickAddButton();
            ClickCancelButton();
        }

        public void ClickCancelButton()  //Click cancel button
        {
            var cancelElement = _state.Wait.WaitUntilElementToBeClickable(_cancelButton);
            cancelElement.Click();

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

        public bool IsEducationEmpty(string universityName)
        {
            try
            {
                var educationTable = _state.Wait.WaitUntilElementToBeClickable(_educationTable);
                var row = educationTable.FindElement(
                    By.XPath($".//tr[td[normalize-space(text())='{universityName}']]"));
                return false;
            }
            catch
            {
                return true;
            }
        }

        public void UpdateEducationDetails(string existingUniversityName, string universityName, string countryName, string title, string degree, string year)  //Update the education details
        {
            var educationTable = _state.Wait.WaitUntilElementToBeClickable(_educationTable);
            var row = educationTable.FindElement(By.XPath($".//tr[td[normalize-space(text())='{existingUniversityName}']]"));
            var editIcon = row.FindElement(By.XPath(".//td[@class='right aligned']//i[@class='outline write icon']"));
            editIcon.Click();

            var editableRow = educationTable.FindElement(By.XPath($".//tr[.//input[@type='text' and @value='{existingUniversityName}']]"));

            //Enter College/University Name
            var enterCollegeUniversityNameForUpdate = editableRow.FindElement(_collegeUniversityNameForUpdate);
            enterCollegeUniversityNameForUpdate.SendKeys(Keys.Control + "a" + Keys.Delete);
            enterCollegeUniversityNameForUpdate.SendKeys(universityName);

            //Select the country name using drop down
            var selectCountryDropDownForUpdate = _state.Wait.WaitUntilElementToBeClickable(_countryDropDownForUpdate);

            SelectElement selectCountry = new SelectElement(selectCountryDropDownForUpdate);
            selectCountry.SelectByText(countryName);

            //Select the title using drop down
            var titleDropDownForUpdate = _state.Wait.WaitUntilElementToBeClickable(_titleDropDownForUpdate);

            SelectElement selectTitle = new SelectElement(titleDropDownForUpdate);
            selectTitle.SelectByText(title);

            //Enter the degree
            var degreeForUpdate = _state.Wait.WaitUntilElementToBeClickable(_degreeFieldForUpdate);
            degreeForUpdate.SendKeys(Keys.Control + "a" + Keys.Delete);
            degreeForUpdate.SendKeys(degree);

            //Select the year of graduation drop down
            var selectYearOfGraduationDropDownForUpdate = _state.Wait.WaitUntilElementToBeClickable(_yearOfGraduationDropDownForUpdate);

            SelectElement selectYear = new SelectElement(selectYearOfGraduationDropDownForUpdate);
            selectYear.SelectByText(year);

            var updateButtonElement = _state.Wait.WaitUntilElementToBeClickable(_updateButton);
            updateButtonElement.Click();
        }

        public string GetSuccessMessageForUpdate(string successMessage)
        {
            try
            {
                var successMessageForUpdateElement = _state.Wait.WaitUntilElementIsVisible(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
                return successMessageForUpdateElement.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void CancelAddEducationDetails(string universityName, string countryName, string title, string degree, string year) //Cancel add education details
        {
            ClickAddNewButton();
            //Enter College/University Name
            var enterCollegeUniversityName = _state.Wait.WaitUntilElementToBeClickable(_collegeUniversityNameField);
            enterCollegeUniversityName.SendKeys(universityName);

            //Select the country name using drop down
            var selectCountryDropDown = _state.Wait.WaitUntilElementToBeClickable(_countryDropDown);

            SelectElement selectCountry = new SelectElement(selectCountryDropDown);
            selectCountry.SelectByText(countryName);

            //Select the title using drop down
            var titleDropDown = _state.Wait.WaitUntilElementToBeClickable(_titleDropDown);

            SelectElement selectTitle = new SelectElement(titleDropDown);
            selectTitle.SelectByText(title);

            //Enter the degree
            var degreeElement = _state.Wait.WaitUntilElementToBeClickable(_degreeField);
            degreeElement.SendKeys(degree);

            //Select the year of graduation drop down
            var selectYearOfGraduationDropDown = _state.Wait.WaitUntilElementToBeClickable(_yearOfGraduationDropDown);

            SelectElement selectYear = new SelectElement(selectYearOfGraduationDropDown);
            selectYear.SelectByText(year);
            ClickCancelButton();
        }

        public void LeaveEitherOneOrAllTheFieldsEmptyToUpdate(string existingUniversityName, string universityName, string countryName, string title, string degree, string year)  //Leave either one or all the fields empty
        {
            var educationTable = _state.Wait.WaitUntilElementIsVisible(_educationTable);
            var row = educationTable.FindElement(By.XPath($".//tr[td[normalize-space(text())='{existingUniversityName}']]"));
            var editIcon = row.FindElement(By.XPath(".//td[@class='right aligned']//i[@class='outline write icon']"));
            editIcon.Click();

            var editableRow = educationTable.FindElement(By.XPath($".//tr[.//input[@type='text' and @value='{existingUniversityName}']]"));

            //Enter College/University Name
            var enterCollegeUniversityNameForUpdate = editableRow.FindElement(_collegeUniversityNameForUpdate);
            enterCollegeUniversityNameForUpdate.SendKeys(Keys.Control + "a" + Keys.Delete);

            if (!string.IsNullOrWhiteSpace(universityName))
            {
                enterCollegeUniversityNameForUpdate.SendKeys(universityName);
            }
            //Select the country name using drop down
            var selectCountryDropDownForUpdate = _state.Wait.WaitUntilElementIsVisible(_countryDropDownForUpdate);

            SelectElement selectCountry = new SelectElement(selectCountryDropDownForUpdate);

            if (!string.IsNullOrWhiteSpace(countryName))
            {
                selectCountry.SelectByText(countryName);
            }
            else
            {
                selectCountry.SelectByIndex(0);
            }
            //Select the title using drop down
            var titleDropDownForUpdate = _state.Wait.WaitUntilElementIsVisible(_titleDropDownForUpdate);

            SelectElement selectTitle = new SelectElement(titleDropDownForUpdate);
            if (!string.IsNullOrWhiteSpace(title))
            {
                selectTitle.SelectByText(title);
            }
            else
            {
                selectTitle.SelectByIndex(0);
            }
            //Enter the degree
            var degreeForUpdate = _state.Wait.WaitUntilElementIsVisible(_degreeFieldForUpdate);
            degreeForUpdate.SendKeys(Keys.Control + "a" + Keys.Delete);
            if (!string.IsNullOrWhiteSpace(degree))
            {
                degreeForUpdate.SendKeys(degree);
            }
            //Select the year of graduation drop down
            var selectYearOfGraduationDropDownForUpdate = _state.Wait.WaitUntilElementIsVisible(_yearOfGraduationDropDownForUpdate);

            SelectElement selectYear = new SelectElement(selectYearOfGraduationDropDownForUpdate);
            if (!string.IsNullOrWhiteSpace(year))
            {
                selectYear.SelectByText(year);
            }
            else
            {
                selectYear.SelectByIndex(0);
            }
            var updateButtonElement = _state.Wait.WaitUntilElementIsVisible(_updateButton);
            updateButtonElement.Click();
        }

        public void ClickCancelUpdateButton()  //Click cancel update
        {
            var cancelUpdateElement = _state.Wait.WaitUntilElementIsVisible(_cancelUpdateButton);
            cancelUpdateElement.Click();
        }
    }
}







