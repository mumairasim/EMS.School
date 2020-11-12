using SCHOOL.DTOs.ViewModels.LessonPlan;
using SCHOOL.Services.Infrastructure;
using System;
using System.Windows;
using DTOLessonPlan = SCHOOL.DTOs.DTOs.LessonPlan;

namespace SCHOOL.DESKTOP.ModulesPages.LessonPlan
{
    /// <summary>
    /// Interaction logic for UpdateLessonPlan.xaml
    /// </summary>
    public partial class UpdateLessonPlan : Window
    {
        private readonly ILessonPlanService _lessonPlanService;
        private Guid _lessonPlanId;
        public UpdateLessonPlan(LessonPlanBaseViewModel model, ILessonPlanService lessonPlanService)
        {
            _lessonPlanService = lessonPlanService;
            InitializeComponent();
            FetchAndPopulateLessonPlan(model.Id);
            _lessonPlanId = model.Id;
        }


        public void MapData(DTOLessonPlan model)
        {
            Name.Text = model.Name;
            Text.Text = model.Text;
            FromDate.Text = model.FromDate.ToString();
            ToDate.Text = model.Text.ToString();
        }


        private DTOLessonPlan GetFormData()
        {
            DTOLessonPlan model = new DTOLessonPlan
            {
                Text = Text.Text,
                FromDate = Convert.ToDateTime(FromDate.Text),
                ToDate = Convert.ToDateTime(ToDate.Text),
                Name = Name.Text,
            };
            return model;
        }


        private void FetchAndPopulateLessonPlan(Guid id)
        {
            var lessonPlan = _lessonPlanService.Get(id);
            MapData(lessonPlan);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var lessonPlanUpdated = GetFormData();
            lessonPlanUpdated.Id = _lessonPlanId;
            _lessonPlanService.Update(lessonPlanUpdated);
        }
    }
}
