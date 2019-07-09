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
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork Database;

        public UserProfileService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void DeleteUserProfile(int userProfileId)
        {
            Database.UserProfiles.Delete(userProfileId);
            Database.Save();
        }

        public UserProfileDTO GetUserProfile(int id)
        {
            var userProfile = Database.UserProfiles.Get(id);
            return Mapper.Map<UserProfile, UserProfileDTO>(userProfile);
        }

        public void UpdateUserProfile(UserProfileDTO userProfileDTO)
        {
            var userProfile = Database.UserProfiles.Get(userProfileDTO.UserId);

            if (userProfile != null)
            {
                Mapper.Map(userProfileDTO, userProfile);
                Database.Save();
            }
        }

        public void CreateUserProfile(UserProfileDTO userProfileDTO)
        {
            Database.UserProfiles.Create(Mapper.Map<UserProfileDTO, UserProfile>(userProfileDTO));
            Database.Save();
        }
    }
}
