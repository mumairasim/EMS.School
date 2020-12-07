using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SCHOOL.DTOs.ViewModels.Attendance
{
    public class AttendanceBaseViewModel
    {
        public Guid Id { get; set; }
        public int RegistrationNumber { get; set; }

        public string PersonName { get; set; }
        public string PersonCnic { get; set; }
        public string PersonNationality { get; set; }
        public string PersonReligion { get; set; }
        public string AttendanceStatus { get; set; }
    }
}
