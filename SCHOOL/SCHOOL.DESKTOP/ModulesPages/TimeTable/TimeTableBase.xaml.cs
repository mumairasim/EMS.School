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
using SCHOOL.DESKTOP.ModulesPages.Student;
using SCHOOL.DTOs.ViewModels.Student;
using SCHOOL.DTOs.ViewModels.TimeTable;
using SCHOOL.Services.Infrastructure;

namespace SCHOOL.DESKTOP.ModulesPages.TimeTable
{
    /// <summary>
    /// Interaction logic for TimeTableBase.xaml
    /// </summary>
    public partial class TimeTableBase : Page
    {
        private readonly IMapper _mapper;
        private readonly ITimeTableService _timeTableService;
        private const int PageSize = 50;
        public int Page { get; set; }
        public TimeTableBase(IMapper mapper, ITimeTableService timeTableService)
        {
            _mapper = mapper;
            _timeTableService = timeTableService;
            InitializeComponent();
            PreLoads();
        }
        public void PreLoads()
        {
            Page = 1;
            var timeTableList = _timeTableService.Get(1, PageSize);
            var timeTables = new List<TimeTableBaseViewModel>();
            _mapper.Map(timeTableList.TimeTables, timeTables);
            TimeTableDataGrid.ItemsSource = timeTables;
        }
        public void SearchTimeTables(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var timeTableList = _timeTableService.Get(1, PageSize);
            var timeTables = new List<TimeTableBaseViewModel>();
            _mapper.Map(timeTableList.TimeTables, timeTables);
            TimeTableDataGrid.ItemsSource = timeTables;
        }
        public void rowEditButton_Click(object sender, RoutedEventArgs e)
        {
            //var row = (StudentBaseViewModel)StudentDataGrid.SelectedItems[0];
            //var updateStudent = new UpdateStudent(row, _studentService);
            //updateStudent.ShowDialog();
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            //Page = 1;
            //var studentList = _studentService.Get(SearchStudentTextBox.Text, 1, PageSize);
            //var students = new List<StudentBaseViewModel>();
            //_mapper.Map(studentList.Students, students);
            //StudentDataGrid.ItemsSource = students;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            //if (Page > 1)
            //{
            //    Page--;
            //}
            //var studentList = _studentService.Get(SearchStudentTextBox.Text, Page, PageSize);
            //var students = new List<StudentBaseViewModel>();
            //_mapper.Map(studentList.Students, students);
            //StudentDataGrid.ItemsSource = students;
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            //Page = 2;
            //var studentList = _studentService.Get(SearchStudentTextBox.Text, 2, PageSize);
            //var students = new List<StudentBaseViewModel>();
            //_mapper.Map(studentList.Students, students);
            //StudentDataGrid.ItemsSource = students;
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            //Page = 3;
            //var studentList = _studentService.Get(SearchStudentTextBox.Text, 3, PageSize);
            //var students = new List<StudentBaseViewModel>();
            //_mapper.Map(studentList.Students, students);
            //StudentDataGrid.ItemsSource = students;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            //Page++;
            //GetStudentAndBind();
        }

        private void GetStudentAndBind()
        {
            //var studentList = _studentService.Get(SearchStudentTextBox.Text, Page, PageSize);
            //var students = new List<StudentBaseViewModel>();
            //_mapper.Map(studentList.Students, students);
            //StudentDataGrid.ItemsSource = students;
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            //Page = 1;
            //var studentList = _studentService.Get(SearchStudentTextBox.Text, 1, PageSize);
            //var students = new List<StudentBaseViewModel>();
            //_mapper.Map(studentList.Students, students);
            //StudentDataGrid.ItemsSource = students;
        }


        private void rowDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            //if (messageBoxResult == MessageBoxResult.Yes)
            //{
            //    var row = (StudentBaseViewModel)StudentDataGrid.SelectedItems[0];
            //    _studentService.Delete(row.Id, "");
            //    GetStudentAndBind();
            //}
            //else
            //{
            //    System.Windows.MessageBox.Show("Delete operation Terminated");
            //}

        }
        private void OnKeyDownHandlerSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Page = 1;
                var timeTableList = _timeTableService.Get(1, PageSize);
                var timeTables = new List<TimeTableBaseViewModel>();
                _mapper.Map(timeTableList.TimeTables, timeTables);
                TimeTableDataGrid.ItemsSource = timeTables;
            }
        }

    }
}
