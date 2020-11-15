using System;
using System.Windows;
using System.Windows.Documents;
using SCHOOL.DTOs.ViewModels.Worksheet;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;
using DTOWorksheet = SCHOOL.DTOs.DTOs.Worksheet;

namespace SCHOOL.DESKTOP.ModulesPages.Worksheet
{
    /// <summary>
    /// Interaction logic for UpdateWorksheet.xaml
    /// </summary>
    public partial class UpdateWorksheet : Window
    {
        private readonly IWorksheetService _worksheetService;
        private Guid _worksheetId;
        public UpdateWorksheet(WorksheetBaseViewModel model, IWorksheetService worksheetService)
        {
            _worksheetService = worksheetService;
            InitializeComponent();
            FetchAndPopulateWorksheet(model.Id);
            _worksheetId = model.Id;
        }

        private DTOWorksheet GetFormData()
        {
            return new DTOWorksheet
            {
                Text = Text.Text,
                ForDate = Convert.ToDateTime(ForDate.Text),
            };
        }

        private void FetchAndPopulateWorksheet(Guid id)
        {
            var worksheet = _worksheetService.Get(id);
            MapData(worksheet);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void MapData(DTOWorksheet model)
        {
            Text.Text = model.Text;
            ForDate.Text = model.ForDate.ToString();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var worksheetUpdated = GetFormData();
            worksheetUpdated.Id = _worksheetId;
            _worksheetService.Update(worksheetUpdated);
        }
    }
}
