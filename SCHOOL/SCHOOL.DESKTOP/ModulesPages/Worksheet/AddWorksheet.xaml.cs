using AutoMapper;
using SCHOOL.DTOs.ViewModels.Common;
using SCHOOL.Services.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DTOWorksheet = SCHOOL.DTOs.DTOs.Worksheet;

namespace SCHOOL.DESKTOP.ModulesPages.Worksheet
{

    public partial class AddWorksheet : Page
    {
        private readonly IWorksheetService _worksheetService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Interaction logic for AddWorksheet.xaml
        /// </summary>
        public AddWorksheet(IWorksheetService worksheetService, IClassService classService, IMapper mapper)
        {
            _worksheetService = worksheetService;
            _classService = classService;
            _mapper = mapper;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _worksheetService.Create(GetFormData());
        }

       
        private DTOWorksheet GetFormData()
        {
            return new DTOWorksheet
            {
                
            };
        }
    }
}
