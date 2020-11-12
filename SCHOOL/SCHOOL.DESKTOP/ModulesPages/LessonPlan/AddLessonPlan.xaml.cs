using AutoMapper;
using SCHOOL.Services.Infrastructure;
using System;
using System.Windows;
using System.Windows.Controls;
using DTOLessonPlan = SCHOOL.DTOs.DTOs.LessonPlan;

namespace SCHOOL.DESKTOP.ModulesPages.LessonPlan
{

    public partial class AddLessonPlan : Page
    {
        private readonly ILessonPlanService _lessonPlanService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Interaction logic for AddLessonPlan.xaml
        /// </summary>
        public AddLessonPlan(ILessonPlanService lessonPlanService, IClassService classService, IMapper mapper)
        {
            _lessonPlanService = lessonPlanService;
            _classService = classService;
            _mapper = mapper;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _lessonPlanService.Create(GetFormData());
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
    }
}
