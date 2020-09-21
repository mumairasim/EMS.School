using System;
namespace SCHOOL.DTOs.DTOs
{
    public class StudentDiary : DtoBaseEntity
    {

        public string DiaryText { get; set; }

        public DateTime? DairyDate { get; set; }

        public Guid? InstructorId { get; set; }

        public Employee Employee { get; set; }
    }
}
