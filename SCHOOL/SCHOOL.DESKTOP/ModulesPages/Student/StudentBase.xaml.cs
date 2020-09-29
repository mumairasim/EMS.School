using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        public StudentBase(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
            InitializeComponent();
            PreLoads();
        }
        public void PreLoads()
        {
            var studentList = _studentService.Get(1, 20);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }
        public void SearchStudents(object sender, RoutedEventArgs e)
        {
            var studentList = _studentService.Get(searchStudentTextBox.Text, 1, 20);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            StudentDataGrid.ItemsSource = students;
        }
    }
}
