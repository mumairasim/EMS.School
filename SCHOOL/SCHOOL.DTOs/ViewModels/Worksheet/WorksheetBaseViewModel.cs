using System;

namespace SCHOOL.DTOs.ViewModels.Worksheet
{
    public class WorksheetBaseViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime? ForDate { get; set; }
        public Guid? InstructorId { get; set; }
        public string EmployeeName { get; set; }
    }
}
