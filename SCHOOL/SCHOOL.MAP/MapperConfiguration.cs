using AutoMapper;
using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ViewModels.Student;
using SCHOOL.DTOs.ViewModels.TimeTable;
using Class = SCHOOL.DATA.Models.Class;
using DTOClass = SCHOOL.DTOs.DTOs.Class;

using Course = SCHOOL.DATA.Models.Course;
using DTOCourse = SCHOOL.DTOs.DTOs.Course;

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


using TimeTable = SCHOOL.DATA.Models.TimeTable;
using DTOTimeTable = SCHOOL.DTOs.DTOs.TimeTable;

using TimeTableDetail = SCHOOL.DATA.Models.TimeTableDetail;
using DTOTimeTableDetail = SCHOOL.DTOs.DTOs.TimeTableDetail;

using Period = SCHOOL.DATA.Models.Period;
using DTOPeriod = SCHOOL.DTOs.DTOs.Period;

using TeacherDiary = SCHOOL.DATA.Models.TeacherDiary;
using DTOTeacherDiary = SCHOOL.DTOs.DTOs.TeacherDiary;

using StudentDiary = SCHOOL.DATA.Models.StudentDiary;
using DTOStudentDiary = SCHOOL.DTOs.DTOs.StudentDiary;


using SCHOOL.DTOs.ViewModels.Employee;
using SCHOOL.DTOs.ViewModels.Worksheet;
using SCHOOL.DTOs.ViewModels.LessonPlan;
using SCHOOL.DTOs.ViewModels.TeacherDiary;
using SCHOOL.DTOs.ViewModels.StudentDiary;



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

            CreateMap<Course, DTOCourse>();
            CreateMap<DTOCourse, DTOCourse>()
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

            CreateMap<Employee, DTOEmployee>();
            CreateMap<DTOEmployee, DTOEmployee>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Designation, DTODesignation>();
            CreateMap<DTODesignation, DTODesignation>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<TimeTable, DTOTimeTable>();
            CreateMap<DTOTimeTable, DTOTimeTable>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<TimeTableDetail, DTOTimeTableDetail>();
            CreateMap<DTOTimeTableDetail, DTOTimeTableDetail>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<Period, DTOPeriod>();
            CreateMap<DTOPeriod, DTOPeriod>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<TeacherDiary, DTOTeacherDiary>();
            CreateMap<DTOTeacherDiary, DTOTeacherDiary>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            CreateMap<StudentDiary, DTOStudentDiary>();
            CreateMap<DTOStudentDiary, DTOStudentDiary>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));


            #endregion

            #region DTO to DB

            //DTO to Db
            CreateMap<DTOClass, Class>();

            CreateMap<DTOCourse, Course>();

            CreateMap<DTOStudent, Student>();
            CreateMap<DTOWorksheet, Worksheet>();
            CreateMap<DTOLessonPlan, LessonPlan>();
            CreateMap<DTODesignation, Designation>();
            CreateMap<DTOEmployee, Employee>();

            CreateMap<DTOPerson, Person>();

            CreateMap<DTOFile, File>();
            CreateMap<DTOEmployee, Employee>();

            CreateMap<DTODesignation, Designation>();

            CreateMap<DTOTimeTable, TimeTable>();
            CreateMap<DTOTimeTableDetail, TimeTableDetail>();
            CreateMap<DTOPeriod, Period>();
            CreateMap<DTOTeacherDiary, TeacherDiary>();
            CreateMap<DTOStudentDiary, StudentDiary>();

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

            CreateMap<DTOTimeTable, TimeTableBaseViewModel>()
                .ForMember(x => x.ClassName, y => y.MapFrom(x => x.Class.ClassName));

            CreateMap<DTOWorksheet, WorksheetBaseViewModel>()
                .ForMember(x => x.InstructorId, y => y.MapFrom(x => x.InstructorId))
                .ForMember(x => x.Text, y => y.MapFrom(x => x.Text))
                .ForMember(x => x.ForDate, y => y.MapFrom(x => x.ForDate))
                .ForMember(x => x.EmployeeName, y => y.MapFrom(x => (x.Employee.Person.FirstName + " " + x.Employee.Person.LastName)));

            CreateMap<DTOLessonPlan, LessonPlanBaseViewModel>();
            CreateMap<DTOTeacherDiary, TeacherDiaryBaseViewModel>();
            CreateMap<DTOStudentDiary, StudentDiaryBaseViewModel>();

            CreateMap<DTOEmployee, EmployeeBaseViewModel>()
    .ForMember(x => x.PersonCnic, y => y.MapFrom(x => x.Person.Cnic))
    .ForMember(x => x.PersonName, y => y.MapFrom(x => x.Person.FirstName + " " + x.Person.LastName))
    .ForMember(x => x.PersonNationality, y => y.MapFrom(x => x.Person.Nationality))
    .ForMember(x => x.PersonReligion, y => y.MapFrom(x => x.Person.Religion));

            #endregion
        }
    }
}
