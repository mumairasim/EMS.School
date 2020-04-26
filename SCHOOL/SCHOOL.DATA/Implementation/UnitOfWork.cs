using SCHOOL.DATA.Infrastructure;
using SchoolSystemContext = SCHOOL.DATA.Models.SchoolSystem;

namespace SCHOOL.DATA.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbContext Context { get; }

        public UnitOfWork()
        {
            Context = new SchoolSystemContext();
        }
        public void Commit()
        {
            Context.SaveChanges();
        }



    }
}
