using SCHOOL.DTOs.ReponseDTOs;
using DTOPeriod = SCHOOL.DTOs.DTOs.Period;

namespace SCHOOL.Services.Infrastructure
{
    public interface IPeriodService
    {
        #region SMS Section
        GenericApiResponse Create(DTOPeriod timeTableDetail);
        #endregion
    }
}





