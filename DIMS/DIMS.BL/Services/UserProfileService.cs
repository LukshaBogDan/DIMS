using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Infrastructure;
using HIMS.BL.Interfaces;
using HIMS.BL.Models;
using HIMS.EF.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using SendGrid;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace HIMS.BL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork Database;
        private IUserService userService;


        public UserProfileService(IUnitOfWork uow, IUserService us)
        {
            Database = uow;
            userService = us;
        }

        public void DeleteUserProfile(int userProfileId)
        {
            UserProfileDTO userProfileDTO = GetUserProfile(userProfileId);
            userService.Delete(userProfileDTO.Email);
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
            UserDTO userDTO = Mapper.Map<UserProfileDTO, UserDTO>(userProfileDTO);
            //userDTO.Role = "User";
            //userDTO.Password = "password";
            //OperationDetails identityResult = userService.Create(userDTO).Result;
            
            Database.UserProfiles.Create(Mapper.Map<UserProfileDTO, UserProfile>(userProfileDTO));
            Database.Save();
        }
    }
}
