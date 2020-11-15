using System;
using System.Windows;
using System.Windows.Documents;
using SCHOOL.DTOs.ViewModels.Employee;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;
using DTOEmployee = SCHOOL.DTOs.DTOs.Employee;

namespace SCHOOL.DESKTOP.ModulesPages.Employee
{
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        private readonly IEmployeeService _employeeService;
        private Guid _employeeId;
        public UpdateEmployee(EmployeeBaseViewModel model, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            InitializeComponent();
            FetchAndPopulateEmployee(model.Id);
            _employeeId = model.Id;
        }

        public void MapData(DTOEmployee model)
        {
            Firstname.Text = model.Person.FirstName;
            Lastname.Text = model.Person.LastName;
            Cnic.Text = model.Person.Cnic;
            Phone.Text = model.Person.Phone;
            Nationality.Text = model.Person.Nationality;
            Religion.Text = model.Person.Religion;
            Dob.Text = model.Person.DOB.ToString();
            PresentAddress.AppendText(model.Person.PresentAddress);
            PermanentAddress.AppendText(model.Person.PermanentAddress);
            ParentName.Text = model.Person.ParentName;
            ParentCnic.Text = model.Person.ParentCnic;
            Relation.Text = model.Person.ParentRelation;
            Occupation.Text = model.Person.ParentOccupation;
            HighestEducation.Text = model.Person.ParentHighestEducation;
            ParentNationality.Text = model.Person.ParentNationality;
            Email.Text = model.Person.ParentEmail;
            OfficeAddress.AppendText(model.Person.ParentOfficeAddress);
            ParentCity.Text = model.Person.ParentCity;
            Mobile1.Text = model.Person.ParentMobile1;
            Mobile2.Text = model.Person.ParentMobile2;
            Name.Text = model.Person.ParentEmergencyName;
            EmergencyRelation.Text = model.Person.ParentEmergencyRelation;
            Mobile.Text = model.Person.ParentEmergencyMobile;

        }

        private DTOEmployee GetFormData()
        {
            DTOEmployee model = new DTOEmployee
            {
                Person = new DTOs.DTOs.Person(),

            };

            model.Person.FirstName = Firstname.Text;
            model.Person.LastName = Lastname.Text;
            model.Person.Cnic = Cnic.Text;
            model.Person.Phone = Phone.Text;
            model.Person.Nationality = Nationality.Text;
            model.Person.Religion = Religion.Text;
            model.Person.DOB = Dob.Text != "" ? Convert.ToDateTime(Dob.Text) : new DateTime();

            model.Person.ParentName = ParentName.Text;
            model.Person.ParentCnic = ParentCnic.Text;
            model.Person.ParentRelation = Relation.Text;
            model.Person.ParentOccupation = Occupation.Text;
            model.Person.ParentHighestEducation = HighestEducation.Text;
            model.Person.ParentNationality = ParentNationality.Text;
            model.Person.ParentEmail = Email.Text;
            model.Person.ParentCity = ParentCity.Text;
            model.Person.ParentMobile1 = Mobile1.Text;
            model.Person.ParentMobile2 = Mobile2.Text;
            model.Person.ParentEmergencyName = Name.Text;
            model.Person.ParentEmergencyRelation = EmergencyRelation.Text;
            model.Person.ParentEmergencyMobile = Mobile.Text;
            model.Person.ParentOfficeAddress = new TextRange(OfficeAddress.Document.ContentStart, OfficeAddress.Document.ContentEnd).Text;
            model.Person.PresentAddress = new TextRange(PresentAddress.Document.ContentStart, PresentAddress.Document.ContentEnd).Text;
            model.Person.PermanentAddress = new TextRange(PermanentAddress.Document.ContentStart, PermanentAddress.Document.ContentEnd).Text;
            return model;
        }
        private void FetchAndPopulateEmployee(Guid id)
        {
            var employee = _employeeService.Get(id);
            MapData(employee);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var employeeUpdated = GetFormData();
            employeeUpdated.Id = _employeeId;
            _employeeService.Update(employeeUpdated);
        }
    }
}
