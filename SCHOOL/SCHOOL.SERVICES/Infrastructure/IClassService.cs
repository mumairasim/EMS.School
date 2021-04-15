using System;
using System.Collections.Generic;
using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ReponseDTOs;
using DTOClass = SCHOOL.DTOs.DTOs.Class;

namespace SCHOOL.Services.Infrastructure
{
    public interface IClassService
    {
        #region SMS Section

        List<DTOClass> Get(string SearchParam = null);

        ClassesList Get(int pageNumber, int pageSize);
        DTOClass Get(Guid? id);
        GenericApiResponse Create(DTOClass Class);
        GenericApiResponse Update(DTOClass dtoClass);
        void Delete(Guid? id, string deletedBy);
        #endregion

    }
}

