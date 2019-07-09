using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Interfaces;
using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BL.Services
{
    public class DirectionService : IDirectionService
    {
        private readonly IUnitOfWork Database;

        public DirectionService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public DirectionDTO GetDirection(int id)
        {
            var direction = Database.Directions.Get(id);
            return Mapper.Map<Direction, DirectionDTO>(direction);
        }

        public IEnumerable<DirectionDTO> GetDirections()
        {
            var directions = Database.Directions.GetAll();
            return Mapper.Map<IEnumerable<Direction>, List<DirectionDTO>>(directions);
        }

        public DirectionDTO FindDirectionByName(string name)
        {
            var directions = Database.Directions.Find(x => x.Name == name);
            return Mapper.Map<IEnumerable<Direction>, List<DirectionDTO>>(directions).FirstOrDefault();
        }
    }
}
