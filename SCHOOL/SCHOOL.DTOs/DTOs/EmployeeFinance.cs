using System;

namespace SCHOOL.DTOs.DTOs
{
    public class EmployeeFinance : DtoBaseEntity
    {
        public Guid? EmployeeFinanceDetailsId { get; set; }

        public bool? SalaryTransfered { get; set; }

        public DateTime? SalaryTransferDate { get; set; }

        public string SalaryMonth { get; set; }

        public string SalaryYear { get; set; }
    }
}
