using SCHOOL.DTOs.ReponseDTOs;
using DTOTimeTableDetail = SCHOOL.DTOs.DTOs.TimeTableDetail;

namespace SCHOOL.Services.Infrastructure
{
    public interface ITimeTableDetailService
    {
        #region SMS
        GenericApiResponse Create(DTOTimeTableDetail timeTableDetail);
        #endregion
    }
}





