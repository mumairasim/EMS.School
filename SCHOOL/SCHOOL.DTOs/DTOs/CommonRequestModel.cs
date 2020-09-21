﻿using System;

namespace SCHOOL.DTOs.DTOs
{
    public class CommonRequestModel : DtoBaseEntity
    {
        public RequestType RequestType { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public string RequestFor { get; set; }
        public Guid? SchoolId { get; set; }
        public School School { get; set; }
    }
}
