using AutoMapper;
using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ViewModels.Student;
using Class = SCHOOL.DATA.Models.Class;
using DTOClass = SCHOOL.DTOs.DTOs.Class;

using Student = SCHOOL.DATA.Models.Student;
using DTOStudent = SCHOOL.DTOs.DTOs.Student;

using Worksheet = SCHOOL.DATA.Models.Worksheet;
using DTOWorksheet = SCHOOL.DTOs.DTOs.Worksheet;

using LessonPlan = SCHOOL.DATA.Models.LessonPlan;
using DTOLessonPlan = SCHOOL.DTOs.DTOs.LessonPlan;

using Designation = SCHOOL.DATA.Models.Designation;
using DTODesignation = SCHOOL.DTOs.DTOs.Designation;

using Employee = SCHOOL.DATA.Models.Employee;
using DTOEmployee = SCHOOL.DTOs.DTOs.Employee;

using Person = SCHOOL.DATA.Models.Person;
using DTOPerson = SCHOOL.DTOs.DTOs.Person;

using File = SCHOOL.DATA.Models.File;
using DTOFile = SCHOOL.DTOs.DTOs.File;
using SCHOOL.DTOs.ViewModels.Employee;
using SCHOOL.DTOs.ViewModels.Worksheet;
using SCHOOL.DTOs.ViewModels.LessonPlan;

namespace SCHOOL.MAP
{
    public class MapperConfigurationInternal : Profile
    {
        public MapperConfigurationInternal()
        {
            #region DB to DTO
            //Db to DTO

            CreateMap<Class, DTOClass>();
            CreateMap<DTOClass, DTOClass>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Student, DTOStudent>();
            CreateMap<DTOStudent, DTOStudent>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Worksheet, DTOWorksheet>();
            CreateMap<DTOWorksheet, DTOWorksheet>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<LessonPlan, DTOLessonPlan>();
            CreateMap<DTOLessonPlan, DTOLessonPlan>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Designation, DTODesignation>();
            CreateMap<DTODesignation, DTODesignation>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Employee, DTOEmployee>();
            CreateMap<DTOEmployee, DTOEmployee>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Person, DTOPerson>();
            CreateMap<DTOPerson, DTOPerson>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<File, DTOFile>();
            CreateMap<DTOFile, DTOFile>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            #endregion

            #region DTO to DB

            //DTO to Db
            CreateMap<DTOClass, Class>();

            CreateMap<DTOStudent, Student>();
            CreateMap<DTOWorksheet, Worksheet>();
            CreateMap<DTOLessonPlan, LessonPlan>();
            CreateMap<DTODesignation, Designation>();
            CreateMap<DTOEmployee, Employee>();

            CreateMap<DTOPerson, Person>();

            CreateMap<DTOFile, File>();

            #endregion

            #region Others

            #endregion

            #region ToCommonRequestModel
            CreateMap<DTOClass, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "Class"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            #endregion

            #region ViewModels

            CreateMap<DTOStudent, StudentBaseViewModel>()
                .ForMember(x => x.ClassName, y => y.MapFrom(x => x.Class.ClassName))
                .ForMember(x => x.PersonCnic, y => y.MapFrom(x => x.Person.Cnic))
                .ForMember(x => x.PersonName, y => y.MapFrom(x => x.Person.FirstName + " " + x.Person.LastName))
                .ForMember(x => x.PersonNationality, y => y.MapFrom(x => x.Person.Nationality))
                .ForMember(x => x.PersonReligion, y => y.MapFrom(x => x.Person.Religion));

            CreateMap<DTOWorksheet, WorksheetBaseViewModel>()
                .ForMember(x => x.InstructorId, y => y.MapFrom(x => x.InstructorId))
                .ForMember(x => x.Text, y => y.MapFrom(x => x.Text))
                .ForMember(x => x.ForDate, y => y.MapFrom(x => x.ForDate))
                .ForMember(x => x.EmployeeName, y => y.MapFrom(x => (x.Employee.Person.FirstName + " " + x.Employee.Person.LastName)));

            CreateMap<DTOLessonPlan, LessonPlanBaseViewModel>();

            CreateMap<DTOEmployee, EmployeeBaseViewModel>()
    .ForMember(x => x.PersonCnic, y => y.MapFrom(x => x.Person.Cnic))
    .ForMember(x => x.PersonName, y => y.MapFrom(x => x.Person.FirstName + " " + x.Person.LastName))
    .ForMember(x => x.PersonNationality, y => y.MapFrom(x => x.Person.Nationality))
    .ForMember(x => x.PersonReligion, y => y.MapFrom(x => x.Person.Religion));

            #endregion
        }
    }
}
