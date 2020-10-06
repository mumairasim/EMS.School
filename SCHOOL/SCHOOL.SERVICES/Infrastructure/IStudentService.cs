using System;
using SCHOOL.DTOs.DTOs;
using DTOStudent = SCHOOL.DTOs.DTOs.Student;

namespace SCHOOL.SERVICES.Infrastructure
{
    public interface IStudentService
    {
        StudentsList Get(int pageNumber, int pageSize);
        StudentsList Get(string searchString, int pageNumber, int pageSize);
        DTOStudent Get(Guid id);
    }
}
