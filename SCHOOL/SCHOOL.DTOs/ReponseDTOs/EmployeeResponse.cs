using System;

namespace SCHOOL.DTOs.ReponseDTOs
{
    public class EmployeeResponse : GenericApiResponse
    {
        public Guid? Id { get; set; }
        public bool IsError { get; set; }
    }
}


