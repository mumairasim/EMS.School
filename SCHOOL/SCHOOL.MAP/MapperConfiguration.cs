﻿using AutoMapper;
using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ViewModels.Student;
using Class = SCHOOL.DATA.Models.Class;
using DTOClass = SCHOOL.DTOs.DTOs.Class;

using Student = SCHOOL.DATA.Models.Student;
using DTOStudent = SCHOOL.DTOs.DTOs.Student;

using Person = SCHOOL.DATA.Models.Person;
using DTOPerson = SCHOOL.DTOs.DTOs.Person;

using File = SCHOOL.DATA.Models.File;
using DTOFile = SCHOOL.DTOs.DTOs.File;




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

            #endregion
        }
    }
}
