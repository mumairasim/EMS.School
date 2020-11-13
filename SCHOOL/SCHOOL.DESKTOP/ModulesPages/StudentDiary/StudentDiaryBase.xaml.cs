using AutoMapper;
using SCHOOL.DTOs.ViewModels.StudentDiary;
using SCHOOL.Services.Infrastructure;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SCHOOL.DESKTOP.ModulesPages.StudentDiary
{
    /// <summary>
    /// Interaction logic for StudentDiaryBase.xaml
    /// </summary>
    public partial class StudentDiaryBase : Page
    {
        private readonly IStudentDiaryService _studentDiaryService;
        private readonly IMapper _mapper;
        private const int PageSize = 50;
        public int Page { get; set; }

        public StudentDiaryBase(IStudentDiaryService studentDiaryService, IMapper mapper)
        {
            _studentDiaryService = studentDiaryService;
            _mapper = mapper;
            InitializeComponent();
            PreLoads();
        }
        public void PreLoads()
        {
            Page = 1;
            var studentDiaryList = _studentDiaryService.Get(1, PageSize);
            var studentDiaries = new List<StudentDiaryBaseViewModel>();
            _mapper.Map(studentDiaryList.StudentDiaries, studentDiaries);
            StudentDiaryDataGrid.ItemsSource = studentDiaries;
        }

        public void SearchStudentDiaries(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var studentDiaryList = _studentDiaryService.Get(SearchStudentDiaryTextBox.Text, 1, PageSize);
            var studentDiaries = new List<StudentDiaryBaseViewModel>();
            _mapper.Map(studentDiaryList.StudentDiaries, studentDiaries);
            StudentDiaryDataGrid.ItemsSource = studentDiaries;
        }
        public void rowEditButton_Click(object sender, RoutedEventArgs e)
        {
            var row = (StudentDiaryBaseViewModel)StudentDiaryDataGrid.SelectedItems[0];
            var updateStudentDiary = new UpdateStudentDiary(row, _studentDiaryService);
            updateStudentDiary.ShowDialog();
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var studentDiaryList = _studentDiaryService.Get(SearchStudentDiaryTextBox.Text, 1, PageSize);
            var studentDiaries = new List<StudentDiaryBaseViewModel>();
            _mapper.Map(studentDiaryList.StudentDiaries, studentDiaries);
            StudentDiaryDataGrid.ItemsSource = studentDiaries;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1)
            {
                Page--;
            }
            var studentDiaryList = _studentDiaryService.Get(SearchStudentDiaryTextBox.Text, Page, PageSize);
            var studentDiaries = new List<StudentDiaryBaseViewModel>();
            _mapper.Map(studentDiaryList.StudentDiaries, studentDiaries);
            StudentDiaryDataGrid.ItemsSource = studentDiaries;
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            Page = 2;
            var studentDiaryList = _studentDiaryService.Get(SearchStudentDiaryTextBox.Text, 2, PageSize);
            var studentDiaries = new List<StudentDiaryBaseViewModel>();
            _mapper.Map(studentDiaryList.StudentDiaries, studentDiaries);
            StudentDiaryDataGrid.ItemsSource = studentDiaries;
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            Page = 3;
            var studentDiaryList = _studentDiaryService.Get(SearchStudentDiaryTextBox.Text, 3, PageSize);
            var studentDiaries = new List<StudentDiaryBaseViewModel>();
            _mapper.Map(studentDiaryList.StudentDiaries, studentDiaries);
            StudentDiaryDataGrid.ItemsSource = studentDiaries;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            Page++;
            GetStudentDiaryAndBind();
        }

        private void GetStudentDiaryAndBind()
        {
            var studentDiaryList = _studentDiaryService.Get(SearchStudentDiaryTextBox.Text, Page, PageSize);
            var studentDiaries = new List<StudentDiaryBaseViewModel>();
            _mapper.Map(studentDiaryList.StudentDiaries, studentDiaries);
            StudentDiaryDataGrid.ItemsSource = studentDiaries;
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var studentDiaryList = _studentDiaryService.Get(SearchStudentDiaryTextBox.Text, 1, PageSize);
            var studentDiaries = new List<StudentDiaryBaseViewModel>();
            _mapper.Map(studentDiaryList.StudentDiaries, studentDiaries);
            StudentDiaryDataGrid.ItemsSource = studentDiaries;
        }

        private void StudentDiaryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rowDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var row = (StudentDiaryBaseViewModel)StudentDiaryDataGrid.SelectedItems[0];
                _studentDiaryService.Delete(row.Id, "");
                GetStudentDiaryAndBind();
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
                var studentDiaryList = _studentDiaryService.Get(SearchStudentDiaryTextBox.Text, 1, PageSize);
                var studentDiaries = new List<StudentDiaryBaseViewModel>();
                _mapper.Map(studentDiaryList.StudentDiaries, studentDiaries);
                StudentDiaryDataGrid.ItemsSource = studentDiaries;
            }
        }
    }
}
