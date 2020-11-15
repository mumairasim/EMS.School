using AutoMapper;
using SCHOOL.DTOs.ViewModels.Course;
using SCHOOL.Services.Infrastructure;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SCHOOL.DESKTOP.ModulesPages.Course
{
    /// <summary>
    /// Interaction logic for CourseBase.xaml
    /// </summary>
    public partial class CourseBase : Page
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        private const int PageSize = 50;
        public int Page { get; set; }

        public CourseBase(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
            InitializeComponent();
            PreLoads();
        }
        public void PreLoads()
        {
            Page = 1;
            var courseList = _courseService.Get(1, PageSize);
            var courses = new List<CourseBaseViewModel>();
            _mapper.Map(courseList.Courses, courses);
            CourseDataGrid.ItemsSource = courses;
        }
        public void SearchCourses(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var courseList = _courseService.Get(SearchCourseTextBox.Text, 1, PageSize);
            var courses = new List<CourseBaseViewModel>();
            _mapper.Map(courseList.Courses, courses);
            CourseDataGrid.ItemsSource = courses;
        }

        public void rowEditButton_Click(object sender, RoutedEventArgs e)
        {
            var row = (CourseBaseViewModel)CourseDataGrid.SelectedItems[0];
            var updateCourse = new UpdateCourse(row, _courseService);
            updateCourse.ShowDialog();
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var courseList = _courseService.Get(SearchCourseTextBox.Text, 1, PageSize);
            var courses = new List<CourseBaseViewModel>();
            _mapper.Map(courseList.Courses, courses);
            CourseDataGrid.ItemsSource = courses;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1)
            {
                Page--;
            }
            var courseList = _courseService.Get(SearchCourseTextBox.Text, Page, PageSize);
            var courses = new List<CourseBaseViewModel>();
            _mapper.Map(courseList.Courses, courses);
            CourseDataGrid.ItemsSource = courses;
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            Page = 2;
            var courseList = _courseService.Get(SearchCourseTextBox.Text, 2, PageSize);
            var courses = new List<CourseBaseViewModel>();
            _mapper.Map(courseList.Courses, courses);
            CourseDataGrid.ItemsSource = courses;
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            Page = 3;
            var courseList = _courseService.Get(SearchCourseTextBox.Text, 3, PageSize);
            var courses = new List<CourseBaseViewModel>();
            _mapper.Map(courseList.Courses, courses);
            CourseDataGrid.ItemsSource = courses;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            Page++;
            GetCourseAndBind();
        }

        private void GetCourseAndBind()
        {
            var courseList = _courseService.Get(SearchCourseTextBox.Text, Page, PageSize);
            var courses = new List<CourseBaseViewModel>();
            _mapper.Map(courseList.Courses, courses);
            CourseDataGrid.ItemsSource = courses;
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var courseList = _courseService.Get(SearchCourseTextBox.Text, 1, PageSize);
            var courses = new List<CourseBaseViewModel>();
            _mapper.Map(courseList.Courses, courses);
            CourseDataGrid.ItemsSource = courses;
        }

        private void CourseDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rowDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var row = (CourseBaseViewModel)CourseDataGrid.SelectedItems[0];
                _courseService.Delete(row.Id);
                GetCourseAndBind();
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
                var courseList = _courseService.Get(SearchCourseTextBox.Text, 1, PageSize);
                var courses = new List<CourseBaseViewModel>();
                _mapper.Map(courseList.Courses, courses);
                CourseDataGrid.ItemsSource = courses;
            }
        }
    }
}
