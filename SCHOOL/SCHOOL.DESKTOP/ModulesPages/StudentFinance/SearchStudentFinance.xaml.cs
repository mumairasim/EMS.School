using AutoMapper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBStudentFinances = SCHOOL.DATA.Models.Student_Finances;

namespace SCHOOL.DESKTOP.ModulesPages.StudentFinance
{
    /// <summary>
    /// Interaction logic for SearchStudentFinance.xaml
    /// </summary>
    public partial class SearchStudentFinance : Page
    {
        private readonly IStudentFinanceService _studentFinanceService;
        private readonly IMapper _mapper;
        public SearchStudentFinance(IStudentFinanceService studentFinanceService, IMapper mapper)
        {
            _studentFinanceService = studentFinanceService;
            _mapper = mapper;
            InitializeComponent();
        }

        private void DetailBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = new List<DBStudentFinances>();
         
            result = _studentFinanceService.GetAllByMonth(Year.Text, ClassDdl.Text);
           
            result = result.Where(x => x.StudentFinanceDetails.FinanceTypes.Type != "Admission").ToList();
            var FinaceList = _mapper.Map<List<StudentFinanceViewModel>>(result);
            StudentDataGrid.ItemsSource = FinaceList;
        }
    }


}
