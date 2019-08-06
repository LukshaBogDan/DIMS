using HIMS.EF.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Sample> Samples { get; }
        IRepository<UserProfile> UserProfiles { get; }
        IRepository<Direction> Directions { get; }
        IViewRepository<vUserProfile> VUserProfiles { get; }
        IRepository<Progress> Progress { get; }
        void Save();
    }
}
