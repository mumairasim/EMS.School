using System;

namespace SCHOOL.DTOs.ViewModels.Employee
{
    public class EmployeeBaseViewModel
    {
        public Guid Id { get; set; }
        public int RegistrationNumber { get; set; }

        public string PersonName { get; set; }
        public string PersonCnic { get; set; }
        public string PersonNationality { get; set; }
        public string PersonReligion { get; set; }
        public string ClassName { get; set; }
    }
}
