using MarsAdvancedTaskPart1.Framework.Helpers;
using OpenQA.Selenium;

namespace MarsAdvancedTaskPart1.Framework.Pages.Components.NavigationMenuComponent
{
    public class ManageListingsComponent
    {
        private readonly TestState _state;

        public ManageListingsComponent(TestState state)
        {
            _state = state;
        }

        //Locators
        private readonly By _manageListingsTab = By.XPath("//a[normalize-space()='Manage Listings']");
        private readonly By _manageListingsTable = By.XPath("//table[@class='ui striped table']");

        //Action Methods
        public void ClickManageListingsTab()
        {
            var manageListingsElement =_state.Wait.WaitUntilElementToBeClickable(_manageListingsTab);
            manageListingsElement.Click();
        }

        public string GetAttributeOfManageListings()
        {
            var manageListingsElement = _state.Wait.WaitUntilElementToBeClickable(_manageListingsTab);
            var hrefValue=manageListingsElement.GetAttribute("href");
            return hrefValue;
        }

        public void ClickEditIcon()
        {
            var editIcon = _state.Wait.WaitUntilElementToBeClickable(By.XPath("//i[@class='outline write icon']"));
            editIcon.Click();
        }

        public List<List<string>> GetManageListingsTable()
        {
            var manageListingsTable = _state.Wait.WaitUntilElementToBeClickable(_manageListingsTable);
            var rows = manageListingsTable.FindElements(By.XPath("//tbody//tr"));
            var allData = new List<List<string>>();

            foreach (var row in rows)
            {
                var cells = row.FindElements(By.XPath("./td[position() >= 2 and position() <= 4]"));
                var cellValues = cells.Select(c => c.Text.Trim()).ToList();
                allData.Add(cellValues);
            }
            return allData;
        }

        public string GetTextFromViewManageListings()
        {
            var viewManageListings =
                _state.Wait.WaitUntilElementToBeClickable(
                    By.XPath("//div[@class='ten wide column']//div[@class='ui fluid card']"));
            return viewManageListings.Text;
        }

        public string GetTitle()
        {
            var getTitle = _state.Wait.WaitUntilElementToBeClickable(By.XPath("//span[@class='skill-title']"));
            return getTitle.Text;
        }

       
    }
}
