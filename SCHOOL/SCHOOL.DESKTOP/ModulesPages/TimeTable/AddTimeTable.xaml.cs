using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            DataGridTimeTableInitialization();
        }

        public DataTable Dt { get; set; }
        public DataRow Dr { get; set; }

        private void DataGridTimeTableInitialization()
        {
            Dt = new DataTable("timeTable");

            DataColumn dc1 = new DataColumn("Days", typeof(string));

            Dt.Columns.Add(dc1);

            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }
        private void Monday_Checked(object sender, RoutedEventArgs e)
        {
            AddDayRow(DaysOfWeek.Monday.ToString());
        }

        private void Tuesday_Checked(object sender, RoutedEventArgs e)
        {
            AddDayRow(DaysOfWeek.Tuesday.ToString());
        }

        private void Wednesday_Checked(object sender, RoutedEventArgs e)
        {
            AddDayRow(DaysOfWeek.Wednesday.ToString());
        }

        private void Thursday_Checked(object sender, RoutedEventArgs e)
        {
            AddDayRow(DaysOfWeek.Thursday.ToString());
        }

        private void Friday_Checked(object sender, RoutedEventArgs e)
        {
            AddDayRow(DaysOfWeek.Friday.ToString());
        }

        private void Saturday_Checked(object sender, RoutedEventArgs e)
        {
            AddDayRow(DaysOfWeek.Saturday.ToString());
        }

        private void Sunday_Checked(object sender, RoutedEventArgs e)
        {
            AddDayRow(DaysOfWeek.Sunday.ToString());
        }

        private void Monday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveDayRow(DaysOfWeek.Monday.ToString());
        }
        private void Tuesday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveDayRow(DaysOfWeek.Tuesday.ToString());
        }
        private void Wednesday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveDayRow(DaysOfWeek.Wednesday.ToString());
        }
        private void Thursday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveDayRow(DaysOfWeek.Thursday.ToString());
        }
        private void Friday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveDayRow(DaysOfWeek.Friday.ToString());
        }
        private void Saturday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveDayRow(DaysOfWeek.Saturday.ToString());
        }
        private void Sunday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveDayRow(DaysOfWeek.Sunday.ToString());
        }




        private void RemoveDayRow(string day)
        {
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                DataRow dr = Dt.Rows[i];
                if ((string)dr[0] == day)
                {
                    dr.Delete();
                    Dt.AcceptChanges();
                    break;
                }
            }
            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }
        private void AddDayRow(string day)
        {
            Dr = Dt.NewRow();
            Dr[0] = day;
            Dt.Rows.Add(Dr);
            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }
    }
}
