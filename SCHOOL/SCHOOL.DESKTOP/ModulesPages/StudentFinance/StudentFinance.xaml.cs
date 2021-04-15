using AutoMapper;
using SCHOOL.DTOs.ViewModels.Finance;
using SCHOOL.Services.Implementation;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBStudentFinances = SCHOOL.DATA.Models.Student_Finances;
using MessageBox = System.Windows.MessageBox;

namespace SCHOOL.DESKTOP.ModulesPages.StudentFinance
{
    /// <summary>
    /// Interaction logic for StudentFinance.xaml
    /// </summary>
 
    public partial class StudentFinance : Page
    {
        private readonly IClassService _classService;
        private readonly IStudentService _studentService;
        private readonly IStudentFinanceService _studentFinanceService;
        private readonly IStudentFinanceDetailsService _studentFinanceDetailsServic;
        private readonly IMapper _mapper;
        public StudentFinance(IStudentService studentService, IMapper mapper, IClassService classService, IStudentFinanceService studentFinanceService, IStudentFinanceDetailsService studentFinanceDetailsServic)
        {
            _studentService = studentService;
            _studentFinanceService = studentFinanceService;
            _studentFinanceDetailsServic = studentFinanceDetailsServic;
            _classService = classService;
            _mapper = mapper;
            InitializeComponent();
            InitComboBox();
        }
        private void InitComboBox()
        {
            ClassDropDownViewModel vm = new ClassDropDownViewModel(_classService);
            DataContext = vm;
            ClassDd.SelectedIndex = 1;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var result= new List<DBStudentFinances>();
            if ((bool)FeeCheckBox.IsChecked)
            {
                result = _studentFinanceService.GetAllByFilter(true,Year.Text, ClassDdl.Text);
            }
            else 
            {
                result = _studentFinanceService.GetAllByFilter(false, Year.Text, ClassDdl.Text);
            }
              
            if(!string.IsNullOrEmpty(RegNo.Text))
            {
                 result = result.Where(x => x.StudentFinanceDetails.Student.RegistrationNumber == Convert.ToInt64(string.IsNullOrEmpty(RegNo.Text) ? "0" : RegNo.Text)).Select(x => x).ToList();
            }
            result = result.Where(x => x.StudentFinanceDetails.FinanceTypes.Type != "Admission").ToList();
            var FinaceList=_mapper.Map<List<StudentFinanceViewModel>>(result);
            StudentDataGrid.ItemsSource = FinaceList;
        }
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<StudentFinanceViewModel>();
            foreach (StudentFinanceViewModel row in StudentDataGrid.ItemsSource)
                {
                if(row.DepositeFee)
                {
                    var stdUpdateDto = new SCHOOL.DTOs.DTOs.StudentFinances
                    {
                        Id = row.FinanceId,
                        Arears = Convert.ToDecimal(row.Arears)
                    };
                    _studentFinanceService.Update(stdUpdateDto);
                }
                else
                {
                    list.Add(row);
                }
                    
                }
            string message = "Fee have been submitted successfully.";
            MessageBox.Show(message);
            StudentDataGrid.ItemsSource = list;
            chkSelectAll.IsChecked = false;
        }
        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            if (StudentDataGrid.Items.Count>0)
            {
                var list = new List<StudentFinanceViewModel>();
                foreach (StudentFinanceViewModel c in StudentDataGrid.ItemsSource)
                {
                    c.DepositeFee = true;
                    list.Add(c);
                }
                StudentDataGrid.ItemsSource = list;
            }
            //else
            //{
            //    chkSelectAll.IsChecked = false;
            //}
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (StudentDataGrid.Items.Count > 0)
            {
                var list = new List<StudentFinanceViewModel>();
                foreach (StudentFinanceViewModel c in StudentDataGrid.ItemsSource)
                {
                    c.DepositeFee = false;
                    list.Add(c);
                }
                StudentDataGrid.ItemsSource = list;
            }
            //else
            //{
            //    chkSelectAll.IsChecked = false;
            //}
        }
        public void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var row = (StudentFinanceViewModel)StudentDataGrid.SelectedItems[0];
            var updateStudentFinance = new FinanceUpdate(row,_studentFinanceDetailsServic,_studentFinanceService);
            updateStudentFinance.ShowDialog();

        }
        private void StudentDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void FeeCheckBox_Checked(object sender, RoutedEventArgs e)
        {

            if((bool)FeeCheckBox.IsChecked)
            {
                SubmitBtn.Visibility = Visibility.Hidden;
            }

            else
            {
                SubmitBtn.Visibility = Visibility.Visible;
                StudentDataGrid.ItemsSource = null;
            }
        }
    }
    public class ClassDropDownViewModel : INotifyPropertyChanged
    {
        public CollectionView ClassEntries { get; set; }
        private string _classEntry;
        public ClassDropDownViewModel(IClassService classService)
        {
            var classList = classService.Get();
            ClassEntries = new CollectionView(classList);
            ClassEntry = classList[0].ClassName;
        }

        public string ClassEntry
        {
            get => _classEntry;
            set
            {
                if (_classEntry == value) return;
                _classEntry = value;
                OnPropertyChanged(_classEntry);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       
    }
}
