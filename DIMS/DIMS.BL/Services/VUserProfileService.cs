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
    public class VUserProfileService : IVUserProfileService
    {
        private readonly IUnitOfWork Database;

        public VUserProfileService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<vUserProfileDTO> GetVUserProfiles()
        {
            var vUserProfiles = Database.VUserProfiles.GetAll();
            return Mapper.Map<IEnumerable<vUserProfile>, List<vUserProfileDTO>>(vUserProfiles);
        }


        public vUserProfileDTO GetVUserProfile(int id)
        {
            var vUserProfile = Database.VUserProfiles.Get(id);
            return Mapper.Map<vUserProfile, vUserProfileDTO>(vUserProfile);
        }
    }
}
