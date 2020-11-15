using AutoMapper;
using SCHOOL.DTOs.ViewModels.Worksheet;
using SCHOOL.Services.Infrastructure;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SCHOOL.DESKTOP.ModulesPages.Worksheet
{
    /// <summary>
    /// Interaction logic for WorksheetBase.xaml
    /// </summary>
    public partial class WorksheetBase : Page
    {
        private readonly IWorksheetService _worksheetService;
        private readonly IMapper _mapper;
        private const int PageSize = 50;
        public int Page { get; set; }

        public WorksheetBase(IWorksheetService worksheetService, IMapper mapper)
        {
            _worksheetService = worksheetService;
            _mapper = mapper;
            InitializeComponent();
            PreLoads();
        }
        public void PreLoads()
        {
            Page = 1;
            var worksheetList = _worksheetService.Get(1, PageSize);
            var worksheets = new List<WorksheetBaseViewModel>();
            _mapper.Map(worksheetList.Worksheets, worksheets);
            WorksheetDataGrid.ItemsSource = worksheets;
        }
        public void SearchWorksheets(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var worksheetList = _worksheetService.Get(SearchWorksheetTextBox.Text, 1, PageSize);
            var worksheets = new List<WorksheetBaseViewModel>();
            _mapper.Map(worksheetList.Worksheets, worksheets);
            WorksheetDataGrid.ItemsSource = worksheets;
        }
        public void rowEditButton_Click(object sender, RoutedEventArgs e)
        {
            var row = (WorksheetBaseViewModel)WorksheetDataGrid.SelectedItems[0];
            var updateWorksheet = new UpdateWorksheet(row, _worksheetService);
            updateWorksheet.ShowDialog();
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var worksheetList = _worksheetService.Get(SearchWorksheetTextBox.Text, 1, PageSize);
            var worksheets = new List<WorksheetBaseViewModel>();
            _mapper.Map(worksheetList.Worksheets, worksheets);
            WorksheetDataGrid.ItemsSource = worksheets;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1)
            {
                Page--;
            }
            var worksheetList = _worksheetService.Get(SearchWorksheetTextBox.Text, Page, PageSize);
            var worksheets = new List<WorksheetBaseViewModel>();
            _mapper.Map(worksheetList.Worksheets, worksheets);
            WorksheetDataGrid.ItemsSource = worksheets;
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            Page = 2;
            var worksheetList = _worksheetService.Get(SearchWorksheetTextBox.Text, 2, PageSize);
            var worksheets = new List<WorksheetBaseViewModel>();
            _mapper.Map(worksheetList.Worksheets, worksheets);
            WorksheetDataGrid.ItemsSource = worksheets;
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            Page = 3;
            var worksheetList = _worksheetService.Get(SearchWorksheetTextBox.Text, 3, PageSize);
            var worksheets = new List<WorksheetBaseViewModel>();
            _mapper.Map(worksheetList.Worksheets, worksheets);
            WorksheetDataGrid.ItemsSource = worksheets;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            Page++;
            GetWorksheetAndBind();
        }

        private void GetWorksheetAndBind()
        {
            var worksheetList = _worksheetService.Get(SearchWorksheetTextBox.Text, Page, PageSize);
            var worksheets = new List<WorksheetBaseViewModel>();
            _mapper.Map(worksheetList.Worksheets, worksheets);
            WorksheetDataGrid.ItemsSource = worksheets;
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var worksheetList = _worksheetService.Get(SearchWorksheetTextBox.Text, 1, PageSize);
            var worksheets = new List<WorksheetBaseViewModel>();
            _mapper.Map(worksheetList.Worksheets, worksheets);
            WorksheetDataGrid.ItemsSource = worksheets;
        }

        private void WorksheetDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rowDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var row = (WorksheetBaseViewModel)WorksheetDataGrid.SelectedItems[0];
                _worksheetService.Delete(row.Id);
                GetWorksheetAndBind();
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
                var worksheetList = _worksheetService.Get(SearchWorksheetTextBox.Text, 1, PageSize);
                var worksheets = new List<WorksheetBaseViewModel>();
                _mapper.Map(worksheetList.Worksheets, worksheets);
                WorksheetDataGrid.ItemsSource = worksheets;
            }
        }
    }
}
