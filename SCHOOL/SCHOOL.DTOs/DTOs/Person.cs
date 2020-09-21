using System;
namespace SCHOOL.DTOs.DTOs
{
    public class Person : DtoBaseEntity
    {

        public Guid? AspNetUserId { get; set; }
        public int? Age { get; set; }
        public DateTime? DOB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentName { get; set; }
        public string Cnic { get; set; }
        public string ParentCnic { get; set; }

        public string Nationality { get; set; }

        public string Religion { get; set; }

        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string ParentOccupation { get; set; }
        public string ParentRelation { get; set; }
        public string ParentHighestEducation { get; set; }
        public string ParentNationality { get; set; }
        public string ParentEmail { get; set; }
        public string ParentOfficeAddress { get; set; }
        public string ParentCity { get; set; }
        public string ParentMobile1 { get; set; }
        public string ParentMobile2 { get; set; }
        public string ParentEmergencyName { get; set; }
        public string ParentEmergencyRelation { get; set; }
        public string ParentEmergencyMobile { get; set; }

        public string Phone { get; set; }

        public Guid? ImageId { get; set; }
        public virtual File Image { get; set; }

    }
}
