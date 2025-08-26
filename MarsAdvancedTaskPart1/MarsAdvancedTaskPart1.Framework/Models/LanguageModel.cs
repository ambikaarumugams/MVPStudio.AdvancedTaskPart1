namespace MarsAdvancedTaskPart1.Framework.Models
{
    public class LanguageModel
    {
        public List<AddLanguage> AddLanguage { get; set; } = new();
        public List<UpdateLanguage> UpdateLanguage { get; set; } = new();
        public List<DeleteLanguage> DeleteLanguage { get; set; } = new();
    }

    public class AddLanguage   
    {
        public string? Language { get; set; } = string.Empty;
        public string? LanguageLevel { get; set; } = string.Empty;
        public Validation? Validation { get; set; } = new();
    }

    public class UpdateLanguage   
    {
        public string? ExistingLanguage { get; set; } = string.Empty;
        public string? LanguageToUpdate { get; set; } = string.Empty;
        public string? LanguageLevelToUpdate { get; set; } = string.Empty;
        public Validation? Validation { get; set; } = new();
    }

    public class DeleteLanguage  
    {
        public string? LanguageToBeDeleted { get; set; } = string.Empty;
        public Validation? Validation { get; set; } = new();
    }

    public class Validation
    {
        public string? ExpectedMessage { get; set; } = string.Empty;
    }
}
