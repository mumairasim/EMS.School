using System;

namespace SCHOOL.DTOs.DTOs
{
    public class StudentFinances : DtoBaseEntity
    {
        public Guid? StudentFinanceDetailsId { get; set; }

        public bool FeeSubmitted { get; set; } = false;
        public DateTime? FeeSubmissionDate { get; set; }
        public string FeeMonth { get; set; }
        public string FeeYear { get; set; }
        public decimal? Arears { get; set; }
        public DateTime? LastDateSubmission { get; set; }
    }
}
