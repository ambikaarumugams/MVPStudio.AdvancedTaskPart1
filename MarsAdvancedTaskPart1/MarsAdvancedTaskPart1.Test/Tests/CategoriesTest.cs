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
            State.Test.Log(Status.Info, "Starting Categories footer test...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _categoriesComponent = new CategoriesComponent(State);
            _categoriesComponent.NavigateToTheProfilePage();

            _categoriesComponent.ClickCategoriesTab();

            var categories = new Dictionary<Action, string>
            {
                { ()=>_categoriesComponent.ClickGraphicsDesignLink(),"Graphics Design"},
                { ()=>_categoriesComponent.ClickDigitalMarketingLink(),"Digital Marketing"},
                { ()=> _categoriesComponent.ClickWritingAndTranslationLink(),"Writing & Translation"},
                { ()=>_categoriesComponent.ClickVideoAndAnimationLink(),"Video & Animation"},
                { ()=>_categoriesComponent.ClickMusicAndAudioLink(),"Music & Audio" },
                { ()=>_categoriesComponent.ClickProgrammingTechLink(),"Programming Tech" },
                { ()=>_categoriesComponent.ClickBusinessLink(),"Business" },
                { ()=>_categoriesComponent.ClickFunAndLifestyleLink(),"Fun & Lifestyle"},
                {()=>_categoriesComponent.ClickSiteMapLink(),"Site Map"}
            };

            foreach (var category in categories)
            {
                category.Key.Invoke();
                State.Test.Log(Status.Info, $"Clicked on {category.Value} link. It shows loading....");
            }
            var actual = _categoriesComponent.IsCategoriesVisible();
            State.Assert.IsTrueBool(actual);
        }
    }
}
