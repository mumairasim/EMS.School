using AutoMapper;
using SCHOOL.Services.Infrastructure;
using System.Windows;
using System.Windows.Controls;
using DTOCourse = SCHOOL.DTOs.DTOs.Course;


namespace SCHOOL.DESKTOP.ModulesPages.Course
{

    public partial class AddCourse : Page
    {
        private readonly ICourseService _courseService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Interaction logic for AddCourse.xaml
        /// </summary>
        public AddCourse(ICourseService courseService, IClassService classService, IMapper mapper)
        {
            _courseService = courseService;
            _classService = classService;
            _mapper = mapper;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _courseService.Create(GetFormData());
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

    }
}
