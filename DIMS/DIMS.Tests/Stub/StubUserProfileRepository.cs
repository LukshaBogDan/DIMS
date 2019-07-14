using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests.Stub
{
    public class StubUserProfileRepository : IRepository<UserProfile>
    {
        readonly List<UserProfile> _UserProfiles;

        public StubUserProfileRepository()
        {
            _UserProfiles = new List<UserProfile>()
            {
                new UserProfile(){UserId = 1, Name = "Ivan", DirectionId = 1},
                new UserProfile(){UserId = 2, Name = "Petr", DirectionId = 2},
                new UserProfile(){UserId = 3, Name = "Maxim", DirectionId = 1},
            };
        }

        public void Create(UserProfile item)
        {
            _UserProfiles.Add(item);
        }

        public void Delete(int id)
        {
            var entity = _UserProfiles.Find(x => x.UserId == id);
            if (entity != null)
            {
                _UserProfiles.Remove(entity);
            }
        }

        public IEnumerable<UserProfile> Find(Func<UserProfile, bool> predicate)
        {
            return _UserProfiles.Where(predicate).ToList();
        }

        public UserProfile Get(int id)
        {
            return _UserProfiles.Find(x => x.UserId == id);
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return _UserProfiles;
        }

        public void Update(UserProfile item)
        {
            var userProfile = _UserProfiles.Find(x => x.UserId == item.UserId);
            int index = _UserProfiles.IndexOf(userProfile);
            _UserProfiles[index] = item;
        }
    }
}
