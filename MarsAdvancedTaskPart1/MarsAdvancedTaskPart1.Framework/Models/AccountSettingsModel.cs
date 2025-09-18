namespace MarsAdvancedTaskPart1.Framework.Models
{
    public class AccountSettingsModel
    {
        public string? Name { get; set; }
        public PasswordModel? Password { get; set; }
        public string? ExpectedMessageForDeactivateAccount { get; set; }
    }

    public class PasswordModel
    {
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? ExpectedMessage { get; set; }
    }
}
