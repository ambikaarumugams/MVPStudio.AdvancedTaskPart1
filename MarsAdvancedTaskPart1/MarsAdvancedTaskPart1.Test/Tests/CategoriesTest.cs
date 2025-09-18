using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Pages.Components.FooterComponent;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    [TestFixture]
    public class CategoriesTest : TestBase.TestBase
    {
        private CategoriesComponent? _categoriesComponent;

        [Test]
        public void SelectCategoriesFooterTab()
        {
            var actualMessages = new List<string>();
            var expectedMessages = new List<string>();
            State.Test.Log(Status.Info, "Starting Categories footer test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _categoriesComponent = new CategoriesComponent(State);
            _categoriesComponent.NavigateToTheProfilePage();

            _categoriesComponent.ClickCategoriesTab();

            var categories = new Dictionary<Action, string>
            {
                { ()=>_categoriesComponent.ClickGraphicsDesignLink(),"GraphicsDesign"},
                { ()=>_categoriesComponent.ClickDigitalMarketingLink(),"DigitalMarketing"},
                { ()=> _categoriesComponent.ClickWritingAndTranslationLink(),"Writing&Translation"},
                { ()=>_categoriesComponent.ClickVideoAndAnimationLink(),"Video&Animation"},
                { ()=>_categoriesComponent.ClickMusicAndAudioLink(),"Music&Audio" },
                { ()=>_categoriesComponent.ClickProgrammingTechLink(),"ProgrammingTech" },
                { ()=>_categoriesComponent.ClickBusinessLink(),"Business" },
                { ()=>_categoriesComponent.ClickFunAndLifestyleLink(),"Fun&Lifestyle"},
                {()=>_categoriesComponent.ClickSiteMapLink(),"SiteMap"}
            };

            foreach (var category in categories)
            {
                category.Key.Invoke();
                var result = _categoriesComponent.GetTextOfCategories();
                State.Test.Log(Status.Info, $"Clicked on {category.Value} link.It shows {result}..");
                string actualUrl = State.Driver.Url; // get current URL
                actualMessages.Add(actualUrl);
                expectedMessages.Add(category.Value);
              
            }
            var refineResults = _categoriesComponent.GetListOfCategoriesFromRefineResults();
            Console.WriteLine(refineResults); actualMessages.Add(refineResults);
            foreach (var expected in expectedMessages)
            {
                State.Assert.AssertListHasUrlWith(actualMessages, expected);
                //State.Assert.AssertListHasUrlWith(actualMessages, "/Sitemap");
            }


        }
    }
}
