using System;
using System.Windows;
using SCHOOL.DTOs.ViewModels.Student;
using SCHOOL.SERVICES.Infrastructure;
using DTOStudent = SCHOOL.DTOs.DTOs.Student;

namespace SCHOOL.DESKTOP.ModulesPages.Student
{
    /// <summary>
    /// Interaction logic for UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : Window
    {
        private readonly IStudentService _studentService;
        public UpdateStudent(StudentBaseViewModel model, IStudentService studentService)
        {
            _studentService = studentService;
            InitializeComponent();
            FetchAndPopulateStudent(model.Id);
        }

        public void MapData(DTOStudent model)
        {
            Firstname.Text = model.Person.FirstName;
            Lastname.Text = model.Person.LastName;
            Cnic.Text = model.Person.Cnic;
            Phone.Text = model.Person.Phone;
            Nationality.Text = model.Person.Nationality;
            Religion.Text = model.Person.Religion;
            Dob.Text = model.Person.DOB.ToString();
            Class.Text = model.Class.ClassName;
            //City.Text = model.Person.City;
            PreviousSchool.Text = model.PreviousSchoolName;
            ReasonForLeaving.Text = model.ReasonForLeaving;
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
        private void FetchAndPopulateStudent(Guid id)
        {
            var student = _studentService.Get(id);
            MapData(student);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
