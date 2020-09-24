using System;
using System.Collections.Generic;
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
