using System;

namespace SCHOOL.DTOs.ViewModels.Course
{
    public class CourseBaseViewModel
    {
        public Guid Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}
