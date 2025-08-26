using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Helpers;
using MarsAdvancedTaskPart1.Framework.Models;
using MarsAdvancedTaskPart1.Framework.Pages.Components;

namespace MarsAdvancedTaskPart1.Test.Tests
{
    public class ShareSkillTest:TestBase.TestBase
    {
        private ShareSkillComponent? _shareSkillComponent;

        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.ShareSkill_ValidInput))]
        public void ShareSkills_ValidInput(ShareSkillModel shareSkillModel)
        {
            List<string> actualMessages = new();
            List<string?> expectedMessages = new();

            State.Test.Log(Status.Info, "Starting add skills with valid input...");
            State.Test.Log(Status.Info, "Enter the Username and Password");
            State.SignInComponent.SignIn(State.LoginData.Username, State.LoginData.Password);
            _shareSkillComponent = new ShareSkillComponent(State);
            _shareSkillComponent.NavigateToTheProfilePage();

            State.Test.Log(Status.Info, "Enter the skill and level");
            foreach (var skill in shareSkillModel.ShareSkills)
            {
                _shareSkillComponent.ClickShareSkill();
                foreach(var tag in skill.Tags)
                {
                    _shareSkillComponent.AddTag(tag);
                }
                
                _shareSkillComponent.ServiceType(skill.ServiceType);
                _shareSkillComponent.LocationType(skill.LocationType);

                _shareSkillComponent.SelectDate(skill.StartDate);
                _shareSkillComponent.ChooseSkillExchange();

                foreach (var skillTag in skill.SkillExchangeTags)
                {
                    _shareSkillComponent.AddSkillExchangeTag(skillTag);
                }
                    _shareSkillComponent.SetActiveYes();
                _shareSkillComponent.ClickSave();
            }
        }
    }
}
    