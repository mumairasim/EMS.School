using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.DATA.Models
{
    public partial class FinanceType : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinanceType()
        {
            //StudentFinanceDetails = new HashSet<StudentFinanceDetail>();
        }

        [StringLength(500)]
        public string Type { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StudentFinanceDetail> StudentFinanceDetails { get; set; }
    }
}
