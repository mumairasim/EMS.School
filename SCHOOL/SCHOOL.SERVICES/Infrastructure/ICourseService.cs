﻿using SCHOOL.DTOs.ReponseDTOs;
using System;
using System.Collections.Generic;
using DTOCourse = SCHOOL.DTOs.DTOs.Course;

namespace SCHOOL.Services.Infrastructure
{
    public interface ICourseService
    {
        #region SMS Section
        /// <summary>
        /// Service level call : Return all records of course
        /// </summary>
        /// <returns></returns>
        List<DTOCourse> GetAll();

        /// <summary>
        /// Retruns a Single Record of a Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTOCourse Get(Guid? id);

        /// <summary>
        /// Service level call : Creates a single record of a Course
        /// </summary>
        /// <param name="dtoCourse"></param>
        GenericApiResponse Create(DTOCourse student);

        /// <summary>
        /// Service level call : Updates the Single Record of a Course 
        /// </summary>
        /// <param name="dtoCourse"></param>
        GenericApiResponse Update(DTOCourse dtoStudent);

        /// <summary>
        /// Service level call : Delete a single record of a Course
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid? id);

        List<DTOCourse> GetAllBySchool(Guid? schoolId);
        #endregion
    }
}