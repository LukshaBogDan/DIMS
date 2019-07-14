using HIMS.BL.DTO;
using HIMS.EF.DAL.Data;
using HIMS.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests.Stub
{
    class StubDirectionService : IDirectionService
    {
        private readonly StubDirectionRepository _directionRepository;

        public StubDirectionService(StubDirectionRepository sdr)
        {
            _directionRepository = sdr;
        }

        public DirectionDTO GetDirection(int id)
        {
            var direction = _directionRepository.Get(id);
            return Mapper.Map<Direction, DirectionDTO>(direction);
        }

        public IEnumerable<DirectionDTO> GetDirections()
        {
            var directions = _directionRepository.GetAll();
            return Mapper.Map<IEnumerable<Direction>, List<DirectionDTO>>(directions);
        }

        public DirectionDTO FindDirectionByName(string name)
        {
            var directions = _directionRepository.Find(x => x.Name == name);
            return Mapper.Map<IEnumerable<Direction>, List<DirectionDTO>>(directions).FirstOrDefault();
        }
    }
}
