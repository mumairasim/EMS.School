using System;

namespace SCHOOL.DATA.Models.NonDbContextModels
{
    public class EmployeeFinanceInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string SchoolName { get; set; }
        public string SalaryMonth { get; set; }
        public string SalaryYear { get; set; }
        public bool IsSalaryTransferred { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid? EmpFinanceDetailsId { get; set; }
    }
}
