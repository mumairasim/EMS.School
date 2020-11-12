using System.Collections.Generic;
using System.Windows;
using AutoMapper;
using SCHOOL.DESKTOP.ModulesPages.Dashboard;
using SCHOOL.DESKTOP.ModulesPages.Employee;
using SCHOOL.DESKTOP.ModulesPages.Student;
using SCHOOL.DESKTOP.ModulesPages.TimeTable;
using SCHOOL.DESKTOP.ModulesPages.Worksheet;
using SCHOOL.DESKTOP.ModulesPages.LessonPlan;
using SCHOOL.DESKTOP.ModulesPages;
using SCHOOL.DTOs.DTOs;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;
using SCHOOL.DESKTOP.ModulesPages.Course;

namespace SCHOOL.DESKTOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IClassService _classService;
        private readonly StudentBase _studentBase;
        private readonly TimeTableBase _timeTableBase;
        private readonly Dashboard _dashboard;
        private readonly AddStudent _addStudent;
        private readonly AddTimeTable _addTimeTable;
        private readonly IStudentService _studentService;
        private readonly IEmployeeService _employeeService;
        private readonly ILessonPlanService _lessonPlanService;

        private readonly IWorksheetService _worksheetService;
        private readonly ICourseService _courseService;

        private readonly AddEmployee _addEmployee;
        private readonly EmployeeBase _employeeBase;

        private readonly AddWorksheet _addWorksheet;
        private readonly WorksheetBase _worksheetBase;

        private readonly AddLessonPlan _addLessonPlan;
        private readonly LessonPlanBase _lessonPlanBase;

        private readonly AddCourse _addCourse;
        private readonly CourseBase _courseBase;


        private readonly IMapper _mapper;
        public List<Class> ClassList { get; set; } = new List<Class>();
        public MainWindow(IClassService classService, IStudentService studentService, IEmployeeService employeeService,
            IWorksheetService worksheetService,
            ILessonPlanService lessonPlanService,
            ICourseService courseService,
            , ITimeTableService timeTableService,
            IMapper mapper)
        {
            _classService = classService;
            _studentService = studentService;
            _employeeService = employeeService;
            _worksheetService = worksheetService;
            _lessonPlanService = lessonPlanService;
            _courseService = courseService;

            _mapper = mapper;
            _courseService = courseService;
            _employeeService = employeeService;
            _timeTableService = timeTableService;
            _dashboard = new Dashboard();


            _studentBase = new StudentBase(_studentService, _mapper);
            _timeTableBase = new TimeTableBase(_mapper, _timeTableService);
            _addStudent = new AddStudent(_studentService, _classService, _mapper);

            _employeeBase = new EmployeeBase(_employeeService, _mapper);
            _addEmployee = new AddEmployee(_employeeService, _mapper);

            _worksheetBase = new WorksheetBase(_worksheetService, _mapper);
            _addWorksheet = new AddWorksheet(_worksheetService, _classService, _mapper);

            _lessonPlanBase = new LessonPlanBase(_lessonPlanService, _mapper);
            _addLessonPlan = new AddLessonPlan(_lessonPlanService, _classService, _mapper);

            _courseBase = new CourseBase(_courseService, _mapper);
            _addCourse = new AddCourse(_courseService, _classService, _mapper);

            _addTimeTable = new AddTimeTable(classService, courseService, employeeService, timeTableService);
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


        private void DashboardTab_GotFocus(object sender, RoutedEventArgs e)
        {
            DashboardPage.Content = _dashboard;
        }
        private void AddStudentTabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            AddStudent.Content = _addStudent;
        }
        private void StudentTab_GotFocus(object sender, RoutedEventArgs e)
        {
            StudentBase.Content = _studentBase;
        }

        private void AddEmployeeTabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            AddEmployee.Content = _addEmployee;
        }
        private void EmployeeTab_GotFocus(object sender, RoutedEventArgs e)
        {
            EmployeeBase.Content = _employeeBase;
        }

        private void AddWorksheetTabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            AddWorksheet.Content = _addWorksheet;
        }
        private void WorksheetTab_GotFocus(object sender, RoutedEventArgs e)
        {
            WorksheetBase.Content = _worksheetBase;
        }
        //
        private void AddLessonPlanTabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            AddLessonPlan.Content = _addLessonPlan;
        }
        private void LessonPlanTab_GotFocus(object sender, RoutedEventArgs e)
        {
            LessonPlanBase.Content = _lessonPlanBase;
        }

        //
        private void AddCourseTabItem_GotFocus(object sender, RoutedEventArgs e)
        private void TimeTableTab_GotFocus(object sender, RoutedEventArgs e)
        {
            TimeTableBase.Content = _timeTableBase;
        }

        private void DashboardTab_GotFocus(object sender, RoutedEventArgs e)
        {
            AddCourse.Content = _addCourse;
        }
        private void CourseTab_GotFocus(object sender, RoutedEventArgs e)
        {
            CourseBase.Content = _courseBase;
        }
        private void AddTimeTableTabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            AddTimeTable.Content = _addTimeTable;
        }
    }

}

