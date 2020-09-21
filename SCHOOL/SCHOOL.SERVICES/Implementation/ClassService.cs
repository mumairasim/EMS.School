using AutoMapper;
using SCHOOL.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using SCHOOL.DATA.Infrastructure;
using SCHOOL.DTOs.DTOs;
using Class = SCHOOL.DATA.Models.Class;
using DTOClass = SCHOOL.DTOs.DTOs.Class;
using SCHOOL.DTOs.ReponseDTOs;

namespace SCHOOL.Services.Implementation
{
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> _repository;
        private const string ErrorNotFound = "Record not found";
        private const string ServerError = "Server error";

        private readonly IMapper _mapper;
        public ClassService(IRepository<Class> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region SMS Section
        public GenericApiResponse Create(DTOClass dtoClass)
        {
            try
            {
                dtoClass.CreatedDate = DateTime.UtcNow;
                dtoClass.IsDeleted = false;
                if (dtoClass.Id == Guid.Empty)
                {
                    dtoClass.Id = Guid.NewGuid();
                }
                HelpingMethodForRelationship(dtoClass);
                _repository.Add(_mapper.Map<DTOClass, Class>(dtoClass));
                return PrepareSuccessResponse("Created", "Instance Created Successfully");

            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", ServerError);
            }

        }
        public List<DTOClass> Get()
        {
            var classes = _repository.Get().Where(cl => cl.IsDeleted == false).ToList();
            return _mapper.Map<List<Class>, List<DTOClass>>(classes);
        }
        public ClassesList Get(int pageNumber, int pageSize)
        {
            var classes = _repository.Get().Where(cl => cl.IsDeleted == false).OrderByDescending(st => st.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var classCount = _repository.Get().Count(st => st.IsDeleted == false);
            var classTempList = new List<DTOClass>();
            foreach (var classobj in classes)
            {
                classTempList.Add(_mapper.Map<Class, DTOClass>(classobj));
            }
            var classesList = new ClassesList()
            {
                Classes = classTempList,
                classesCount = classCount
            };
            return classesList;
        }
        public DTOClass Get(Guid? id)
        {
            if (id == null) return null;
            var classRecord = _repository.Get().FirstOrDefault(cl => cl.Id == id && cl.IsDeleted == false);
            var classes = _mapper.Map<Class, DTOClass>(classRecord);

            return classes;
        }

        public GenericApiResponse Update(DTOClass dtoClass)
        {
            try
            {
                var classes = Get(dtoClass.Id);
                if (classes != null)
                {
                    dtoClass.UpdateDate = DateTime.UtcNow;
                    var mergedClass = _mapper.Map(dtoClass, classes);
                    _repository.Update(_mapper.Map<DTOClass, Class>(mergedClass));
                    return PrepareSuccessResponse("Updated", "Instance Updated Successfully");
                }
                return PrepareFailureResponse("Error", ErrorNotFound);
            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", ServerError);
            }

        }
        public void Delete(Guid? id, string deletedBy)
        {
            if (id == null)
                return;
            var classes = Get(id);
            classes.IsDeleted = true;
            classes.DeletedDate = DateTime.UtcNow;
            classes.DeletedBy = deletedBy;
            _repository.Update(_mapper.Map<DTOClass, Class>(classes));
        }
        #endregion

        private void HelpingMethodForRelationship(DTOClass dtoClass)
        {
            dtoClass.SchoolId = dtoClass.School.Id;
            dtoClass.School = null;
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

    }
}




