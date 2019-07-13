using System;

namespace HIMS.EF.DAL.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Sample> Samples { get; }

        void Save();
    }
}
