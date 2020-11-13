using SCHOOL.DTOs.ViewModels.TeacherDiary;
using SCHOOL.Services.Infrastructure;
using System;
using System.Windows;
using DTOTeacherDiary = SCHOOL.DTOs.DTOs.TeacherDiary;

namespace SCHOOL.DESKTOP.ModulesPages.TeacherDiary
{
    /// <summary>
    /// Interaction logic for UpdateTeacherDiary.xaml
    /// </summary>
    public partial class UpdateTeacherDiary : Window
    {
        private readonly ITeacherDiaryService _teacherDiaryService;
        private Guid _teacherDiaryId;
        public UpdateTeacherDiary(TeacherDiaryBaseViewModel model, ITeacherDiaryService teacherDiaryService)
        {
            _teacherDiaryService = teacherDiaryService;
            InitializeComponent();
            FetchAndPopulateTeacherDiary(model.Id);
            _teacherDiaryId = model.Id;
        }

        public void MapData(DTOTeacherDiary model)
        {
            DairyText.Text = model.DairyText;
            DairyDate.Text = model.DairyDate.ToString();
        }

        private DTOTeacherDiary GetFormData()
        {
            return new DTOTeacherDiary
            {
                DairyText = DairyText.Text,
                DairyDate = Convert.ToDateTime(DairyDate.Text)
            };
        }

        private void FetchAndPopulateTeacherDiary(Guid id)
        {
            var teacherDiary = _teacherDiaryService.Get(id);
            MapData(teacherDiary);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var teacherDiaryUpdated = GetFormData();
            teacherDiaryUpdated.Id = _teacherDiaryId;
            _teacherDiaryService.Update(teacherDiaryUpdated);
        }
    }
}
