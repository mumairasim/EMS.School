using AutoMapper;
using SCHOOL.DATA.Infrastructure;
using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ReponseDTOs;
using SCHOOL.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DBWorksheet = SCHOOL.DATA.Models.Worksheet;
using DTOWorksheet = SCHOOL.DTOs.DTOs.Worksheet;

namespace SCHOOL.Services.Implementation
{
    public class WorksheetService : IWorksheetService
    {
        #region Properties
        private readonly IRepository<DBWorksheet> _repository;
        private const string error_not_found = "Record not found";
        private const string server_error = "Server error";

        private IMapper _mapper;
        #endregion

        #region Init

        public WorksheetService(IRepository<DBWorksheet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region SMS

        /// <summary>
        /// Service level call : Creates a single record of a Worksheet
        /// </summary>
        /// <param name="dTOWorksheet"></param>
        public GenericApiResponse Create(DTOWorksheet dTOWorksheet)
        {
            try
            {
                dTOWorksheet.CreatedDate = DateTime.UtcNow;
                dTOWorksheet.IsDeleted = false;

                //below check is to create request type instances with the same Ids in both DBs, 
                //if request is from front end then assign a new Id
                if (dTOWorksheet.Id == Guid.Empty)
                {
                    dTOWorksheet.Id = Guid.NewGuid();
                }

                _repository.Add(_mapper.Map<DTOWorksheet, DBWorksheet>(dTOWorksheet));
                return PrepareSuccessResponse("Created", "Instance Created Successfully");

            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", server_error);
            }
        }

        /// <summary>
        /// Service level call : Delete a single record of a Worksheet
        /// </summary>
        /// <param name="id"></param>
        public GenericApiResponse Delete(Guid? id)
        {
            try
            {
                if (id == null)
                    return null;
                var worksheet = Get(id);
                if (worksheet != null)
                {
                    worksheet.IsDeleted = true;
                    worksheet.DeletedDate = DateTime.UtcNow;
                    _repository.Update(_mapper.Map<DTOWorksheet, DBWorksheet>(worksheet));
                    return PrepareSuccessResponse("Deleted", "Instance Deleted Successfully");
                }
                return PrepareFailureResponse("Error", error_not_found);
            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", server_error);
            }

        }

        /// <summary>
        /// Retruns a Single Record of a Worksheet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOWorksheet Get(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var worksheet = _repository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var worksheetDto = _mapper.Map<DBWorksheet, DTOWorksheet>(worksheet);

            return worksheetDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a Worksheet 
        /// </summary>
        /// <param name="dtoWorksheet"></param>
        public GenericApiResponse Update(DTOWorksheet dtoWorksheet)
        {
            try
            {
                var worksheet = Get(dtoWorksheet.Id);
                if (worksheet != null)
                {
                    dtoWorksheet.UpdateDate = DateTime.UtcNow;
                    dtoWorksheet.IsDeleted = false;
                    var updated = _mapper.Map(dtoWorksheet, worksheet);
                    var updatedDbRec = _mapper.Map<DTOWorksheet, DBWorksheet>(updated);
                    _repository.Update(updatedDbRec);
                    return PrepareSuccessResponse("Updated", "Instance Updated Successfully");
                }
                return PrepareFailureResponse("Error", error_not_found);
            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", server_error);
            }
        }

        /// <summary>
        /// Service level call : Return all records of a Worksheet
        /// </summary>
        /// <returns></returns>
        List<DTOWorksheet> IWorksheetService.GetAll()
        {
            var worksheets = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var worksheetList = new List<DTOWorksheet>();
            foreach (var worksheet in worksheets)
            {
                worksheetList.Add(_mapper.Map<DBWorksheet, DTOWorksheet>(worksheet));
            }
            return worksheetList;
        }


        public WorksheetList Get(string searchString, int pageNumber, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return Get(pageNumber, pageSize);
            var worksheets = _repository.Get().Where(st =>
                (
                    st.Text.ToString().Equals(searchString)
                ) &&
                st.IsDeleted == false
                ).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

            var worksheetTempList = new List<DTOWorksheet>();
            foreach (var worksheet in worksheets)
            {
                worksheetTempList.Add(_mapper.Map<DBWorksheet, DTOWorksheet>(worksheet));
            }

            var worksheetsList = new WorksheetList()
            {
                Worksheets = worksheetTempList
            };

            return worksheetsList;
        }


        /// <summary>
        /// Service level call : Return all records of a Worksheet
        /// </summary>
        /// <returns></returns>
        public WorksheetList Get(int pageNumber, int pageSize)
        {
            var worksheets = _repository.Get().Where(st => st.IsDeleted == false).OrderByDescending(x => x.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var worksheetTempList = new List<DTOWorksheet>();
            foreach (var worksheet in worksheets)
            {
                worksheetTempList.Add(_mapper.Map<DBWorksheet, DTOWorksheet>(worksheet));
            }

            var worksheetsList = new WorksheetList()
            {
                Worksheets = worksheetTempList,
            };

            return worksheetsList;
        }

        #endregion

        #region Utils
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
