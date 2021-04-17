using AutoMapper;
using SCHOOL.Services.Infrastructure;
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

namespace SCHOOL.DESKTOP.ModulesPages.Class
{
    /// <summary>
    /// Interaction logic for ClassBase.xaml
    /// </summary>
    public partial class ClassBase : Page
    {
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        public ClassBase(IClassService classService, IMapper mapper)
        {
            _mapper = mapper;
            _classService = classService;
            InitializeComponent();
            bindList(SearchClassTextBox.Text);

        }

        private void bindList( string SearchParam)
        {
            var classList = _classService.Get(SearchParam);
            ClassDataGrid.ItemsSource = classList;
        }
        public void SearchClass(object sender, RoutedEventArgs e)
        {
            bindList(SearchClassTextBox.Text);
        }

        private void OnKeyDownHandlerSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {

                bindList(SearchClassTextBox.Text);
            }
        }
    }
}
