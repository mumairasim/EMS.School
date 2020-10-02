using SCHOOL.DTOs.DTOs;
using SCHOOL.DTOs.ReponseDTOs;
using System;
using DTOLessonPlan = SCHOOL.DTOs.DTOs.LessonPlan;

namespace SCHOOL.Services.Infrastructure
{
    public interface ILessonPlanService
    {
        #region SMS Section
        LessonPlansList Get(int pageNumber, int pageSize);
        //List<DTOLessonPlan> Get();
        DTOLessonPlan Get(Guid? id);
        LessonPlanResponse Create(DTOLessonPlan lessonplan);
        LessonPlanResponse Update(DTOLessonPlan dtolessonplan);
        void Delete(Guid? id, string DeletedBy);
        #endregion
    }
}


