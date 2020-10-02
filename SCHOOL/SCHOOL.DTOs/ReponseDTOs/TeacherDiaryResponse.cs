using System;

namespace SCHOOL.DTOs.ReponseDTOs
{
    public class TeacherDiaryResponse : GenericApiResponse
    {
        public Guid? Id { get; set; }
        public bool IsError { get; set; }
    }
}
