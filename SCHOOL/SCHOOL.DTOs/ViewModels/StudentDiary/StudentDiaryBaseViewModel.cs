using System;

namespace SCHOOL.DTOs.ViewModels.StudentDiary
{
    public class StudentDiaryBaseViewModel
    {
        public Guid Id { get; set; }
        public string DairyText { get; set; }
        public DateTime? DairyDate { get; set; }
        public string EmployeeName { get; set; }
    }
}
