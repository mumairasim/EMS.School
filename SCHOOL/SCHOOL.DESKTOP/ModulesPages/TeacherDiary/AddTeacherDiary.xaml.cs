using AutoMapper;
using SCHOOL.Services.Infrastructure;
using System;
using System.Windows;
using System.Windows.Controls;
using DTOTeacherDiary = SCHOOL.DTOs.DTOs.TeacherDiary;

namespace SCHOOL.DESKTOP.ModulesPages.TeacherDiary
{

    public partial class AddTeacherDiary : Page
    {
        private readonly ITeacherDiaryService _teacherDiaryService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Interaction logic for AddTeacherDiary.xaml
        /// </summary>
        public AddTeacherDiary(ITeacherDiaryService teacherDiaryService, IClassService classService, IMapper mapper)
        {
            _teacherDiaryService = teacherDiaryService;
            _classService = classService;
            _mapper = mapper;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _teacherDiaryService.Create(GetFormData());
        }

        private DTOTeacherDiary GetFormData()
        {
            return new DTOTeacherDiary
            {
                DairyText = DairyText.Text,
                DairyDate = Convert.ToDateTime(DairyDate.Text)
            };
        }
    }
}
