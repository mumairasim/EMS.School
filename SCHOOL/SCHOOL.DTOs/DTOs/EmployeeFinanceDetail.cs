using System;

namespace SCHOOL.DTOs.DTOs
{
    public class EmployeeFinanceDetail : DtoBaseEntity
    {
        public Guid? EmployeeId { get; set; }
        public decimal? Salary { get; set; }
    }
}
