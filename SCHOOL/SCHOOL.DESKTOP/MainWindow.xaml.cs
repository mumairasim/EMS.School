using System.Collections.Generic;
using System.Windows;
using SCHOOL.DESKTOP.ModulesPages.Student;
using SCHOOL.DTOs.DTOs;
using SCHOOL.Services.Infrastructure;

namespace SCHOOL.DESKTOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IClassService _classService;
        private readonly StudentBase _studentBase;
        public List<Class> ClassList { get; set; } = new List<Class>();
        public MainWindow(IClassService classService)
        {
            _classService = classService;
            _studentBase = new StudentBase(_classService);
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

        private void StudentTab_GotFocus(object sender, RoutedEventArgs e)
        {
            StudentBase.Content = _studentBase;
        }
    }

}

