namespace MarsAdvancedTaskPart1.Framework.Models
{
    public class ShareSkillModel
    {
        public List<ShareSkillDetails> ShareSkills { get; set; } = new();
    }

    public class ShareSkillDetails
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? Category { get; set; }
        public string? SubCategory { get; set; }

        public List<string>? Tags { get; set; }

        public string? ServiceType { get; set; }
        public string? LocationType { get; set; }

        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public List<CalendarEvent>? Events { get; set; } = new();

        public string? SkillTradeType { get; set; }
        public List<string>? SkillExchangeTags { get; set; }
        public int? CreditAmount { get; set; }

        public List<string>? WorkSamples { get; set; }

        public string? Active { get; set; }

        public string? ExpectedToastType { get; set; }
        public string? ExpectedToastContains { get; set; }
    }

    public class CalendarEvent
    {
        public string? Title { get; set; }
        public string Start { get; set; } = "";
        public string End { get; set; } = "";
        public bool AllDayEvent { get; set; } = false;
        public string? Repeat { get; set; } = "Never";
        public string? Description { get; set; }
        public string? Owner { get; set; }
    }
}

