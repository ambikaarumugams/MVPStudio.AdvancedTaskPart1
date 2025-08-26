namespace MarsAdvancedTaskPart1.Framework.Models
{
    public class ProfileOverviewModel
    {
        public List<ProfileDetails> ProfileDetails { get; set; } = new();
    }

    public class ProfileDetails
    {
        public string DisplayName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Availability { get; set; } = string.Empty;
        public string Hours { get; set; } = string.Empty;
        public string EarnTarget { get; set; } = string.Empty;
        public string DisplayNameExpectedMessage { get; set; } = string.Empty;
        public string AvailabilityExpectedMessage { get; set; } = string.Empty;
        public string HoursExpectedMessage { get; set; } = string.Empty;
        public string EarnTargetExpectedMessage { get; set; } = string.Empty;
    }
}
