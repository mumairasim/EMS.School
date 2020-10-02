using System;
using System.Collections.Generic;
using DTOPerson = SCHOOL.DTOs.DTOs.Person;

namespace SCHOOL.SERVICES.Infrastructure
{
    public interface IPersonService
    {
        List<DTOPerson> Get();
        DTOPerson Get(Guid? id);
        Guid Create(DTOPerson dtoPerson);
        void Update(DTOPerson dtoPerson);
        void Delete(Guid? id);
    }
}
