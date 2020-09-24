using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MaterialDesignThemes.Wpf;
using SCHOOL.DESKTOP.ModulesPages.Student;
using SCHOOL.DTOs.DTOs;
using SCHOOL.Services.Implementation;
using SCHOOL.Services.Infrastructure;

namespace SCHOOL.DESKTOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IClassService _classService;
        public List<Class> ClassList { get; set; } = new List<Class>();
        public MainWindow(IClassService classService)
        {
            _classService = classService;
            InitializeComponent();
            
        }

        
        private void ClassTab_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var classList = _classService.Get();
            ClassDatagrid.ItemsSource = classList;
        }


        private void getClass_Click(object sender, RoutedEventArgs e)
        {
            var classList = _classService.Get();
            ClassDatagrid.ItemsSource = classList;
        }

        private void StudentTab_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            StudentBase.Content = new StudentBase();
        }
    }

}

