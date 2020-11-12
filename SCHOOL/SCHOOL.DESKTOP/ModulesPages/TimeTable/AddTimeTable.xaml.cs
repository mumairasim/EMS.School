﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.Enums;
using SCHOOL.Services.Infrastructure;
using DTOTimeTable = SCHOOL.DTOs.DTOs.TimeTable;
using DTOTimeTableDetail = SCHOOL.DTOs.DTOs.TimeTableDetail;
using DTOPeriod = SCHOOL.DTOs.DTOs.Period;
using DTOCourse = SCHOOL.DTOs.DTOs.Course;
using DTOEmployee = SCHOOL.DTOs.DTOs.Employee;
using DTOClass = SCHOOL.DTOs.DTOs.Class;

namespace SCHOOL.DESKTOP.ModulesPages.TimeTable
{
    /// <summary>
    /// Interaction logic for AddTimeTable.xaml
    /// </summary>
    public partial class AddTimeTable
    {
        private readonly IClassService _classService;
        private readonly ICourseService _courseService;
        private readonly IEmployeeService _employeeService;
        private readonly ITimeTableService _timeTableService;
        public AddTimeTable(IClassService classService, ICourseService courseService, IEmployeeService employeeService, ITimeTableService timeTableService)
        {
            _classService = classService;
            _courseService = courseService;
            _employeeService = employeeService;
            _timeTableService = timeTableService;
            InitializeComponent();
            PageInitialization();
        }

        public int MondayPeriod { get; set; }
        public int TuesdayPeriod { get; set; }
        public int WednesdayPeriod { get; set; }
        public int ThursdayPeriod { get; set; }
        public int FridayPeriod { get; set; }
        public int SaturdayPeriod { get; set; }
        public int SundayPeriod { get; set; }
        public List<DTOTimeTableDetail> TimeTableDetails { get; set; }

