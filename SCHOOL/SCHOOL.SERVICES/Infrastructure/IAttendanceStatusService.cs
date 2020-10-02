using System;
using System.Collections.Generic;
using DTOAttendanceStatus = SCHOOL.DTOs.DTOs.AttendanceStatus;
namespace SCHOOL.Services.Infrastructure
{
    public interface IAttendanceStatusService
    {
        #region SMS Section
        List<DTOAttendanceStatus> Get();
        DTOAttendanceStatus Get(Guid? id);
        Guid Create(DTOAttendanceStatus dtoAttendanceStatus);
        void Update(DTOAttendanceStatus dtoAttendanceStatus);
        void Delete(Guid? id);
        #endregion

    }
}
