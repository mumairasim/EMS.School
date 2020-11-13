using AutoMapper;
using SCHOOL.DTOs.ViewModels.TeacherDiary;
using SCHOOL.Services.Infrastructure;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SCHOOL.DESKTOP.ModulesPages.TeacherDiary
{
    /// <summary>
    /// Interaction logic for TeacherDiaryBase.xaml
    /// </summary>
    public partial class TeacherDiaryBase : Page
    {
        private readonly ITeacherDiaryService _teacherDiaryService;
        private readonly IMapper _mapper;
        private const int PageSize = 50;
        public int Page { get; set; }

        public TeacherDiaryBase(ITeacherDiaryService teacherDiaryService, IMapper mapper)
        {
            _teacherDiaryService = teacherDiaryService;
            _mapper = mapper;
            InitializeComponent();
            PreLoads();
        }
        public void PreLoads()
        {
            Page = 1;
            var teacherDiaryList = _teacherDiaryService.Get(1, PageSize);
            var teacherDiarys = new List<TeacherDiaryBaseViewModel>();
            _mapper.Map(teacherDiaryList.TeacherDiaries, teacherDiarys);
            TeacherDiaryDataGrid.ItemsSource = teacherDiarys;
        }
        public void SearchTeacherDiaries(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var teacherDiaryList = _teacherDiaryService.Get(SearchTeacherDiaryTextBox.Text, 1, PageSize);
            var teacherDiarys = new List<TeacherDiaryBaseViewModel>();
            _mapper.Map(teacherDiaryList.TeacherDiaries, teacherDiarys);
            TeacherDiaryDataGrid.ItemsSource = teacherDiarys;
        }
        public void rowEditButton_Click(object sender, RoutedEventArgs e)
        {
            var row = (TeacherDiaryBaseViewModel)TeacherDiaryDataGrid.SelectedItems[0];
            var updateTeacherDiary = new UpdateTeacherDiary(row, _teacherDiaryService);
            updateTeacherDiary.ShowDialog();
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var teacherDiaryList = _teacherDiaryService.Get(SearchTeacherDiaryTextBox.Text, 1, PageSize);
            var teacherDiarys = new List<TeacherDiaryBaseViewModel>();
            _mapper.Map(teacherDiaryList.TeacherDiaries, teacherDiarys);
            TeacherDiaryDataGrid.ItemsSource = teacherDiarys;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1)
            {
                Page--;
            }
            var teacherDiaryList = _teacherDiaryService.Get(SearchTeacherDiaryTextBox.Text, Page, PageSize);
            var teacherDiarys = new List<TeacherDiaryBaseViewModel>();
            _mapper.Map(teacherDiaryList.TeacherDiaries, teacherDiarys);
            TeacherDiaryDataGrid.ItemsSource = teacherDiarys;
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            Page = 2;
            var teacherDiaryList = _teacherDiaryService.Get(SearchTeacherDiaryTextBox.Text, 2, PageSize);
            var teacherDiarys = new List<TeacherDiaryBaseViewModel>();
            _mapper.Map(teacherDiaryList.TeacherDiaries, teacherDiarys);
            TeacherDiaryDataGrid.ItemsSource = teacherDiarys;
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            Page = 3;
            var teacherDiaryList = _teacherDiaryService.Get(SearchTeacherDiaryTextBox.Text, 3, PageSize);
            var teacherDiarys = new List<TeacherDiaryBaseViewModel>();
            _mapper.Map(teacherDiaryList.TeacherDiaries, teacherDiarys);
            TeacherDiaryDataGrid.ItemsSource = teacherDiarys;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            Page++;
            GetTeacherDiaryAndBind();
        }

        private void GetTeacherDiaryAndBind()
        {
            var teacherDiaryList = _teacherDiaryService.Get(SearchTeacherDiaryTextBox.Text, Page, PageSize);
            var teacherDiarys = new List<TeacherDiaryBaseViewModel>();
            _mapper.Map(teacherDiaryList.TeacherDiaries, teacherDiarys);
            TeacherDiaryDataGrid.ItemsSource = teacherDiarys;
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var teacherDiaryList = _teacherDiaryService.Get(SearchTeacherDiaryTextBox.Text, 1, PageSize);
            var teacherDiarys = new List<TeacherDiaryBaseViewModel>();
            _mapper.Map(teacherDiaryList.TeacherDiaries, teacherDiarys);
            TeacherDiaryDataGrid.ItemsSource = teacherDiarys;
        }

        private void TeacherDiaryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rowDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var row = (TeacherDiaryBaseViewModel)TeacherDiaryDataGrid.SelectedItems[0];
                _teacherDiaryService.Delete(row.Id, "");
                GetTeacherDiaryAndBind();
            }
            else
            {
                MessageBox.Show("Delete operation Terminated");
            }

        }
        private void OnKeyDownHandlerSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Page = 1;
                var teacherDiaryList = _teacherDiaryService.Get(SearchTeacherDiaryTextBox.Text, 1, PageSize);
                var teacherDiarys = new List<TeacherDiaryBaseViewModel>();
                _mapper.Map(teacherDiaryList.TeacherDiaries, teacherDiarys);
                TeacherDiaryDataGrid.ItemsSource = teacherDiarys;
            }
        }
    }
}
