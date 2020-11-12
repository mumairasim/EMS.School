using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoMapper;
using SCHOOL.DTOs.ViewModels.LessonPlan;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;

namespace SCHOOL.DESKTOP.ModulesPages.LessonPlan
{
    /// <summary>
    /// Interaction logic for LessonPlanBase.xaml
    /// </summary>
    public partial class LessonPlanBase : Page
    {
        private readonly ILessonPlanService _lessonPlanService;
        private readonly IMapper _mapper;
        private const int PageSize = 50;
        public int Page { get; set; }

        public LessonPlanBase(ILessonPlanService lessonPlanService, IMapper mapper)
        {
            _lessonPlanService = lessonPlanService;
            _mapper = mapper;
            InitializeComponent();
            PreLoads();
        }
        public void PreLoads()
        {
            Page = 1;
            var lessonPlanList = _lessonPlanService.Get(1, PageSize);
            var lessonPlans = new List<LessonPlanBaseViewModel>();
            _mapper.Map(lessonPlanList.LessonPlans, lessonPlans);
            LessonPlanDataGrid.ItemsSource = lessonPlans;
        }
        public void SearchLessonPlans(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var lessonPlanList = _lessonPlanService.Get(SearchLessonPlanTextBox.Text, 1, PageSize);
            var lessonPlans = new List<LessonPlanBaseViewModel>();
            _mapper.Map(lessonPlanList.LessonPlans, lessonPlans);
            LessonPlanDataGrid.ItemsSource = lessonPlans;
        }
        public void rowEditButton_Click(object sender, RoutedEventArgs e)
        {
            var row = (LessonPlanBaseViewModel)LessonPlanDataGrid.SelectedItems[0];
            var updateLessonPlan = new UpdateLessonPlan(row, _lessonPlanService);
            updateLessonPlan.ShowDialog();
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var lessonPlanList = _lessonPlanService.Get(SearchLessonPlanTextBox.Text, 1, PageSize);
            var lessonPlans = new List<LessonPlanBaseViewModel>();
            _mapper.Map(lessonPlanList.LessonPlans, lessonPlans);
            LessonPlanDataGrid.ItemsSource = lessonPlans;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1)
            {
                Page--;
            }
            var lessonPlanList = _lessonPlanService.Get(SearchLessonPlanTextBox.Text, Page, PageSize);
            var lessonPlans = new List<LessonPlanBaseViewModel>();
            _mapper.Map(lessonPlanList.LessonPlans, lessonPlans);
            LessonPlanDataGrid.ItemsSource = lessonPlans;
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            Page = 2;
            var lessonPlanList = _lessonPlanService.Get(SearchLessonPlanTextBox.Text, 2, PageSize);
            var lessonPlans = new List<LessonPlanBaseViewModel>();
            _mapper.Map(lessonPlanList.LessonPlans, lessonPlans);
            LessonPlanDataGrid.ItemsSource = lessonPlans;
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            Page = 3;
            var lessonPlanList = _lessonPlanService.Get(SearchLessonPlanTextBox.Text, 3, PageSize);
            var lessonPlans = new List<LessonPlanBaseViewModel>();
            _mapper.Map(lessonPlanList.LessonPlans, lessonPlans);
            LessonPlanDataGrid.ItemsSource = lessonPlans;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            Page++;
            GetLessonPlanAndBind();
        }

        private void GetLessonPlanAndBind()
        {
            var lessonPlanList = _lessonPlanService.Get(SearchLessonPlanTextBox.Text, Page, PageSize);
            var lessonPlans = new List<LessonPlanBaseViewModel>();
            _mapper.Map(lessonPlanList.LessonPlans, lessonPlans);
            LessonPlanDataGrid.ItemsSource = lessonPlans;
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var lessonPlanList = _lessonPlanService.Get(SearchLessonPlanTextBox.Text, 1, PageSize);
            var lessonPlans = new List<LessonPlanBaseViewModel>();
            _mapper.Map(lessonPlanList.LessonPlans, lessonPlans);
            LessonPlanDataGrid.ItemsSource = lessonPlans;
        }

        private void LessonPlanDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rowDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var row = (LessonPlanBaseViewModel)LessonPlanDataGrid.SelectedItems[0];
                _lessonPlanService.Delete(row.Id, "");
                GetLessonPlanAndBind();
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
                var lessonPlanList = _lessonPlanService.Get(SearchLessonPlanTextBox.Text, 1, PageSize);
                var lessonPlans = new List<LessonPlanBaseViewModel>();
                _mapper.Map(lessonPlanList.LessonPlans, lessonPlans);
                LessonPlanDataGrid.ItemsSource = lessonPlans;
            }
        }
    }
}
