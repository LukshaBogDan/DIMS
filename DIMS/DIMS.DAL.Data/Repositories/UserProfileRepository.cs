using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data.Repositories
{
    class UserProfileRepository : IRepository<UserProfile>
    {
        private readonly HIMSDbContext _himsDbContext;

        public UserProfileRepository(HIMSDbContext himsDbContext)
        {
            _himsDbContext = himsDbContext;
        }

        public void Create(UserProfile item)
        {
            _himsDbContext.UserProfiles.Add(item);
        }

        public void Delete(int id)
        {
            var entity = _himsDbContext.UserProfiles.Find(id);
            if (entity != null)
            {
                _himsDbContext.UserProfiles.Remove(entity);
            }
        }

        public IEnumerable<UserProfile> Find(Func<UserProfile, bool> predicate)
        {
            return _himsDbContext.UserProfiles.Where(predicate).ToList();
        }

        public UserProfile Get(int id)
        {
            return _himsDbContext.UserProfiles.Find(id);
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return _himsDbContext.UserProfiles;
        }

        public void Update(UserProfile item)
        {
            _himsDbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
