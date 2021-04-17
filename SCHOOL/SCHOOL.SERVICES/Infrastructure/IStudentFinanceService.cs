using System;
using System.Collections.Generic;
using DTOStudentFinances = SCHOOL.DTOs.DTOs.StudentFinances;
using DBStudentFinances = SCHOOL.DATA.Models.Student_Finances;
using DTOStudentFinanceCustom = SCHOOL.DTOs.DTOs.StudentFinanceInfo;

namespace SCHOOL.Services.Infrastructure
{
    public interface IStudentFinanceService
    {
        #region SMS 
        /// <summary>
        /// Service level call : Return all records of a StudentFinances
        /// </summary>
        /// <returns></returns>
        List<DTOStudentFinances> GetAll();
        List<DBStudentFinances> GetAllByFilter(bool isSubmit,string Year=null,string month=null);
        List<DBStudentFinances> GetAllByMonth(string Year = null, string month = null);
        /// <summary>
        /// Service level call : Return filtered records of a StudentFinances, pass null to ignore filters
        /// </summary>
        /// <returns></returns>
        List<DTOStudentFinanceCustom> GetByFilter(Guid? schoolId, Guid? classId, Guid? studentId, string feeMonth);

        /// <summary>
        /// Service level call : Return filtered records of a StudentFinances, pass null to ignore filters
        /// </summary>
        /// <returns></returns>
        List<DTOStudentFinanceCustom> GetDetailByFilter(Guid? schoolId, Guid? ClassId, int? Regno, string Month, string Year);

        /// <summary>
        /// Retruns a Single Record of a StudentFinances
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOStudentFinances Get(Guid? id);

        /// <summary>
        /// Service level call : Creates a single record of a StudentFinances
        /// </summary>
        /// <param name="dtoStudentFinances"></param>
        void Create(DTOStudentFinanceCustom dTOStudentFinances);

        /// <summary>
        /// Service level call : Updates the Single Record of a StudentFinances 
        /// </summary>
        /// <param name="dtoStudentFinances"></param>
        void Update(DTOStudentFinances dTOStudentFinances);

        /// <summary>
        /// Service level call : Delete a single record of a StudentFinances
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid? id);
        #endregion
    }
}
