using SCHOOL.DTOs.DTOs;

namespace SCHOOL.SERVICES.Infrastructure
{
    public interface IStudentService
    {
        StudentsList Get(int pageNumber, int pageSize);
        StudentsList Get(string searchString, int pageNumber, int pageSize);
    }
}
