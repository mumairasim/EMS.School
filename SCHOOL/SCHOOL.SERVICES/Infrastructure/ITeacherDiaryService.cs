using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ReponseDTOs;
using System;
using DTOTeacherDiary = SCHOOL.DTOs.DTOs.TeacherDiary;

namespace SCHOOL.Services.Infrastructure
{
    public interface ITeacherDiaryService
    {
        #region SMS Section
        TeacherDiariesList Get(int pageNumber, int pageSize);
        DTOTeacherDiary Get(Guid? id);
        TeacherDiaryResponse Create(DTOTeacherDiary teacherDiary);
        TeacherDiaryResponse Update(DTOTeacherDiary dtoTeacherDiary);
        void Delete(Guid? id, string DeletedBy);
        TeacherDiariesList Get(string searchString, int pageNumber, int pageSize);
        #endregion
    }
}