        private void PageInitialization()
        {
            TimeTableDetails = new List<DTOTimeTableDetail>();
            ClassName.SelectedIndex = 0;



            TimeTableGrid.RowDefinitions.Add(new RowDefinition());
            TimeTableGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < 7; i++)
            {
                TimeTableGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(MinHeight = 70)
                });
            }
            for (int i = 0; i < 25; i++)
            {
                TimeTableGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(MinWidth = 150)
                });
            }


            var dynamicLabel = new Label
            {
                Content = "Days",
                FontWeight = FontWeights.Bold,
                FontSize = 20
            };
            Grid.SetRow(dynamicLabel, 0);
            Grid.SetColumn(dynamicLabel, 0);
            TimeTableGrid.Children.Add(dynamicLabel);
            MondayPeriod = 0;
            TuesdayPeriod = 0;
            WednesdayPeriod = 0;
            ThursdayPeriod = 0;
            FridayPeriod = 0;
            SaturdayPeriod = 0;
            SundayPeriod = 0;

            GetClasses();
            GetCourses();
            GetTeachers();


            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Monday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Tuesday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Wednesday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Thursday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Friday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Saturday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Sunday.ToString() });
            Day.SelectedItem = Day.Items[0];

        }
        private void Monday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Monday);
            PrepareTimeTableDetailObject(DaysOfWeek.Monday);
        }

        private void Tuesday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Tuesday);
            PrepareTimeTableDetailObject(DaysOfWeek.Tuesday);
        }

        private void Wednesday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Wednesday);
            PrepareTimeTableDetailObject(DaysOfWeek.Wednesday);
        }

        private void Thursday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Thursday);
            PrepareTimeTableDetailObject(DaysOfWeek.Thursday);
        }

        private void Friday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Friday);
            PrepareTimeTableDetailObject(DaysOfWeek.Friday);
        }

        private void Saturday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Saturday);
            PrepareTimeTableDetailObject(DaysOfWeek.Saturday);
        }

        private void Sunday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Sunday);
            PrepareTimeTableDetailObject(DaysOfWeek.Sunday);
        }

        private void Monday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Monday);
        }
        private void Tuesday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Tuesday);
        }
        private void Wednesday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Wednesday);
        }
        private void Thursday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Thursday);
        }
        private void Friday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Friday);
        }
        private void Saturday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Saturday);
        }
        private void Sunday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Sunday);
        }
        private void AddPeriod_Click(object sender, RoutedEventArgs e)
        {
            int maxPeriods = 20;
            ComboBoxItem typeItem = (ComboBoxItem)Day.SelectedItem;
            string selectedDay = typeItem.Content.ToString();
            var day = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), selectedDay);
            if (day == DaysOfWeek.Monday)
            {
                if (MondayPeriod < maxPeriods)
                {
                    MondayPeriod++;
                    PrepareStringAndInsertColumn(day, MondayPeriod);
                    AddTimeTablePeriod(DaysOfWeek.Monday);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Tuesday)
            {
                if (TuesdayPeriod < maxPeriods)
                {
                    TuesdayPeriod++;
                    PrepareStringAndInsertColumn(day, TuesdayPeriod);
                    AddTimeTablePeriod(DaysOfWeek.Tuesday);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Wednesday)
            {
                if (WednesdayPeriod < maxPeriods)
                {
                    WednesdayPeriod++;
                    PrepareStringAndInsertColumn(day, WednesdayPeriod);
                    AddTimeTablePeriod(DaysOfWeek.Wednesday);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Thursday)
            {
                if (ThursdayPeriod < maxPeriods)
                {
                    ThursdayPeriod++;
                    PrepareStringAndInsertColumn(day, ThursdayPeriod);
                    AddTimeTablePeriod(DaysOfWeek.Thursday);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Friday)
            {
                if (FridayPeriod < maxPeriods)
                {
                    FridayPeriod++;
                    PrepareStringAndInsertColumn(day, FridayPeriod);
                    AddTimeTablePeriod(DaysOfWeek.Friday);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Saturday)
            {
                if (SaturdayPeriod < maxPeriods)
                {
                    SaturdayPeriod++;
                    PrepareStringAndInsertColumn(day, SaturdayPeriod);
                    AddTimeTablePeriod(DaysOfWeek.Saturday);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Sunday)
            {
                if (SundayPeriod < maxPeriods)
                {
                    SundayPeriod++;
                    PrepareStringAndInsertColumn(day, SundayPeriod);
                    AddTimeTablePeriod(DaysOfWeek.Sunday);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddRow(DaysOfWeek day)
        {
            var dynamicLabel = new Label
            {
                Name = day + "_Label",
                Content = day.ToString(),
                FontWeight = FontWeights.Bold
            };
            Grid.SetRow(dynamicLabel, (int)day);
            Grid.SetColumn(dynamicLabel, 0);
            TimeTableGrid.Children.Add(dynamicLabel);

        }
        private void RemoveRow(DaysOfWeek day)
        {
            Label lbl = (Label)LogicalTreeHelper.FindLogicalNode(TimeTableGrid, day + "_Label");
            TimeTableGrid.Children.Remove(lbl);
        }
        private void AddColumn(DaysOfWeek day, string text, int period)
        {
            var dynamicLabel = new Label
            {
                Name = day + "_" + period + "_Label",
                Content = text,
                Margin = new Thickness(5, 5, 5, 5),
                BorderBrush = new SolidColorBrush(Colors.DarkGray),
                BorderThickness = new Thickness(1)
            };
            Grid.SetRow(dynamicLabel, (int)day);
            Grid.SetColumn(dynamicLabel, period);
            TimeTableGrid.Children.Add(dynamicLabel);

        }

        private void PrepareStringAndInsertColumn(DaysOfWeek day, int period)
        {
            var subject = (DTOCourse)SubjectName.SelectedItem;
            string subjectName = subject.CourseName;

            var typeItemTeacher = (DTOEmployee)TeacherName.SelectedItem;
            string teacherName = typeItemTeacher.Person.FirstName + " " + typeItemTeacher.Person.LastName;

            var startTime = StartTime.Text;
            var endTime = EndTime.Text;

            var query = new StringBuilder();
            query.Append(subjectName + "\n");
            query.Append(teacherName + "\n");
            query.Append(startTime + " - " + endTime);


            AddColumn(day, query.ToString(), period);
        }

        private void PrepareTimeTableDetailObject(DaysOfWeek day)
        {
            if (!IfDayAlreadyExist(day))
            {
                var timeTableDetail = new DTOTimeTableDetail
                {
                    Day = day.ToString(),
                    Periods = new List<Period>()
                };
                TimeTableDetails.Add(timeTableDetail);
            }
        }
        private void AddTimeTablePeriod(DaysOfWeek day)
        {
            foreach (var ttD in TimeTableDetails)
            {
                if (ttD.Day.Equals(day.ToString()))
                {
                    var startTime = ParseTime(StartTime.Text);
                    var endTime = ParseTime(EndTime.Text);
                    if (startTime == null)
                    {
                        MessageBox.Show("Wrong format for Start time", "Wrong Format", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (endTime == null)
                    {
                        MessageBox.Show("Wrong format for End time", "Wrong Format", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    var subject = (DTOCourse)SubjectName.SelectedItem;
                    var employee = (DTOEmployee)TeacherName.SelectedItem;
                    var period = new DTOPeriod
                    {
                        StartTime = startTime,
                        EndTime = endTime,
                        CourseId = subject.Id,
                        TeacherId = employee.Id
                    };
                    ttD.Periods.Add(period);
                    break;
                }
            }
        }
        private DTOTimeTable PrepareTimeTableObject()
        {
            var classObj = (DTOClass)ClassName.SelectedItem;
            var timeTable = new DTOTimeTable
            {
                ClassId = classObj.Id,
                TimeTableName = TimeTableName.Text,
                TimeTableDetails = TimeTableDetails
            };
            return timeTable;
        }
        private bool IfDayAlreadyExist(DaysOfWeek day)
        {
            foreach (var ttD in TimeTableDetails)
            {
                if (ttD.Day.Equals(day.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var timeTable = PrepareTimeTableObject();
            var result = _timeTableService.Create(timeTable);
            if (result.StatusCode == "200")
            {
                MessageBox.Show("Time table saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GetCourses()
        {
            var courseList = _courseService.GetAll();
            SubjectName.ItemsSource = courseList;
            SubjectName.SelectedItem = SubjectName.Items[0];

        }
        private void GetClasses()
        {
            var classesList = _classService.Get();
            ClassName.ItemsSource = classesList;
            ClassName.SelectedItem = ClassName.Items[0];

        }
        private void GetTeachers()
        {
            var employeeList = _employeeService.GetTeachers();
            TeacherName.ItemsSource = employeeList;
            TeacherName.SelectedItem = TeacherName.Items[0];

        }
        public static TimeSpan? ParseTime(string input)
        {
            var ok = DateTime.TryParseExact(input, @"h:mm tt", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out var output);
            if (ok)
            {
                return output.Subtract(output.Date);
            }

            return null;
        }

    }


}
