using System.Collections.Generic;
using System.Windows;
using AutoMapper;
using SCHOOL.DESKTOP.ModulesPages.Dashboard;
using SCHOOL.DESKTOP.ModulesPages.Student;
using SCHOOL.DTOs.DTOs;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;

namespace SCHOOL.DESKTOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IClassService _classService;
        private readonly StudentBase _studentBase;
        private readonly Dashboard _dashboard;
        private readonly AddStudent _addStudent;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public List<Class> ClassList { get; set; } = new List<Class>();
        public MainWindow(IClassService classService, IStudentService studentService, IMapper mapper)
        {
            _classService = classService;
            _studentService = studentService;
            _mapper = mapper;
            _dashboard = new Dashboard();
            _studentBase = new StudentBase(_studentService, _mapper);
            _addStudent = new AddStudent(_studentService, _classService, _mapper);
            InitializeComponent();
            DashboardPage.Content = _dashboard;
        }


        private void ClassTab_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var classList = _classService.Get();
            ClassDatagrid.ItemsSource = classList;
        }


        private void getClass_Click(object sender, RoutedEventArgs e)
        {
            var classList = _classService.Get();
            ClassDatagrid.ItemsSource = classList;
        }

        private void StudentTab_GotFocus(object sender, RoutedEventArgs e)
        {
            StudentBase.Content = _studentBase;
        }
        private void DashboardTab_GotFocus(object sender, RoutedEventArgs e)
        {
            DashboardPage.Content = _dashboard;
        }
        private void AddStudentTabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            AddStudent.Content = _addStudent;
        }
    }

}

