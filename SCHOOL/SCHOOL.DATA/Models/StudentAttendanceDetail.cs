using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHOOL.DATA.Models
{
    [Table("StudentAttendanceDetail")]
    public partial class StudentAttendanceDetail : BaseEntity
    {

        public Guid? AttendanceStatusId { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? StudentAttendanceId { get; set; }
        public virtual StudentAttendance StudentAttendance { get; set; }
        public virtual AttendanceStatus AttendanceStatus { get; set; }
        public virtual Student Student { get; set; }
    }
}
