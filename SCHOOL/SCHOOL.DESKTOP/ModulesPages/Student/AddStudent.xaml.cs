using AutoMapper;
using SCHOOL.DTOs.ViewModels.Common;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using DTOStudent = SCHOOL.DTOs.DTOs.Student;
using DTOClass = SCHOOL.DTOs.DTOs.Class;


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
            InitComboBox();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _studentService.Create(GetFormData());
        }

        private void InitComboBox()
        {
            ClassDropDownViewModel vm = new ClassDropDownViewModel(_classService);
            DataContext = vm;
            ClassDdl.SelectedIndex = 0;
        }

        private DTOStudent GetFormData()
        {
            DTOStudent model = new DTOStudent
            {
                Person = new DTOs.DTOs.Person(),
                Class = new DTOClass()
            };

            model.Person.FirstName = Firstname.Text;
            model.Person.LastName = Lastname.Text;
            model.Person.Cnic = Cnic.Text;
            model.Person.Phone = Phone.Text;
            model.Person.Nationality = Nationality.Text;
            model.Person.Religion = Religion.Text;
            model.Person.DOB = Convert.ToDateTime(Dob.Text);

            //
            model.Class.ClassName = ClassDdl.Text;

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

    public class ClassDropDownViewModel : INotifyPropertyChanged
    {
        public CollectionView ClassEntries { get; set; }
        private string _classEntry;
        public ClassDropDownViewModel(IClassService classService)
        {
            var classList = classService.Get();
            ClassEntries = new CollectionView(classList);
            ClassEntry = classList[0].ClassName;
        }

        public string ClassEntry
        {
            get => _classEntry;
            set
            {
                if (_classEntry == value) return;
                _classEntry = value;
                OnPropertyChanged(_classEntry);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //MessageBox.Show("Value : " + propertyName);
        }
    }
}
