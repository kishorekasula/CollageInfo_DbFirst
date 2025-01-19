using System;
using System.Collections.Generic;

namespace CollageInfo.Entities;

public partial class SeaLearnerSubscriber
{
    public int SubscriberId { get; set; }

    public string? TranscriptId { get; set; }

    public string? LearnerId { get; set; }

    public int? PeopleKey { get; set; }

    public string? CourseId { get; set; }

    public string? SessionId { get; set; }

    public string? Status { get; set; }

    public long? CompletionDate { get; set; }

    public int? SourceId { get; set; }

    public string? SourceName { get; set; }

    public DateTime? SubscribedDateTime { get; set; }

    public string? Payload { get; set; }

    public bool? IsProcessed { get; set; }
}
