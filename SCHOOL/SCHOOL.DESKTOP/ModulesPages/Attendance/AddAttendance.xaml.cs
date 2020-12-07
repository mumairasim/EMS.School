using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using AutoMapper;
using SCHOOL.DTOs.ViewModels.Attendance;
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
        public ObservableCollection<AttendanceBaseViewModel> AttendanceStudents { get; set; }
        public ObservableCollection<string> AttendanceStatusList { get; set; }
        public AddAttendance(IClassService classService, IStudentService studentService, IMapper mapper)
        {
            _classService = classService;
            _studentService = studentService;
            _mapper = mapper;
            InitializeComponent();
            PreLoads();
            GetClasses();

        }

        private void GetClasses()
        {
            var classesList = _classService.Get();
            ClassName.ItemsSource = classesList;
            ClassName.SelectedItem = ClassName.Items[0];
        }
        private void PreLoads()
        {
            //if (AttendanceStatusList == null)
            //    AttendanceStatusList = new ObservableCollection<AttendanceStatusViewModel>();
            //AttendanceStatusList.Add(
            //    new AttendanceStatusViewModel
            //    {
            //        Id = Guid.NewGuid(),
            //        Status = "Present"
            //    });
            //AttendanceStatusList.Add(
            //    new AttendanceStatusViewModel
            //    {
            //        Id = Guid.NewGuid(),
            //        Status = "Absent"
            //    });
            //AttendanceStatusList.Add(
            //    new AttendanceStatusViewModel
            //    {
            //        Id = Guid.NewGuid(),
            //        Status = "Leave"
            //    });


            //if (AttendanceStatusList == null)
            //    AttendanceStatusList = new ObservableCollection<string>();
            //AttendanceStatusList.Add("Present");
            //AttendanceStatusList.Add("Absent");
            //AttendanceStatusList.Add("Leave");

        }

        private void GetStudents_Click(object sender, RoutedEventArgs e)
        {
            var classObj = (DTOClass)ClassName.SelectedItem;
            var studentList = _studentService.GetByClass(classObj.Id);
            var students = new List<StudentBaseViewModel>();
            var attendanceStudents = new List<AttendanceBaseViewModel>();
            _mapper.Map(studentList.Students, students);
            _mapper.Map(students, attendanceStudents);




            foreach (var item in attendanceStudents)
            {
                if (AttendanceStudents == null)
                {
                    AttendanceStudents = new ObservableCollection<AttendanceBaseViewModel>();
                }
                item.AttendanceStatus = "Present";
                AttendanceStudents.Add(item);
            }

            AttendanceDataGrid.ItemsSource = AttendanceStudents;
        }

        private void MarkAttendance_Click(object sender, RoutedEventArgs e)
        {
            CompileDataFromDataGrid();
        }

        private void CompileDataFromDataGrid()
        {
            var row = (DataGridRow)AttendanceDataGrid.ItemContainerGenerator.ContainerFromIndex(0);
            var row1 = AttendanceDataGrid.Items[0] as DataRowView;
            if (row1 != null) MessageBox.Show(row1["RegNumber"].ToString());
            var rows = GetDataGridRows(AttendanceDataGrid);
        }
        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
    }
}
