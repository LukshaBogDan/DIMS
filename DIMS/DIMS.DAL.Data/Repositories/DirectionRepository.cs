using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Data.Repositories
{
    class DirectionRepository : IRepository<Direction>
    {
        private readonly HIMSDbContext _himsDbContext;

        public DirectionRepository(HIMSDbContext himsDbContext)
        {
            _himsDbContext = himsDbContext;
        }

        public void Create(Direction item)
        {
            _himsDbContext.Directions.Add(item);
        }

        public void Delete(int id)
        {
            var entity = _himsDbContext.Directions.Find(id);
            if (entity != null)
            {
                _himsDbContext.Directions.Remove(entity);
            }
        }

        public IEnumerable<Direction> Find(Func<Direction, bool> predicate)
        {
            return _himsDbContext.Directions.Where(predicate).ToList();
        }

        public Direction Get(int id)
        {
            return _himsDbContext.Directions.Find(id);
        }

        public IEnumerable<Direction> GetAll()
        {
            return _himsDbContext.Directions;
        }

        public void Update(Direction item)
        {
            _himsDbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
