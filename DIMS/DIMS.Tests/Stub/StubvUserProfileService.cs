using HIMS.BL.DTO;
using HIMS.BL.Interfaces;
using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests.Stub
{
    class StubvUserProfileService : IVUserProfileService
    {
        private readonly StubvUserProfileRepository _stubvUserProfileRepository;

        public StubvUserProfileService(StubvUserProfileRepository svur)
        {
            _stubvUserProfileRepository = svur;
        }

        public IEnumerable<vUserProfileDTO> GetVUserProfiles()
        {
            var vUserProfiles = _stubvUserProfileRepository.GetAll();
            return Mapper.Map<IEnumerable<vUserProfile>, List<vUserProfileDTO>>(vUserProfiles);
        }


        public vUserProfileDTO GetVUserProfile(int id)
        {
            var vUserProfile = _stubvUserProfileRepository.Get(id);
            return Mapper.Map<vUserProfile, vUserProfileDTO>(vUserProfile);
        }
    }
}
