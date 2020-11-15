using AutoMapper;
using SCHOOL.Services.Infrastructure;
using System.Windows;
using System.Windows.Controls;
using DTOStudentDiary = SCHOOL.DTOs.DTOs.StudentDiary;

namespace SCHOOL.DESKTOP.ModulesPages.StudentDiary
{

    public partial class AddStudentDiary : Page
    {
        private readonly IStudentDiaryService _studentDiaryService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Interaction logic for AddStudentDiary.xaml
        /// </summary>
        public AddStudentDiary(IStudentDiaryService studentDiaryService, IClassService classService, IMapper mapper)
        {
            _studentDiaryService = studentDiaryService;
            _classService = classService;
            _mapper = mapper;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _studentDiaryService.Create(GetFormData());
        }

       
        private DTOStudentDiary GetFormData()
        {
            return new DTOStudentDiary
            {
                
            };
        }
    }
}
