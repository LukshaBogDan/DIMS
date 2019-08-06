using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Models;
using HIMS.EF.DAL.Data;
using HIMS.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIMS.Server.utils
{
    public static class AutomapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Sample, SampleDTO>();
                cfg.CreateMap<SampleDTO, Sample>();
                cfg.CreateMap<SampleViewModel, SampleDTO>();
                cfg.CreateMap<UserProfile, UserProfileDTO>();
                cfg.CreateMap<UserProfileDTO, UserProfile>();
                cfg.CreateMap<UserProfileViewModel, UserProfileDTO>();
                cfg.CreateMap<UserProfileDTO, UserProfileViewModel>();
                cfg.CreateMap<vUserProfile, vUserProfileDTO>();
                cfg.CreateMap<vUserProfileDTO, vUserProfile>();
                cfg.CreateMap<vUserProfileViewModel, vUserProfileDTO>();
                cfg.CreateMap<Direction, DirectionDTO>();
                cfg.CreateMap<UserProfileDTO, UserDTO>();
                cfg.CreateMap<Progress, ProgressDTO>();
                cfg.CreateMap<ProgressDTO, Progress>();
                cfg.CreateMap<ProgressViewModel, ProgressDTO>();
            });
        }
    }
}