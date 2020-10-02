﻿using System;
using System.Collections.Generic;
using DTODesignation = SCHOOL.DTOs.DTOs.Designation;
namespace SCHOOL.Services.Infrastructure
{
    public interface IDesignationService
    {
        #region SMS Section
        List<DTODesignation> Get();
        DTODesignation Get(Guid? id);
        Guid Create(DTODesignation dtoDesignation);
        void Update(DTODesignation dtoDesignation);
        void Delete(Guid? id);
        #endregion
    }
}
