using HIMS.EF.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace HIMS.EF.DAL.Data.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly HIMSDbContext _himsDbContext;
        private SampleRepository _sampleRepository;
        private UserProfileRepository _userProfileRepository;
        private DirectionRepository _directionRepository;
        private vUserProfileRepository _vUserProfileRepository;
        private ProgressRepository _progressRepository;

        public EFUnitOfWork(string connectionString)
        {
            this._himsDbContext = new HIMSDbContext(connectionString);

        }

        public IRepository<Sample> Samples => _sampleRepository ?? (_sampleRepository = new SampleRepository(_himsDbContext));
        public IRepository<UserProfile> UserProfiles => _userProfileRepository ?? (_userProfileRepository = new UserProfileRepository(_himsDbContext));
        public IRepository<Direction> Directions => _directionRepository ?? (_directionRepository = new DirectionRepository(_himsDbContext));
        public IViewRepository<vUserProfile> VUserProfiles => _vUserProfileRepository ?? (_vUserProfileRepository = new vUserProfileRepository(_himsDbContext));
        public IRepository<Progress> Progress => _progressRepository ?? (_progressRepository = new ProgressRepository(_himsDbContext));

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
