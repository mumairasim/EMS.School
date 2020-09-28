using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL.DATA.Models
{
    [Table("Period")]
    public partial class Period : BaseEntity
    {
        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }
        public Guid? TeacherId { get; set; }

        public Guid? TimeTableDetailId { get; set; }

        public Guid? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Employee Employee { get; set; }


        public virtual TimeTableDetail TimeTableDetail { get; set; }
    }
}
