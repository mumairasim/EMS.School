﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SCHOOL.DATA.Models
{
    [Table("Files")]
    public class File : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
    }
}
