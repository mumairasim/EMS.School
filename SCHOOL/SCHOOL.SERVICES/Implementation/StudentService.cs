using AutoMapper;
using SCHOOL.DATA.Infrastructure;
using SCHOOL.DTOs.DTOs;
using SCHOOL.Services.Infrastructure;
using SCHOOL.SERVICES.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DTOStudent = SCHOOL.DTOs.DTOs.Student;
using Student = SCHOOL.DATA.Models.Student;

namespace SCHOOL.SERVICES.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IPersonService _personService;
        private readonly IFinanceTypeService _financeTypeService;

        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> repository, IPersonService personService, IFinanceTypeService financeTypeService, IMapper mapper)
        {
            _repository = repository;
            _personService = personService;
            _financeTypeService = financeTypeService;
            _mapper = mapper;
        }

        public StudentsList Get(int pageNumber, int pageSize)
        {
            var students = _repository.Get().Where(st => st.IsDeleted == false).OrderByDescending(st => st.RegistrationNumber).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var studentCount = _repository.Get().Count(st => st.IsDeleted == false);
            var studentTempList = new List<DTOStudent>();
            foreach (var student in students)
            {
                studentTempList.Add(_mapper.Map<Student, DTOStudent>(student));
            }

            var studentsList = new StudentsList
            {
                Students = studentTempList,
                StudentsCount = studentCount
            };

            return studentsList;
        }
        public StudentsList GetByClass(Guid classId)
        {
            var students = _repository.Get().Where(st => st.IsDeleted == false && st.ClassId == classId).OrderByDescending(st => st.RegistrationNumber).ToList();
            var studentCount = _repository.Get().Count(st => st.IsDeleted == false);
            var studentTempList = new List<DTOStudent>();
            foreach (var student in students)
            {
                studentTempList.Add(_mapper.Map<Student, DTOStudent>(student));
            }

            var studentsList = new StudentsList
            {
                Students = studentTempList,
                StudentsCount = studentCount
            };

            return studentsList;
        }
        public StudentsList Get(string searchString, int pageNumber, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return Get(pageNumber, pageSize);
            var students = _repository.Get().Where(st =>
                (
                    st.RegistrationNumber.ToString().Equals(searchString) ||
                    st.Person.Cnic.Contains(searchString) ||
                    st.Person.Phone.Equals(searchString) ||
                    st.Person.FirstName.Contains(searchString) ||
                    st.Person.LastName.Contains(searchString) ||
                    st.Person.Phone.Contains(searchString)
                ) &&
                st.IsDeleted == false
                ).OrderByDescending(st => st.RegistrationNumber).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var studentCount = _repository.Get().Count(st => (
                                                                 st.RegistrationNumber.ToString().Equals(searchString) ||
                                                                 st.Person.Cnic.Contains(searchString) ||
                                                                 st.Person.Phone.Equals(searchString) ||
                                                                 st.Person.FirstName.Contains(searchString) ||
                                                                 st.Person.LastName.Contains(searchString) ||
                                                                 st.Person.Phone.Contains(searchString)
                                                             ) && st.IsDeleted == false);
            var studentTempList = new List<DTOStudent>();
            foreach (var student in students)
            {
                studentTempList.Add(_mapper.Map<Student, DTOStudent>(student));
            }

            var studentsList = new StudentsList()
            {
                Students = studentTempList,
                StudentsCount = studentCount
            };

            return studentsList;
        }
        public DTOStudent Get(Guid id)
        {
            var studentRecord = _repository.Get().FirstOrDefault(st => st.Id == id && st.IsDeleted == false);
            var student = _mapper.Map<Student, DTOStudent>(studentRecord);
            return student;
        }

        public void Update(DTOStudent dtoStudent)
        {
            //var validationResult = Validation(dtoStudentUpdatedState);
            //if (validationResult.IsError)
            //{
            //    return validationResult;
            //}
            var dtoStudentCurrentState = Get(dtoStudent.Id);
            dtoStudent.UpdateDate = DateTime.UtcNow;
            var mergedStudent = _mapper.Map(dtoStudent, dtoStudentCurrentState);
            _personService.Update(mergedStudent.Person);
            HelpingMethodForRelationship(dtoStudent);
            _repository.Update(_mapper.Map<DTOStudent, Student>(mergedStudent));
            //UpsertFinanceDetailsAgainstStudent(dtoStudent, dtoStudentCurrentState);
        }
        public void Create(DTOStudent dtoStudent)
        {
            dtoStudent.CreatedDate = DateTime.UtcNow;
            dtoStudent.IsDeleted = false;
            if (dtoStudent.Id == Guid.Empty)
            {
                dtoStudent.Id = Guid.NewGuid();
            }
            dtoStudent.PersonId = _personService.Create(dtoStudent.Person);
            HelpingMethodForRelationship(dtoStudent);
            _repository.Add(_mapper.Map<DTOStudent, Student>(dtoStudent));
            //InsertStudentFinanceDetail(dtoStudent);
            return;

        }

        public void Delete(Guid? id, string DeletedBy)
        {
            if (id == null)
                return;
            var student = Get(id ?? Guid.Empty);
            student.IsDeleted = true;
            student.DeletedBy = DeletedBy;
            student.DeletedDate = DateTime.UtcNow;
            _personService.Delete(student.PersonId);
            _repository.Update(_mapper.Map<DTOStudent, Student>(student));
        }

        //private void InsertStudentFinanceDetail(DTOStudent dtoStudent)
        //{
        //    var listOfTypeIds = new[] { new { _financeTypeService.GetByName("Admission").Id, FeeAmount = dtoStudent.AdmissionFee },
        //        new { _financeTypeService.GetByName("Monthly").Id, FeeAmount = dtoStudent.MonthlyFee }
        //    }.ToList();

        //    foreach (var type in listOfTypeIds)
        //    {
        //        var stdFinance = new DTOStudentFinanceDetail
        //        {
        //            StudentId = dtoStudent.Id,
        //            IsDeleted = false,
        //            Fee = type.FeeAmount,
        //            CreatedDate = dtoStudent.CreatedDate,
        //            CreatedBy = dtoStudent.CreatedBy,
        //            FinanceTypeId = type.Id
        //        };
        //        if (stdFinance.Id == Guid.Empty)
        //        {
        //            stdFinance.Id = Guid.NewGuid();
        //        }
        //        _studentFinanceDetailsService.Create(stdFinance);
        //    }


        //}




        private void HelpingMethodForRelationship(DTOStudent dtoStudent)
        {
            //dtoStudent.SchoolId = dtoStudent.School.Id;
            //dtoStudent.ClassId = dtoStudent.Class.Id;
            dtoStudent.Person = null;
            dtoStudent.Class = null;
            dtoStudent.School = null;
            dtoStudent.Image = null;
        }
    }
}
