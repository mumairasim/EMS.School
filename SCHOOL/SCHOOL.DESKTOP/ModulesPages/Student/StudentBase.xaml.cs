using System.Windows;
using System.Windows.Controls;
using SCHOOL.Services.Infrastructure;

namespace SCHOOL.DESKTOP.ModulesPages.Student
{
    /// <summary>
    /// Interaction logic for StudentBase.xaml
    /// </summary>
    public partial class StudentBase : Page
    {
        private readonly IClassService _classService;
        public StudentBase(IClassService classService)
        {
            _classService = classService;
            InitializeComponent();
            var classList = _classService.Get();
            StudentDataGrid.ItemsSource = classList;
        }

        public void SearchStudents(object sender, RoutedEventArgs e)
        {
            var classList = _classService.Get();
            StudentDataGrid.ItemsSource = classList;
        }
    }
}
