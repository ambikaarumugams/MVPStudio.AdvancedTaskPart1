namespace MarsAdvancedTaskPart1.Framework.Models
{
    public class SkillsModel
    {
        public List<AddSkill> AddSkill { get; set; } = new();
        public List<UpdateSkill> UpdateSkill { get; set; } = new();
        public List<DeleteSkill> DeleteSkill { get; set; } = new();
    }

    public class AddSkill
    {
        public string? Skill { get; set; } = string.Empty;
        public string SkillLevel { get; set; } = string.Empty;
        public SkillValidation SkillValidation { get; set; } = new();
    }

    public class UpdateSkill
    {
        public string ExistingSkill { get; set; } = string.Empty;
        public string? SkillToUpdate { get; set; } = string.Empty;
        public string SkillLevelToUpdate { get; set; } = string.Empty;
        public SkillValidation SkillValidation { get; set; } = new();
    }

    public class DeleteSkill
    {
        public string? SkillToBeDeleted { get; set; } = string.Empty;
        public SkillValidation SkillValidation { get; set; } = new();
    }

    public class SkillValidation
    {
        public string? SkillExpectedMessage { get; set; } = string.Empty;
    }
}
