using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHOOL.DATA.Models
{
    [Table("StudentAttendance")]
    public partial class StudentAttendance : BaseEntity
    {
        public DateTime AttendanceDate { get; set; }
        public Guid? SchoolId { get; set; }
        public Guid? ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
