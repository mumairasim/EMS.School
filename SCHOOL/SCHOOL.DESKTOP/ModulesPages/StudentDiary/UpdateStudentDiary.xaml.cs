using SCHOOL.DTOs.ViewModels.StudentDiary;
using SCHOOL.Services.Infrastructure;
using System;
using System.Windows;
using DTOStudentDiary = SCHOOL.DTOs.DTOs.StudentDiary;

namespace SCHOOL.DESKTOP.ModulesPages.StudentDiary
{
    /// <summary>
    /// Interaction logic for UpdateStudentDiary.xaml
    /// </summary>
    public partial class UpdateStudentDiary : Window
    {
        private readonly IStudentDiaryService _studentDiaryService;
        private Guid _studentDiaryId;
        public UpdateStudentDiary(StudentDiaryBaseViewModel model, IStudentDiaryService studentDiaryService)
        {
            _studentDiaryService = studentDiaryService;
            InitializeComponent();
            FetchAndPopulateStudentDiary(model.Id);
            _studentDiaryId = model.Id;
        }

        private DTOStudentDiary GetFormData()
        {
            return new DTOStudentDiary
            {
                DiaryText = DairyText.Text,
                DairyDate = Convert.ToDateTime(DairyDate.Text)
            };
        }

        public void MapData(DTOStudentDiary model)
        {
            DairyText.Text = model.DiaryText;
            DairyDate.Text = model.DairyDate.ToString();
        }

        private void FetchAndPopulateStudentDiary(Guid id)
        {
            var studentDiary = _studentDiaryService.Get(id);
            MapData(studentDiary);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var studentDiaryUpdated = GetFormData();
            studentDiaryUpdated.Id = _studentDiaryId;
            _studentDiaryService.Update(studentDiaryUpdated);
        }
    }
}
