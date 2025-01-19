﻿namespace CollageInfo.Models
{
    public class CourseSubscriptionModel
    {

        public string? CourseId { get; set; }

        public string? CourseName { get; set; }

        public string? CourseType { get; set; }

        public decimal? CourseHours { get; set; }

        public string? ContentLevel { get; set; }

        public string? SessionId { get; set; }

        public string? CurriculumDispCat { get; set; }

        public DateTime? SubscribedDateTime { get; set; }

        public string? Payload { get; set; }

    }
}
