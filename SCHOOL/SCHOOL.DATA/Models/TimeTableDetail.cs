using System;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.DATA.Models
{
    public partial class TimeTableDetail:BaseEntity
    {
        [StringLength(50)]
        public string Day { get; set; }

        public Guid? ClassId { get; set; }

        public Guid? PeriodId { get; set; }

        public Guid? TeacherId { get; set; }

        public Guid? TimeTableId { get; set; }

        public virtual Class Class { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Period Period { get; set; }

        public virtual TimeTable TimeTable { get; set; }
    }
}
