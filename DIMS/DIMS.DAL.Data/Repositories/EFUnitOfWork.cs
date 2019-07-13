using System;

namespace HIMS.EF.DAL.Data.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly HIMSDbContext _himsDbContext;
        private SampleRepository _sampleRepository;

        public EFUnitOfWork(string connectionString)
        {
            this._himsDbContext = new HIMSDbContext(connectionString);
        }

        public IRepository<Sample> Samples => _sampleRepository ?? (_sampleRepository = new SampleRepository(_himsDbContext));

        public void Save()
        {
            _himsDbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Release managed resources
                    _himsDbContext.Dispose();
                }
                //release unmanaged resources
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
