using System.Windows;
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
        public MainWindow(IClassService classService)
        {
            _classService = classService;
            InitializeComponent();
        }

        private void StudentTab_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

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
    }

}

