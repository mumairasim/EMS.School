using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHOOL.DTOs.ViewModels.Finance
{
   public class StudentFinanceViewModel
    {
        public long RegNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int Fee { get; set; }
        public int Arears { get; set; }
        public bool DepositeFee { get; set; }
        public Guid StId { get; set; }
        public Guid FinanceId { get; set; }
    }
}
