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
    class StubUserProfileService : IUserProfileService
    {
        private readonly StubUserProfileRepository _stubUserProfileRepository;

        public StubUserProfileService(StubUserProfileRepository sur)
        {
            _stubUserProfileRepository = sur;
        }

        public void DeleteUserProfile(int userProfileId)
        {
            _stubUserProfileRepository.Delete(userProfileId);
        }

        public UserProfileDTO GetUserProfile(int id)
        {
            var userProfile = _stubUserProfileRepository.Get(id);
            return Mapper.Map<UserProfile, UserProfileDTO>(userProfile);
        }

        public void UpdateUserProfile(UserProfileDTO userProfileDTO)
        {
            var userProfile = _stubUserProfileRepository.Get(userProfileDTO.UserId);

            if (userProfile != null)
            {
                Mapper.Map(userProfileDTO, userProfile);
            }
        }

        public void CreateUserProfile(UserProfileDTO userProfileDTO)
        {
            _stubUserProfileRepository.Create(Mapper.Map<UserProfileDTO, UserProfile>(userProfileDTO));
        }
    }
}
