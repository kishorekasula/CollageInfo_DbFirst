using System.Diagnostics.CodeAnalysis;

namespace CollageInfo.Models
{
    [ExcludeFromCodeCoverage]
    public class LearnerModel
    {
       // public int SubscriberID { get; set; }
        public string? TranscriptID { get; set; }

        public string? Employee_ID { get; set; }

        public int? PeopleKey { get; set; }

        public string? CourseID { get; set; }

        public string? SessionID { get; set; }

        public string? Status { get; set; }

        public long? CompletionDate { get; set; }

        public int? SourceID { get; set; }

        public string? SourceName { get; set; }

    }
}
