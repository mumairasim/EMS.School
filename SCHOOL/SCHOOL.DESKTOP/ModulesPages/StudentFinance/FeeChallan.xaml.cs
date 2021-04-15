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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoMapper;
using SCHOOL.DTOs.ViewModels.Finance;
using SCHOOL.Services.Infrastructure;
using DBStudentFinances = SCHOOL.DATA.Models.Student_Finances;
namespace SCHOOL.DESKTOP.ModulesPages.StudentFinance
{
    /// <summary>
    /// Interaction logic for FeeChallan.xaml
    /// </summary>

    public partial class FeeChallan : Page
    {
        private readonly IStudentFinanceService _studentFinanceService;
        private readonly IStudentFinanceDetailsService _studentFinanceDetailsService;
        private readonly IMapper _mapper;
        public FeeChallan(IStudentFinanceService studentFinanceService, IMapper mapper, IStudentFinanceDetailsService studentFinanceDetailsService)
        {
            InitializeComponent();
            _studentFinanceService = studentFinanceService;
            _studentFinanceDetailsService = studentFinanceDetailsService;
            _mapper = mapper;
        }
        private void DetailBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = new List<DBStudentFinances>();

            result = _studentFinanceService.GetAllByMonth(null,null);

            result = result.Where(x => x.StudentFinanceDetails.FinanceTypes.Type != "Admission").ToList();
            if (!string.IsNullOrEmpty(RegNo.Text))
            {
                result = result.Where(x => x.StudentFinanceDetails.Student.RegistrationNumber == Convert.ToInt64(string.IsNullOrEmpty(RegNo.Text) ? "0" : RegNo.Text)).Select(x => x).ToList();
            }
            var FinaceList = _mapper.Map<List<StudentFinanceViewModel>>(result);
            StudentDataGrid.ItemsSource = FinaceList;
        }
        public void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            var row = (StudentFinanceViewModel)StudentDataGrid.SelectedItems[0];

            var challanForm = new ChallanForm(row,_studentFinanceDetailsService);
            challanForm.ShowDialog();

        }
    }
}
