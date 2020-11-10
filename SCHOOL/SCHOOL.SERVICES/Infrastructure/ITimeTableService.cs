using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ReponseDTOs;
using System;
using DTOTimeTable = SCHOOL.DTOs.DTOs.TimeTable;

namespace SCHOOL.Services.Infrastructure
{
    public interface ITimeTableService
    {
        #region SMS Section
        TimeTableList Get(Guid? schoolId, Guid? classId, int pageNumber, int pageSize);
        TimeTableList Get(int pageNumber, int pageSize);
        GenericApiResponse Create(DTOTimeTable teacherDiary);
        #endregion

    }
}





