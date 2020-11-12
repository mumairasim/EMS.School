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
        private readonly IWorksheetService _studentService;
        private Guid _studentId;
        public UpdateWorksheet(WorksheetBaseViewModel model, IWorksheetService studentService)
        {
            _studentService = studentService;
            InitializeComponent();
            FetchAndPopulateWorksheet(model.Id);
            _studentId = model.Id;
        }

        public void MapData(DTOWorksheet model)
        {

        }

        private DTOWorksheet GetFormData()
        {
            return new DTOWorksheet
            {

            };
        }
        private void FetchAndPopulateWorksheet(Guid id)
        {
            var student = _studentService.Get(id);
            MapData(student);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var studentUpdated = GetFormData();
            studentUpdated.Id = _studentId;
            _studentService.Update(studentUpdated);
        }
    }
}
