using SCHOOL.DTOs.ViewModels.Course;
using SCHOOL.Services.Infrastructure;
using System;
using System.Windows;
using DTOCourse = SCHOOL.DTOs.DTOs.Course;

namespace SCHOOL.DESKTOP.ModulesPages.Course
{
    /// <summary>
    /// Interaction logic for UpdateCourse.xaml
    /// </summary>
    public partial class UpdateCourse : Window
    {
        private readonly ICourseService _courseService;
        private Guid _courseId;
        public UpdateCourse(CourseBaseViewModel model, ICourseService courseService)
        {
            _courseService = courseService;
            InitializeComponent();
            FetchAndPopulateCourse(model.Id);
            _courseId = model.Id;
        }

        public void MapData(DTOCourse model)
        {
            CourseName.Text = model.CourseName;
            CourseCode.Text = model.CourseCode;
        }

        private DTOCourse GetFormData()
        {
            DTOCourse model = new DTOCourse
            {
                CourseCode = CourseCode.Text,
                CourseName = CourseName.Text
            };
            return model;
        }

        private void FetchAndPopulateCourse(Guid id)
        {
            var course = _courseService.Get(id);
            MapData(course);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var courseUpdated = GetFormData();
            courseUpdated.Id = _courseId;
            _courseService.Update(courseUpdated);
        }
    }
}
