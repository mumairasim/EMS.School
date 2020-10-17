using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoMapper;
using SCHOOL.DTOs.ViewModels.Student;
using SCHOOL.SERVICES.Infrastructure;

namespace SCHOOL.DESKTOP.ModulesPages.Student
{
    /// <summary>
    /// Interaction logic for StudentBase.xaml
    /// </summary>
    public partial class StudentBase : Page
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private const int PageSize = 50;
        public int Page { get; set; }

        public StudentBase(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
            InitializeComponent();
            PreLoads();
        }
        public void PreLoads()
        {
            Page = 1;
            var studentList = _studentService.Get(1, PageSize);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }
        public void SearchStudents(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var studentList = _studentService.Get(SearchStudentTextBox.Text, 1, PageSize);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }
        public void rowEditButton_Click(object sender, RoutedEventArgs e)
        {
            var row = (StudentBaseViewModel)StudentDataGrid.SelectedItems[0];
            var updateStudent = new UpdateStudent(row, _studentService);
            updateStudent.ShowDialog();
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var studentList = _studentService.Get(SearchStudentTextBox.Text, 1, PageSize);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1)
            {
                Page--;
            }
            var studentList = _studentService.Get(SearchStudentTextBox.Text, Page, PageSize);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            Page = 2;
            var studentList = _studentService.Get(SearchStudentTextBox.Text, 2, PageSize);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            Page = 3;
            var studentList = _studentService.Get(SearchStudentTextBox.Text, 3, PageSize);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            Page++;
            GetStudentAndBind();
        }

        private void GetStudentAndBind()
        {
            var studentList = _studentService.Get(SearchStudentTextBox.Text, Page, PageSize);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var studentList = _studentService.Get(SearchStudentTextBox.Text, 1, PageSize);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }

        private void StudentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rowDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var row = (StudentBaseViewModel)StudentDataGrid.SelectedItems[0];
                _studentService.Delete(row.Id, "");
                GetStudentAndBind();
            }
            else
            {
                System.Windows.MessageBox.Show("Delete operation Terminated");
            }

        }
        private void OnKeyDownHandlerSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Page = 1;
                var studentList = _studentService.Get(SearchStudentTextBox.Text, 1, PageSize);
                var students = new List<StudentBaseViewModel>();
                _mapper.Map(studentList.Students, students);
                StudentDataGrid.ItemsSource = students;
            }
        }
    }
}
