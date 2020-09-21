using System;
using System.Collections.Generic;

namespace SCHOOL.DTOs.DTOs
{
    public class StudentAttendance : DtoBaseEntity
    {
        public DateTime? AttendanceDate { get; set; }
        public Guid? ClassId { get; set; }
        public Class Class { get; set; }
        public List<StudentAttendanceDetail> StudentAttendanceDetail { get; set; }
    }
}
