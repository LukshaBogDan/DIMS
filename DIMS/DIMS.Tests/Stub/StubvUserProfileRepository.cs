using HIMS.EF.DAL.Data;
using HIMS.EF.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests.Stub
{
    public class StubvUserProfileRepository : IViewRepository<vUserProfile>
    {
        readonly List<vUserProfile> _vUserProfiles;

        public StubvUserProfileRepository()
        {
            _vUserProfiles = new List<vUserProfile>()
            {
                new vUserProfile(){UserId = 1, FullName = "Ivan Ivanov"},
                new vUserProfile(){UserId = 2, FullName = "Petr Petrov"},
                new vUserProfile(){UserId = 3, FullName = "Maxim Maximov"},
            };
        }

        public IEnumerable<vUserProfile> Find(Func<vUserProfile, bool> predicate)
        {
            return _vUserProfiles.Where(predicate).ToList();
        }

        public vUserProfile Get(int id)
        {
            return _vUserProfiles.Find(x => x.UserId == id);
        }

        public IEnumerable<vUserProfile> GetAll()
        {
            return _vUserProfiles;
        }
    }
}
