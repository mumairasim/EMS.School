using System;
using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ReponseDTOs;
using DTOStudent = SCHOOL.DTOs.DTOs.Student;

namespace SCHOOL.SERVICES.Infrastructure
{
    public interface IStudentService
    {
        StudentsList Get(int pageNumber, int pageSize);
        StudentsList GetByClass(Guid classId);
        StudentsList Get(string searchString, int pageNumber, int pageSize);
        DTOStudent Get(Guid id);
        void Create(DTOStudent student);
        void Update(DTOStudent dtoStudent);
        void Delete(Guid? id, string DeletedBy);
    }
}
