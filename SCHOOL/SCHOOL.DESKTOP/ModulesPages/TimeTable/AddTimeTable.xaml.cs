using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SCHOOL.DTOs.Enums;

namespace SCHOOL.DESKTOP.ModulesPages.TimeTable
{
    /// <summary>
    /// Interaction logic for AddTimeTable.xaml
    /// </summary>
    public partial class AddTimeTable : Page
    {
        public AddTimeTable()
        {
            InitializeComponent();
        }

        private void Monday_Checked(object sender, RoutedEventArgs e)
        {
            AddColumn(DaysOfWeek.Monday.ToString());
        }

        private void Tuesday_Checked(object sender, RoutedEventArgs e)
        {
            AddColumn(DaysOfWeek.Tuesday.ToString());
        }

        private void Wednesday_Checked(object sender, RoutedEventArgs e)
        {
            AddColumn(DaysOfWeek.Wednesday.ToString());
        }

        private void Thursday_Checked(object sender, RoutedEventArgs e)
        {
            AddColumn(DaysOfWeek.Thursday.ToString());
        }

        private void Friday_Checked(object sender, RoutedEventArgs e)
        {
            AddColumn(DaysOfWeek.Friday.ToString());
        }

        private void Saturday_Checked(object sender, RoutedEventArgs e)
        {
            AddColumn(DaysOfWeek.Saturday.ToString());
        }

        private void Sunday_Checked(object sender, RoutedEventArgs e)
        {
            AddColumn(DaysOfWeek.Sunday.ToString());
        }

        private void Monday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveColumn(DaysOfWeek.Monday.ToString());
        }
        private void Tuesday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveColumn(DaysOfWeek.Tuesday.ToString());
        }
        private void Wednesday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveColumn(DaysOfWeek.Wednesday.ToString());
        }
        private void Thursday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveColumn(DaysOfWeek.Thursday.ToString());
        }
        private void Friday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveColumn(DaysOfWeek.Friday.ToString());
        }
        private void Saturday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveColumn(DaysOfWeek.Saturday.ToString());
        }
        private void Sunday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveColumn(DaysOfWeek.Sunday.ToString());
        }

        private void AddColumn(string columnName)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn { Header = columnName };
            TimeTableDataGrid.Columns.Add(textColumn);
        }

        private void RemoveColumn(string columnName)
        {
            var textColumn = TimeTableDataGrid.Columns.FirstOrDefault(c => c.Header.Equals(columnName));
            TimeTableDataGrid.Columns.Remove(textColumn);
        }

    }
}
