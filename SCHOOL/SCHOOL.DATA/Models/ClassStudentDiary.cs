using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL.DATA.Models
{
    [Table("ClassStudentDiary")]
    public partial class ClassStudentDiary:BaseEntity
    {
        public int? StudentDiaryId { get; set; }

        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual StudentDiary StudentDiary { get; set; }
    }
}
