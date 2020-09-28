using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL.DATA.Models
{
    [Table("Worksheet")]
    public partial class Worksheet : BaseEntity
    {
        public string Text { get; set; }

        public DateTime? ForDate { get; set; }

        public Guid? InstructorId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
