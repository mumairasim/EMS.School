﻿

namespace SCHOOL.DATA.Infrastructure
{
    public interface IUnitOfWork
    {
        IDbContext Context { get; }

        void Commit();
    }
}
