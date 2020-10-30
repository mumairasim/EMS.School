using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using SCHOOL.DTOs.Enums;

namespace SCHOOL.DESKTOP.ModulesPages.TimeTable
{
    /// <summary>
    /// Interaction logic for AddTimeTable.xaml
    /// </summary>
    public partial class AddTimeTable
    {
        public AddTimeTable()
        {
            InitializeComponent();
            PageInitialization();
        }

        public int MondayPeriod { get; set; }
        public int TuesdayPeriod { get; set; }
        public int WednesdayPeriod { get; set; }
        public int ThursdayPeriod { get; set; }
        public int FridayPeriod { get; set; }
        public int SaturdayPeriod { get; set; }
        public int SundayPeriod { get; set; }

        private void PageInitialization()
        {
            TimeTableGrid.RowDefinitions.Add(new RowDefinition());
            TimeTableGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < 7; i++)
            {
                TimeTableGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(MinHeight = 60)
                });
            }
            for (int i = 0; i < 8; i++)
            {
                TimeTableGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(MinWidth = 150)
                });
            }


            var dynamicLabel = new Label
            {
                Content = "Days",
                //Foreground = new SolidColorBrush(Colors.White),
                //Background = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Bold
            };
            Grid.SetRow(dynamicLabel, 0);
            Grid.SetColumn(dynamicLabel, 0);
            TimeTableGrid.Children.Add(dynamicLabel);
            MondayPeriod = 0;
            TuesdayPeriod = 0;
            WednesdayPeriod = 0;
            ThursdayPeriod = 0;
            FridayPeriod = 0;
            SaturdayPeriod = 0;
            SundayPeriod = 0;

            SubjectName.Items.Add(new ComboBoxItem { Content = "English" });
            SubjectName.Items.Add(new ComboBoxItem { Content = "Urdu" });
            SubjectName.Items.Add(new ComboBoxItem { Content = "Maths" });
            SubjectName.Items.Add(new ComboBoxItem { Content = "Science" });


            TeacherName.Items.Add(new ComboBoxItem { Content = "Asif Ali" });
            TeacherName.Items.Add(new ComboBoxItem { Content = "Kashif Naeem" });
            TeacherName.Items.Add(new ComboBoxItem { Content = "Nabiha Batool" });
            TeacherName.Items.Add(new ComboBoxItem { Content = "Farzana Khan" });


            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Monday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Tuesday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Wednesday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Thursday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Friday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Saturday.ToString() });
            Day.Items.Add(new ComboBoxItem { Content = DaysOfWeek.Sunday.ToString() });

        }
        private void Monday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Monday);
        }

        private void Tuesday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Tuesday);
        }

        private void Wednesday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Wednesday);
        }

        private void Thursday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Thursday);
        }

        private void Friday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Friday);
        }

        private void Saturday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Saturday);
        }

        private void Sunday_Checked(object sender, RoutedEventArgs e)
        {
            AddRow(DaysOfWeek.Sunday);
        }

        private void Monday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Monday);
        }
        private void Tuesday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Tuesday);
        }
        private void Wednesday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Wednesday);
        }
        private void Thursday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Thursday);
        }
        private void Friday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Friday);
        }
        private void Saturday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Saturday);
        }
        private void Sunday_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveRow(DaysOfWeek.Sunday);
        }
        private void AddPeriod_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)Day.SelectedItem;
            string selectedDay = typeItem.Content.ToString();
            var day = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), selectedDay);
            if (day == DaysOfWeek.Monday)
            {
                if (MondayPeriod < 9)
                {
                    MondayPeriod++;
                    PrepareStringAndInsertColumn(day, MondayPeriod);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Tuesday)
            {
                if (TuesdayPeriod < 9)
                {
                    TuesdayPeriod++;
                    PrepareStringAndInsertColumn(day, TuesdayPeriod);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Wednesday)
            {
                if (WednesdayPeriod < 9)
                {
                    WednesdayPeriod++;
                    PrepareStringAndInsertColumn(day, WednesdayPeriod);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Thursday)
            {
                if (ThursdayPeriod < 9)
                {
                    ThursdayPeriod++;
                    PrepareStringAndInsertColumn(day, ThursdayPeriod);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Friday)
            {
                if (FridayPeriod < 9)
                {
                    FridayPeriod++;
                    PrepareStringAndInsertColumn(day, FridayPeriod);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Saturday)
            {
                if (SaturdayPeriod < 9)
                {
                    SaturdayPeriod++;
                    PrepareStringAndInsertColumn(day, SaturdayPeriod);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (day == DaysOfWeek.Sunday)
            {
                if (SundayPeriod < 9)
                {
                    SundayPeriod++;
                    PrepareStringAndInsertColumn(day, SundayPeriod);
                }
                else
                {
                    MessageBox.Show("Max number of periods added", "Max Limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddRow(DaysOfWeek day)
        {
            var dynamicLabel = new Label
            {
                Name = day + "_Label",
                Content = day.ToString(),
                FontWeight = FontWeights.Bold
            };
            Grid.SetRow(dynamicLabel, (int)day);
            Grid.SetColumn(dynamicLabel, 0);
            TimeTableGrid.Children.Add(dynamicLabel);

        }
        private void RemoveRow(DaysOfWeek day)
        {
            Label lbl = (Label)LogicalTreeHelper.FindLogicalNode(TimeTableGrid, day + "_Label");
            TimeTableGrid.Children.Remove(lbl);
        }
        private void AddColumn(DaysOfWeek day, string text, int period)
        {
            var dynamicLabel = new Label
            {
                Name = day + "_" + period + "_Label",
                Content = text,
                Margin = new Thickness(5, 5, 5, 5)
            };
            Grid.SetRow(dynamicLabel, (int)day);
            Grid.SetColumn(dynamicLabel, period);
            TimeTableGrid.Children.Add(dynamicLabel);

        }

        private void PrepareStringAndInsertColumn(DaysOfWeek day, int period)
        {
            ComboBoxItem typeItemSubject = (ComboBoxItem)SubjectName.SelectedItem;
            string subjectName = typeItemSubject.Content.ToString();

            ComboBoxItem typeItemTeacher = (ComboBoxItem)TeacherName.SelectedItem;
            string teacherName = typeItemTeacher.Content.ToString();

            var startTime = StartTime.Text;
            var endTime = EndTime.Text;

            var query = new StringBuilder();
            query.Append(subjectName + "\n");
            query.Append(teacherName + "\n");
            query.Append(startTime + " - " + endTime);


            AddColumn(day, query.ToString(), period);
        }
    }
}
