using System.Collections.Generic;
using System.Windows;
using AutoMapper;
using SCHOOL.DESKTOP.ModulesPages.Attendance;
using SCHOOL.DESKTOP.ModulesPages.Dashboard;
using SCHOOL.DESKTOP.ModulesPages.Student;
using SCHOOL.DESKTOP.ModulesPages.TimeTable;
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
        private readonly ICourseService _courseService;
        private readonly IEmployeeService _employeeService;
        private readonly ITimeTableService _timeTableService;
        private readonly StudentBase _studentBase;
        private readonly TimeTableBase _timeTableBase;
        private readonly Dashboard _dashboard;
        private readonly AddStudent _addStudent;
        private readonly AddTimeTable _addTimeTable;
        private readonly AddAttendance _addAttendance;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public List<Class> ClassList { get; set; } = new List<Class>();
        public MainWindow(IClassService classService, IStudentService studentService, IMapper mapper, ICourseService courseService, IEmployeeService employeeService, ITimeTableService timeTableService)
        {
            _classService = classService;
            _studentService = studentService;
            _mapper = mapper;
            _courseService = courseService;
            _employeeService = employeeService;
            _timeTableService = timeTableService;
            _dashboard = new Dashboard();
            _studentBase = new StudentBase(_studentService, _mapper);
            _timeTableBase = new TimeTableBase(_mapper, _timeTableService);
            _addStudent = new AddStudent(_studentService, _classService, _mapper);
            _addTimeTable = new AddTimeTable(classService, courseService, employeeService, timeTableService);
            _addAttendance = new AddAttendance(classService, studentService, mapper);
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
        private void TimeTableTab_GotFocus(object sender, RoutedEventArgs e)
        {
            TimeTableBase.Content = _timeTableBase;
        }

        private void DashboardTab_GotFocus(object sender, RoutedEventArgs e)
        {
            DashboardPage.Content = _dashboard;
        }
        private void AddStudentTabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            AddStudent.Content = _addStudent;
        }
        private void AddTimeTableTabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            AddTimeTable.Content = _addTimeTable;
        }

        private void AttendanceTab_GotFocus(object sender, RoutedEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void MarkTimeTableTabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            MarkAttendance.Content = _addAttendance;
        }
    }

}

