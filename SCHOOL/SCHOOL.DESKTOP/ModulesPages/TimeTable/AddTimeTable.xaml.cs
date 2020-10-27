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
            Dr = Dt.NewRow();

            Dr[0] = "Monday";

            Dt.Rows.Add(Dr);

            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }

        private void Tuesday_Checked(object sender, RoutedEventArgs e)
        {
            Dr = Dt.NewRow();

            Dr[0] = "Tuesday";

            Dt.Rows.Add(Dr);

            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }

        private void Wednesday_Checked(object sender, RoutedEventArgs e)
        {
            Dr = Dt.NewRow();

            Dr[0] = "Wednesday";

            Dt.Rows.Add(Dr);

            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }

        private void Thursday_Checked(object sender, RoutedEventArgs e)
        {
            Dr = Dt.NewRow();

            Dr[0] = "Thursday";

            Dt.Rows.Add(Dr);

            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }

        private void Friday_Checked(object sender, RoutedEventArgs e)
        {
            Dr = Dt.NewRow();

            Dr[0] = "Friday";

            Dt.Rows.Add(Dr);

            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }

        private void Saturday_Checked(object sender, RoutedEventArgs e)
        {
            Dr = Dt.NewRow();

            Dr[0] = "Saturday";

            Dt.Rows.Add(Dr);

            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }

        private void Sunday_Checked(object sender, RoutedEventArgs e)
        {
            Dr = Dt.NewRow();

            Dr[0] = "Sunday";

            Dt.Rows.Add(Dr);

            TimeTableDataGrid.ItemsSource = Dt.DefaultView;
        }
    }
}
