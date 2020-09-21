using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL.DATA.Models
{
    [Table("Assignment")]
    public partial class Assignment : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignment()
        {
        }

        public string AssignmentText { get; set; }

        public DateTime? LastDateOfSubmission { get; set; }

        public Guid? InstructorId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
