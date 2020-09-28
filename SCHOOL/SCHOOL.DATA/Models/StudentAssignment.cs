using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL.DATA.Models
{
    [Table("StudentAssignment")]
    public partial class StudentAssignment:BaseEntity
    {
        public Guid? StudentId { get; set; }

        public Guid? AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; }

        public virtual Student Student { get; set; }
    }
}
