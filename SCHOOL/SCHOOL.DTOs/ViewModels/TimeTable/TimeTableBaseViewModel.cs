using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHOOL.DTOs.ViewModels.TimeTable
{
    public class TimeTableBaseViewModel
    {
        public Guid Id { get; set; }
        public string TimeTableName { get; set; }
        public string ClassName { get; set; }
    }
}
