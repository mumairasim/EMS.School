using AutoMapper;
using SCHOOL.DTOs.ViewModels.Common;
using SCHOOL.Services.Infrastructure;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using DTOEmployee = SCHOOL.DTOs.DTOs.Employee;


namespace SCHOOL.DESKTOP.ModulesPages.Employee
{

    public partial class AddEmployee : Page
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Interaction logic for AddEmployee.xaml
        /// </summary>
        public AddEmployee(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _employeeService.Create(GetFormData());
        }


        private DTOEmployee GetFormData()
        {
            DTOEmployee model = new DTOEmployee
            {
                Person = new DTOs.DTOs.Person()
            };

            model.Person.FirstName = Firstname.Text;
            model.Person.LastName = Lastname.Text;
            model.Person.Cnic = Cnic.Text;
            model.Person.Phone = Phone.Text;
            model.Person.Nationality = Nationality.Text;
            model.Person.Religion = Religion.Text;
            model.Person.DOB = Convert.ToDateTime(Dob.Text);

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
    }
}
