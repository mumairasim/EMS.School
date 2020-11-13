using System;

namespace SCHOOL.DTOs.ViewModels.TeacherDiary
{
    public class TeacherDiaryBaseViewModel
    {
        public Guid Id { get; set; }
        public string DairyText { get; set; }
        public DateTime? DairyDate { get; set; }
        public string EmployeeName { get; set; }
    }
}
