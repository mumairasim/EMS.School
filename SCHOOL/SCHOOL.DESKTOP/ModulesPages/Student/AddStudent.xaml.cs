using AutoMapper;
using SCHOOL.DTOs.ViewModels.Common;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using DTOStudent = SCHOOL.DTOs.DTOs.Student;


namespace SCHOOL.DESKTOP.ModulesPages.Student
{

    public partial class AddStudent : Page
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Interaction logic for AddStudent.xaml
        /// </summary>
        public AddStudent(IStudentService studentService, IClassService classService, IMapper mapper)
        {
            _studentService = studentService;
            _classService = classService;
            _mapper = mapper;
            InitializeComponent();
            initComboBox();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _studentService.Create(GetFormData());
        }

        private void initComboBox()
        {

            var classList = _classService.Get().Select(x => new CustomComboBoxItem
            {
                Text = x.ClassName,
                Value = x.Id
            }).ToList();

            foreach (var item in classList)
            {
                ClassDDL.Items.Add(item);
            }
            ClassDDL.SelectedIndex = 0;
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
            model.Person.DOB = Convert.ToDateTime(Dob.Text);

            //
            model.Class.ClassName = ClassDDL.Text;

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
    }
}
