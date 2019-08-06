using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data.Repositories
{
    class ProgressRepository : IRepository<Progress>
    {
        private readonly HIMSDbContext _himsDbContext;

        public ProgressRepository(HIMSDbContext himsDbContext)
        {
            _himsDbContext = himsDbContext;
        }

        public void Create(Progress item)
        {
            _himsDbContext.Progress.Add(item);
        }

        public void Delete(int id)
        {
            var entity = _himsDbContext.Progress.Find(id);
            if (entity != null)
            {
                _himsDbContext.Progress.Remove(entity);
            }
        }

        public IEnumerable<Progress> Find(Func<Progress, bool> predicate)
        {
            return _himsDbContext.Progress.Where(predicate).ToList();
        }

        public Progress Get(int id)
        {
            return _himsDbContext.Progress.Find(id);
        }

        public IEnumerable<Progress> GetAll()
        {
            return _himsDbContext.Progress;
        }

        public void Update(Progress item)
        {
            _himsDbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
