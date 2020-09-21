﻿using System;

namespace SCHOOL.DTOs.DTOs
{
    public class RequestType
    {
        public Guid Id { get; set; }
        public string Value { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public Guid? DeletedBy { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
