using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ViewModels.Finance;
using SCHOOL.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SCHOOL.DESKTOP.ModulesPages.StudentFinance
{
    /// <summary>
    /// Interaction logic for FinanceUpdate.xaml
    /// </summary>
    public partial class FinanceUpdate : Window
    {
        private readonly IStudentFinanceDetailsService _studentFinanceDetailsService;
        private readonly IStudentFinanceService _studentFinanceService;
        public static Guid StudentId =Guid.Empty;
        public static Guid FinanceId = Guid.Empty;
        public FinanceUpdate(StudentFinanceViewModel row, IStudentFinanceDetailsService studentFinanceDetailsService,IStudentFinanceService studentFinanceService)
        {
           
            InitializeComponent();
            _studentFinanceDetailsService = studentFinanceDetailsService;
            _studentFinanceService = studentFinanceService;
            StudentId = row.StId;
            FinanceId = row.FinanceId;
            populateData(row);
            
        }
        public void populateData(StudentFinanceViewModel row)
        {
            var studentFinance = _studentFinanceDetailsService.GetByStudentId(StudentId);
            var FinanceDetail = studentFinance.Where(x => x.FinanceTypes.Type == "Admission" && x.Student_Finances.Count>0).Select(a => a.Student_Finances.FirstOrDefault()).FirstOrDefault();
            FirstName.Text = row.FirstName;
            LastName.Text = row.LastName;
            RegNo.Text = row.RegNo.ToString();
            Month.Text = row.Month;
            Year.Text = row.Year;
            Arears.Text = string.IsNullOrEmpty(row.Arears.ToString())?"0": row.Arears.ToString();
            MonthlyFee.Text = row.Fee.ToString();
            AdmissionFee.Text = studentFinance.Where(x => x.FinanceTypes.Type == "Admission").Select(a => ((int)(a.Fee)).ToString()).FirstOrDefault();
            if (FinanceDetail == null)
            {
                AdmissionFeeCheckBox.IsChecked = false;
            }
            else
            {
                AdmissionFeeCheckBox.IsChecked = FinanceDetail?.FeeSubmitted;
                AdmissionFee.IsReadOnly = true;
            }
            MonthlyFeeCheckBox.IsChecked = row.DepositeFee;
            if(row.DepositeFee)
            {
                MonthlyFee.IsReadOnly = true;
            }
         


        }
        public void ClearFromData()
        {
            FirstName.Text =string.Empty;
            LastName.Text = string.Empty;
            RegNo.Text = string.Empty;
            Month.Text = string.Empty;
            Year.Text = string.Empty;
            Arears.Text = string.Empty;
            MonthlyFee.Text = string.Empty;
            AdmissionFee.Text = string.Empty;
            AdmissionFeeCheckBox.IsChecked = false;


        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(bool)AdmissionFeeCheckBox.IsChecked)
            {
                var studentFinance = _studentFinanceDetailsService.GetByStudentId(StudentId);
                var stdFinance = new StudentFinanceInfo
                {
                    Id = Guid.NewGuid(),
                    FeeSubmitted = true,
                    FeeMonth = Month.Text,
                    FeeYear = Year.Text,
                    StudentFinanceDetailsId = studentFinance.Where(x => x.FinanceTypes.Type == "Admission").Select(a => a.Id).FirstOrDefault(),
                    Arears = Convert.ToDecimal(string.IsNullOrEmpty(Arears.Text) ? "0" :Arears.Text),
                    CreatedDate=DateTime.Now
                };
                
                _studentFinanceService.Create(stdFinance);
                var stdUpdateDto = new SCHOOL.DTOs.DTOs.StudentFinances
                {
                    Id= FinanceId,
                   Arears = Convert.ToDecimal(string.IsNullOrEmpty(Arears.Text) ? "0" : Arears.Text)
                };
                _studentFinanceService.Update(stdUpdateDto);

            }
            else
            {
                var stdUpdateDto = new SCHOOL.DTOs.DTOs.StudentFinances
                {
                    Id = FinanceId,
                    Arears = Convert.ToDecimal(string.IsNullOrEmpty(Arears.Text) ? "0" : Arears.Text)
                };
                _studentFinanceService.Update(stdUpdateDto);

            }
            string message = "Your details have been saved successfully.";
            MessageBox.Show(message);
            //ClearFromData();
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
