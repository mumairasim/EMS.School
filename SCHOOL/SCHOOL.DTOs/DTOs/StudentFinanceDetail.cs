using System;

namespace SCHOOL.DTOs.DTOs
{
    public class StudentFinanceDetail : DtoBaseEntity
    {
        public Guid? StudentId { get; set; }
        public decimal? Fee { get; set; }

        public Guid? FinanceTypeId { get; set; }

    }
}
