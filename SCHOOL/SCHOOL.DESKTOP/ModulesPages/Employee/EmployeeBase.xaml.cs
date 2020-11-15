using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoMapper;
using SCHOOL.DTOs.ViewModels.Employee;
using SCHOOL.DTOs.ViewModels.Student;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;

namespace SCHOOL.DESKTOP.ModulesPages.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeBase.xaml
    /// </summary>
    public partial class EmployeeBase : Page
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private const int PageSize = 50;
        public int Page { get; set; }

        public EmployeeBase(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            InitializeComponent();
            PreLoads();
        }
        public void PreLoads()
        {
            Page = 1;
            var employeeList = _employeeService.Get(1, PageSize);
            var employees = new List<EmployeeBaseViewModel>();
            _mapper.Map(employeeList.Employees, employees);
            EmployeeDataGrid.ItemsSource = employees;
        }
        public void SearchEmployees(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var employeeList = _employeeService.Get(SearchEmployeeTextBox.Text, 1, PageSize);
            var employees = new List<EmployeeBaseViewModel>();
            _mapper.Map(employeeList.Employees, employees);
            EmployeeDataGrid.ItemsSource = employees;
        }
        public void rowEditButton_Click(object sender, RoutedEventArgs e)
        {
            var row = (EmployeeBaseViewModel)EmployeeDataGrid.SelectedItems[0];
            var updateEmployee = new UpdateEmployee(row, _employeeService);
            updateEmployee.ShowDialog();
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var employeeList = _employeeService.Get(SearchEmployeeTextBox.Text, 1, PageSize);
            var employees = new List<EmployeeBaseViewModel>();
            _mapper.Map(employeeList.Employees, employees);
            EmployeeDataGrid.ItemsSource = employees;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (Page > 1)
            {
                Page--;
            }
            var employeeList = _employeeService.Get(SearchEmployeeTextBox.Text, Page, PageSize);
            var employees = new List<EmployeeBaseViewModel>();
            _mapper.Map(employeeList.Employees, employees);
            EmployeeDataGrid.ItemsSource = employees;
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            Page = 2;
            var employeeList = _employeeService.Get(SearchEmployeeTextBox.Text, 2, PageSize);
            var employees = new List<EmployeeBaseViewModel>();
            _mapper.Map(employeeList.Employees, employees);
            EmployeeDataGrid.ItemsSource = employees;
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            Page = 3;
            var employeeList = _employeeService.Get(SearchEmployeeTextBox.Text, 3, PageSize);
            var employees = new List<EmployeeBaseViewModel>();
            _mapper.Map(employeeList.Employees, employees);
            EmployeeDataGrid.ItemsSource = employees;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            Page++;
            GetEmployeeAndBind();
        }

        private void GetEmployeeAndBind()
        {
            var employeeList = _employeeService.Get(SearchEmployeeTextBox.Text, Page, PageSize);
            var employees = new List<EmployeeBaseViewModel>();
            _mapper.Map(employeeList.Employees, employees);
            EmployeeDataGrid.ItemsSource = employees;
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            Page = 1;
            var employeeList = _employeeService.Get(SearchEmployeeTextBox.Text, 1, PageSize);
            var employees = new List<EmployeeBaseViewModel>();
            _mapper.Map(employeeList.Employees, employees);
            EmployeeDataGrid.ItemsSource = employees;
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rowDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var row = (EmployeeBaseViewModel)EmployeeDataGrid.SelectedItems[0];
                _employeeService.Delete(row.Id, "");
                GetEmployeeAndBind();
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
                var employeeList = _employeeService.Get(SearchEmployeeTextBox.Text, 1, PageSize);
                var employees = new List<EmployeeBaseViewModel>();
                _mapper.Map(employeeList.Employees, employees);
                EmployeeDataGrid.ItemsSource = employees;
            }
        }
    }
}
