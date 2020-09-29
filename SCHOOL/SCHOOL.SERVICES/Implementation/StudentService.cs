using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SCHOOL.DATA.Infrastructure;
using SCHOOL.DTOs.DTOs;
using SCHOOL.SERVICES.Infrastructure;
using Student = SCHOOL.DATA.Models.Student;
using DTOStudent = SCHOOL.DTOs.DTOs.Student;

namespace SCHOOL.SERVICES.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public StudentService(IRepository<Student> repository, IPersonService personService, IMapper mapper)
        {
            _repository = repository;
            _personService = personService;
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

            var studentsList = new StudentsList()
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
    }
}
