using System;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.DATA.Models
{
    public partial class TimeTableDetail:BaseEntity
    {
        [StringLength(50)]
        public string Day { get; set; }
        public Guid? TimeTableId { get; set; }

        public virtual TimeTable TimeTable { get; set; }
    }
}
