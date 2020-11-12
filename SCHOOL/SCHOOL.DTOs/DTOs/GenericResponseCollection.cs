using System.Collections.Generic;

namespace SCHOOL.DTOs.DTOs
{
    public class StudentsList
    {
        public List<Student> Students { get; set; }
        public int StudentsCount { get; set; }
    }
    public class WorksheetList
    {
        public List<Worksheet> Worksheets { get; set; }
        public int WorksheetsCount { get; set; }
    }
    public class CoursesList
    {
        public List<Course> Courses { get; set; }
        public int CoursesCount { get; set; }
    }
}
