using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL.DATA.Models
{
    [Table("AttendanceStatus")]
    public partial class AttendanceStatus : BaseEntity
    {
        public string Status { get; set; }
    }
}
