using System;
using System.Windows;
using System.Windows.Documents;
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
        private Guid _studentId;
        public UpdateStudent(StudentBaseViewModel model, IStudentService studentService)
        {
            _studentService = studentService;
            InitializeComponent();
            FetchAndPopulateStudent(model.Id);
            _studentId = model.Id;
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

        private DTOStudent GetFormData()
        {
            DTOStudent model = new DTOStudent
            {
                Person = new DTOs.DTOs.Person(),
                Class = new DTOs.DTOs.Class()
            };

            model.Person.FirstName = Firstname.Text;
            model.Person.LastName = Lastname.Text;
            model.Person.Cnic = Cnic.Text;
            model.Person.Phone = Phone.Text;
            model.Person.Nationality = Nationality.Text;
            model.Person.Religion = Religion.Text;
            model.Person.DOB = Dob.Text != "" ? Convert.ToDateTime(Dob.Text) : new DateTime();

            // model.Class.ClassName = ClassDDL.Text;
            model.Class.ClassName = Class.Text;

            model.PreviousSchoolName = PreviousSchool.Text;
            model.ReasonForLeaving = ReasonForLeaving.Text;
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
        private void FetchAndPopulateStudent(Guid id)
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
