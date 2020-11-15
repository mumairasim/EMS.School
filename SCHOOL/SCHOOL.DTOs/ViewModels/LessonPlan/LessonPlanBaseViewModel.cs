using System;

namespace SCHOOL.DTOs.ViewModels.LessonPlan
{
    public class LessonPlanBaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
