using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL.DATA.Models
{
    public partial class Student_Finances : BaseEntity
    {
        public Guid? StudentFinanceDetailsId { get; set; }

        public bool? FeeSubmitted { get; set; }
        [Column(TypeName = "money")]
        public decimal? Arears { get; set; }
        public DateTime? FeeSubmissionDate { get; set; }

        [StringLength(250)]
        public string FeeMonth { get; set; }

        [StringLength(250)]
        public string FeeYear { get; set; }

        public DateTime? LastDateSubmission { get; set; }

        public virtual StudentFinanceDetail StudentFinanceDetails { get; set; }
    }
}
