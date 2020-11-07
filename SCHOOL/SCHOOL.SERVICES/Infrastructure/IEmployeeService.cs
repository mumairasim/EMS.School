using System;
using System.Collections.Generic;
using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ReponseDTOs;
using DTOEmployee = SCHOOL.DTOs.DTOs.Employee;

namespace SCHOOL.Services.Infrastructure
{

    public interface IEmployeeService
    {
        #region SMS Section
        EmployeesList Get(int pageNumber, int pageSize);
        List<DTOEmployee> GetTeachers();
        EmployeesList Get(int? employeeNumber, int pageNumber, int pageSize);
        EmployeesList Get(string searchString, int pageNumber, int pageSize);
        DTOEmployee Get(Guid? id);
        List<DTOEmployee> GetEmployeeByDesignation();
        EmployeeResponse Create(DTOEmployee employee);
        EmployeeResponse Update(DTOEmployee dtoEmployee);
        void Delete(Guid? id, string DeletedBy);
        #endregion
    }

}

