using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ReponseDTOs;
using System;
using System.Linq.Expressions;
using DTOStudentAttendance = SCHOOL.DTOs.DTOs.StudentAttendance;
using StudentAttendance = SCHOOL.DATA.Models.StudentAttendance;

namespace SCHOOL.Services.Infrastructure
{
    public interface IStudentAttendanceService
    {
        #region SMS Section
        StudentsAttendanceList Get(int pageNumber, int pageSize);
        StudentsAttendanceList Get(Guid? classId, Guid? schoolId, int pageNumber, int pageSize);
        StudentsAttendanceList Search(Expression<Func<StudentAttendance, bool>> predicate, int pageNumber, int pageSize);
        DTOStudentAttendance Get(Guid? id);
        StudentAttendanceResponse Create(DTOStudentAttendance dtoStudentAttendance);
        StudentAttendanceResponse Update(DTOStudentAttendance dtoStudentAttendance);
        void Delete(Guid? id, string deletedBy);
        #endregion

    }
}
