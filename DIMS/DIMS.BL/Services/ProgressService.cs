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
    public class ProgressService : IProgressService
    {
        private readonly IUnitOfWork Database;

        public ProgressService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ProgressDTO GetProgress(int ProgressId)
        {
            var progress = Database.Progress.Get(ProgressId);
            return Mapper.Map<Progress, ProgressDTO>(progress);
        }

        public IEnumerable<ProgressDTO> GetUserProgress(int userId)
        {
            IEnumerable<Progress> progress = Database.Progress.Find(x => x.UserId == userId);
            return Mapper.Map<IEnumerable<Progress>, List<ProgressDTO>>(progress);
        }
    }
}
