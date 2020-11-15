using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AutoMapper;
using SCHOOL.DTOs.ViewModels.Student;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;
using DTOClass = SCHOOL.DTOs.DTOs.Class;

namespace SCHOOL.DESKTOP.ModulesPages.Attendance
{
    /// <summary>
    /// Interaction logic for AddAttendance.xaml
    /// </summary>
    public partial class AddAttendance : Page
    {
        private readonly IClassService _classService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public AddAttendance(IClassService classService, IStudentService studentService, IMapper mapper)
        {
            _classService = classService;
            _studentService = studentService;
            _mapper = mapper;
            InitializeComponent();
            GetClasses();
        }

        private void GetClasses()
        {
            var classesList = _classService.Get();
            ClassName.ItemsSource = classesList;
            ClassName.SelectedItem = ClassName.Items[0];

        }


        private void GetStudents_Click(object sender, RoutedEventArgs e)
        {
            var classObj = (DTOClass)ClassName.SelectedItem;
            var studentList = _studentService.GetByClass(classObj.Id);
            var students = new List<StudentBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            AttendanceDataGrid.ItemsSource = students;
        }
    }
}
