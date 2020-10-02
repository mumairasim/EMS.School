using SCHOOL.DTOs.DTOs;
using System;
using DTOStudentDiary = SCHOOL.DTOs.DTOs.StudentDiary;

namespace SCHOOL.Services.Infrastructure
{
    public interface IStudentDiaryService
    {
        #region SMS Section
        StudentDiariesList Get(int pageNumber, int pageSize);
        DTOStudentDiary Get(Guid? id);
        void Create(DTOStudentDiary StudentDiary);
        void Update(DTOStudentDiary dtoStudentDiary);
        void Delete(Guid? id, string DeletedBy);
        #endregion

    }
}
