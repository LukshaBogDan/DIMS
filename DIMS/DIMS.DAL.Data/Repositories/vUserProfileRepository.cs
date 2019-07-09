using HIMS.EF.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data.Repositories
{
    public class vUserProfileRepository : IViewRepository<vUserProfile>
    {

        private readonly HIMSDbContext _himsDbContext;

        public vUserProfileRepository(HIMSDbContext himsDbContext)
        {
            _himsDbContext = himsDbContext;
        }

        public IEnumerable<vUserProfile> Find(Func<vUserProfile, bool> predicate)
        {
            return _himsDbContext.vUserProfiles.Where(predicate).ToList();
        }

        public vUserProfile Get(int id)
        {
            return _himsDbContext.vUserProfiles.Find(id);
        }

        public IEnumerable<vUserProfile> GetAll()
        {
            return _himsDbContext.vUserProfiles;
        }
    }
}
