using System;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.DATA.Models
{
    public partial class EmployeeFinance : BaseEntity
    {
        public int? EmployeeFinanceDetailsId { get; set; }

        public bool? SalaryTransfered { get; set; }

        public DateTime? SalaryTransferDate { get; set; }

        [StringLength(250)]
        public string SalaryMonth { get; set; }

        [StringLength(250)]
        public string SalaryYear { get; set; }

        public virtual EmployeeFinanceDetail EmployeeFinanceDetail { get; set; }
    }
}
