using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests.Stub
{
    public class StubDirectionRepository : IRepository<Direction>
    {
        readonly List<Direction> _Directions;

        public StubDirectionRepository()
        {
            _Directions = new List<Direction>()
            {
                new Direction(){DirectionId = 1, Name = ".Net"},
                new Direction(){DirectionId = 2, Name = "Java"},
                new Direction(){DirectionId = 3, Name = "Front"}
            };
        }

        public void Create(Direction item)
        {
            _Directions.Add(item);
        }

        public void Delete(int id)
        {
            var entity = _Directions.Find(x => x.DirectionId == id);
            if (entity != null)
            {
                _Directions.Remove(entity);
            }
        }

        public IEnumerable<Direction> Find(Func<Direction, bool> predicate)
        {
            return _Directions.Where(predicate).ToList();
        }

        public Direction Get(int id)
        {
            return _Directions.Find(x => x.DirectionId == id);
        }

        public IEnumerable<Direction> GetAll()
        {
            return _Directions;
        }

        public void Update(Direction item)
        {
            var direction = _Directions.Find(x => x.DirectionId == item.DirectionId);
            int index = _Directions.IndexOf(direction);
            _Directions[index] = item;
        }
    }
}
