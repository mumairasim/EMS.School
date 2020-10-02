using System;
using AutoMapper;
using SCHOOL.DATA.Infrastructure;
using SCHOOL.DTOs.ReponseDTOs;
using SCHOOL.Services.Infrastructure;
using TimeTableDetail = SCHOOL.DATA.Models.TimeTableDetail;
using DTOTimeTableDetail = SCHOOL.DTOs.DTOs.TimeTableDetail;

namespace SCHOOL.Services.Implementation
{
    public class TimeTableDetailService : ITimeTableDetailService
    {
        private readonly IRepository<TimeTableDetail> _repository;
        private readonly IMapper _mapper;
        private readonly IPeriodService _periodService;
        public TimeTableDetailService(IRepository<TimeTableDetail> repository, IMapper mapper, IPeriodService periodService)
        {
            _repository = repository;
            _mapper = mapper;
            _periodService = periodService;
        }
        #region SMS Section
        public GenericApiResponse Create(DTOTimeTableDetail dtoTimeTableDetail)
        {
            try
            {
                dtoTimeTableDetail.CreatedDate = DateTime.Now;
                dtoTimeTableDetail.IsDeleted = false;

                if (dtoTimeTableDetail.Id == Guid.Empty)
                {
                    dtoTimeTableDetail.Id = Guid.NewGuid();
                }

                //Old implementation
                //var timeTableDetail = _repository.Add(_mapper.Map<DTOTimeTableDetail, TimeTableDetail>(dtoTimeTableDetail));
                _repository.Add(_mapper.Map<DTOTimeTableDetail, TimeTableDetail>(dtoTimeTableDetail));
                if (dtoTimeTableDetail.Periods != null)
                    foreach (var period in dtoTimeTableDetail.Periods)
                    {
                        //period.TimeTableDetailId = timeTableDetail.Id;
                        period.TimeTableDetailId = Guid.NewGuid();
                        _periodService.Create(period);
                    }

                return PrepareSuccessResponse("success", "");
            }
            catch (Exception e)
            {
                return PrepareFailureResponse("error", e.Message);
            }
        }
        private GenericApiResponse PrepareFailureResponse(string errorMessage, string descriptionMessage)
        {
            return new GenericApiResponse
            {
                StatusCode = "400",
                Message = errorMessage,
                Description = descriptionMessage
            };
        }
        private GenericApiResponse PrepareSuccessResponse(string message, string descriptionMessage)
        {
            return new GenericApiResponse
            {
                StatusCode = "200",
                Message = message,
                Description = descriptionMessage
            };
        }
        #endregion
    }
}
