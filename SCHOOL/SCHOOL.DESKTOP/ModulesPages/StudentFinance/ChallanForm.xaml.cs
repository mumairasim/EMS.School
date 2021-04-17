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
    /// Interaction logic for ChallanForm.xaml
    /// </summary>
    /// 
  
    public partial class ChallanForm : Window
    {
        private readonly IStudentFinanceDetailsService _studentFinanceDetailsService;
        public ChallanForm(StudentFinanceViewModel row,IStudentFinanceDetailsService studentFinanceDetailsService)
        {
            _studentFinanceDetailsService = studentFinanceDetailsService;
            InitializeComponent();
            PopulateData(row);
        }
        public void PopulateData(StudentFinanceViewModel row)
        {

            var studentFinance = _studentFinanceDetailsService.GetByStudentId(row.StId);
            var FinanceDetail = studentFinance.Where(x => x.FinanceTypes.Type == "Admission" && x.Student_Finances.Count > 0).Select(a => a.Student_Finances.FirstOrDefault()).FirstOrDefault();
            IssueDate.Text = DateTime.Today.ToString("dd MMM yyyy");
            IssueDate1.Text = DateTime.Today.ToString("dd MMM yyyy");
            IssueDate2.Text = DateTime.Today.ToString("dd MMM yyyy");
            Month.Text= DateTime.Today.ToString("MMMM dd");
            Month1.Text = DateTime.Today.ToString("MMMM dd");
            Month2.Text = DateTime.Today.ToString("MMMM dd");
            Name.Text = row.FirstName;
            Name1.Text = row.FirstName;
            Name2.Text = row.FirstName;
            Class.Text = "Class : " + row.Class;
            Class1.Text = "Class : " + row.Class;
            Class2.Text = "Class : " + row.Class;
            Amount.Text = row.Fee.ToString();
            Amount1.Text = row.Fee.ToString();
            Amount2.Text = row.Fee.ToString();
            Arreas.Text = row.Arears.ToString();
            Arreas1.Text = row.Arears.ToString();
            Arreas2.Text = row.Arears.ToString();
          
            if (FinanceDetail == null)
            {
                AddmissionAmount.Text = studentFinance.Where(x => x.FinanceTypes.Type == "Admission").Select(a => ((int)(a.Fee)).ToString()).FirstOrDefault();
                AddmissionAmount1.Text = studentFinance.Where(x => x.FinanceTypes.Type == "Admission").Select(a => ((int)(a.Fee)).ToString()).FirstOrDefault();
                AddmissionAmount2.Text= studentFinance.Where(x => x.FinanceTypes.Type == "Admission").Select(a => ((int)(a.Fee)).ToString()).FirstOrDefault();
            }
            else
            {
                AddmissionAmount.Text = "0";
                AddmissionAmount1.Text = "0";
                AddmissionAmount2.Text = "0";
            }
            TOTALDUE.Text = (row.Fee + row.Arears  + Convert.ToInt32(AddmissionAmount.Text)).ToString();
            TOTALDUE1.Text = (row.Fee + row.Arears + Convert.ToInt32(AddmissionAmount.Text)).ToString();
            TOTALDUE2.Text = (row.Fee + row.Arears + Convert.ToInt32(AddmissionAmount.Text)).ToString();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
    
}
