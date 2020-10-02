﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SCHOOL.DATA.Infrastructure;
using SCHOOL.DATA.Models;
using SCHOOL.Services.Infrastructure;
using DTODesignation = SCHOOL.DTOs.DTOs.Designation;

namespace SCHOOL.Services.Implementation
{
    public class DesignationService : IDesignationService
    {
        private readonly IRepository<Designation> _repository;
        private IMapper _mapper;
        public DesignationService(IRepository<Designation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #region SMS Section
        public List<DTODesignation> Get()
        {
            var designations = _repository.Get().Where(d => d.IsDeleted == false).ToList();
            var designationList = new List<DTODesignation>();
            foreach (var designation in designations)
            {
                designationList.Add(_mapper.Map<Designation, DTODesignation>(designation));
            }
            return designationList;
        }
        public DTODesignation Get(Guid? id)
        {
            if (id == null) return null;
            var designationRecord = _repository.Get().FirstOrDefault(d => d.Id == id && d.IsDeleted == false);
            if (designationRecord == null) return null;

            return _mapper.Map<Designation, DTODesignation>(designationRecord);
        }
        public Guid Create(DTODesignation dtoDesignation)
        {
            dtoDesignation.CreatedDate = DateTime.UtcNow;
            dtoDesignation.IsDeleted = false;
            if (dtoDesignation.Id == Guid.Empty)
            {
                dtoDesignation.Id = Guid.NewGuid();
            }
            _repository.Add(_mapper.Map<DTODesignation, Designation>(dtoDesignation));
            return dtoDesignation.Id;
        }
        public void Update(DTODesignation dtoDesignation)
        {
            var designation = Get(dtoDesignation.Id);
            dtoDesignation.UpdateDate = DateTime.UtcNow;
            var mergedDesignation = _mapper.Map(dtoDesignation, designation);
            _repository.Update(_mapper.Map<DTODesignation, Designation>(mergedDesignation));
        }
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var designation = Get(id);
            designation.IsDeleted = true;
            designation.DeletedDate = DateTime.UtcNow;
            _repository.Update(_mapper.Map<DTODesignation, Designation>(designation));
        }
        #endregion

    }
}
