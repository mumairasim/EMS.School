using AutoMapper;
using SCHOOL.DATA.Infrastructure;
using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ReponseDTOs;
using SCHOOL.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Course = SCHOOL.DATA.Models.Course;
using DTOCourse = SCHOOL.DTOs.DTOs.Course;

namespace SCHOOL.Services.Implementation
{
    public class CourseService : ICourseService
    {
        #region Properties
        private readonly IRepository<Course> _repository;

        private const string error_not_found = "Record not found";
        private const string server_error = "Server error";
        private IMapper _mapper;
        #endregion

        #region Init

        public CourseService(IRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region SMS Section

        /// <summary>
        /// Service level call : Creates a single record of a Course
        /// </summary>
        /// <param name="dtoCourse"></param>
        /// 

        public GenericApiResponse Create(DTOCourse dtoCourse)
        {
            try
            {
                dtoCourse.CreatedDate = DateTime.UtcNow;
                dtoCourse.IsDeleted = false;
                if (dtoCourse.Id == Guid.Empty)
                {
                    dtoCourse.Id = Guid.NewGuid();
                }
                _repository.Add(_mapper.Map<DTOCourse, Course>(dtoCourse));
                return PrepareSuccessResponse("Created", "Instance Created Successfully");

            }
            catch (Exception)
            {
                return PrepareFailureResponse("Error", server_error);
            }
        }

        /// <summary>
        /// Service level call : Delete a single record of a Course
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid? id)
        {
            if (id == null)
                return;
            var course = Get(id);
            if (course != null)
            {
                course.IsDeleted = true;
                course.DeletedDate = DateTime.UtcNow;

                _repository.Update(_mapper.Map<DTOCourse, Course>(course));
            }
        }

        public CoursesList Get(string searchString, int pageNumber, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return Get(pageNumber, pageSize);
            var courses = _repository.Get().Where(st =>
                (
                    st.CourseName.Contains(searchString) ||
                    st.CourseCode.Contains(searchString)
                ) &&
                st.IsDeleted == false
                ).OrderByDescending(st => st.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

            var courseCount = _repository.Get().Count(st => (
            st.CourseName.Contains(searchString) ||
            st.CourseCode.Contains(searchString)
            ) && st.IsDeleted == false);

            var courseTempList = new List<DTOCourse>();
            foreach (var course in courses)
            {
                courseTempList.Add(_mapper.Map<Course, DTOCourse>(course));
            }

            var coursesList = new CoursesList()
            {
                Courses = courseTempList,
                CoursesCount = courseCount
            };

            return coursesList;
        }


        public CoursesList Get(int pageNumber, int pageSize)
        {
            var courses = _repository.Get().Where(st => st.IsDeleted == false).OrderByDescending(st => st.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var courseCount = _repository.Get().Count(st => st.IsDeleted == false);
            var courseTempList = new List<DTOCourse>();
            foreach (var course in courses)
            {
                courseTempList.Add(_mapper.Map<Course, DTOCourse>(course));
            }

            var coursesList = new CoursesList()
            {
                Courses = courseTempList,
                CoursesCount = courseCount
            };

            return coursesList;
        }

        /// <summary>
        /// Retruns a Single Record of a Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTOCourse Get(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var course = _repository.Get().FirstOrDefault(x => x.Id == id && (x.IsDeleted == false || x.IsDeleted == null));
            var courseDto = _mapper.Map<Course, DTOCourse>(course);

            return courseDto;
        }

        /// <summary>
        /// Service level call : Updates the Single Record of a Course 
        /// </summary>
        /// <param name="dtoCourse"></param>
        /// 

        public GenericApiResponse Update(DTOCourse dtoCourse)
        {
            try
            {
                var course = Get(dtoCourse.Id);
                if (course != null)
                {
                    dtoCourse.UpdateDate = DateTime.UtcNow;
                    var updated = _mapper.Map(dtoCourse, course);
                    dtoCourse.IsDeleted = false;

                    _repository.Update(_mapper.Map<DTOCourse, Course>(updated));
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
        /// Service level call : Return all records of course
        /// </summary>
        /// <returns></returns>
        public List<DTOCourse> GetAll()
        {
            var courses = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var courseList = new List<DTOCourse>();
            foreach (var course in courses)
            {
                courseList.Add(_mapper.Map<Course, DTOCourse>(course));
            }
            return courseList;
        }

        public List<DTOCourse> GetAllBySchool(Guid? schoolId)
        {
            var courses = _repository.Get().Where(x => (x.IsDeleted == false || x.IsDeleted == null)).ToList();
            var courseList = new List<DTOCourse>();
            foreach (var course in courses)
            {
                courseList.Add(_mapper.Map<Course, DTOCourse>(course));
            }
            return courseList;
        }

        #endregion

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