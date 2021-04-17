using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL.DATA.Models
{
    public partial class StudentFinanceDetail:BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentFinanceDetail()
        {
            Student_Finances = new HashSet<Student_Finances>();
        }
        public Guid? StudentId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fee { get; set; }
        [Column(TypeName = "money")]
        public decimal? Arears { get; set; }

        public Guid? FinanceTypeId { get; set; }

        public virtual FinanceType FinanceTypes { get; set; }

        public virtual Student Student { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Finances> Student_Finances { get; set; }
    }
}
