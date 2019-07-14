using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Interfaces;
using HIMS.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIMS.Server.Controllers
{
    public class UserProfileController : Controller
    {

        private readonly IVUserProfileService _vUserProfileService;
        private readonly IUserProfileService _userProfileService;
        private readonly IDirectionService _directionService;


        public UserProfileController(IVUserProfileService vUserProfileService, IUserProfileService userProfileService, IDirectionService directionService)
        {
            _vUserProfileService = vUserProfileService;
            _userProfileService = userProfileService;
            _directionService = directionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<vUserProfileDTO> vUserProfileDTOs = _vUserProfileService.GetVUserProfiles().ToList();
            var userProfiles = Mapper.Map<IEnumerable<vUserProfileDTO>, List<vUserProfileViewModel>>(vUserProfileDTOs);         
            return View(userProfiles);
        }

        [HttpGet]
        public ActionResult Details(int UserProfileId)
        {
            var userProfileDTO = _userProfileService.GetUserProfile(UserProfileId);
            UserProfileViewModel userProfile = Mapper.Map<UserProfileDTO, UserProfileViewModel>(userProfileDTO);
            DirectionDTO direction = _directionService.GetDirection(userProfile.DirectionId);
            ViewBag.Direction = direction.Name;
            return View(userProfile);
        }

        [HttpGet]
        public ActionResult Edit(int UserProfileId)
        {
            var userProfileDTO = _userProfileService.GetUserProfile(UserProfileId);
            UserProfileViewModel userProfile = Mapper.Map<UserProfileDTO, UserProfileViewModel>(userProfileDTO);
            DirectionDTO direction = _directionService.GetDirection(userProfile.DirectionId);
            List<DirectionDTO> directionDTOs = _directionService.GetDirections().ToList();
            SelectList selectListItems = new SelectList(directionDTOs, "Name", "Name");
            ViewBag.Direction = direction.Name;
            ViewBag.Directions = selectListItems;
            ViewData["Directions"] = selectListItems;
            return View(userProfile);
        }

        [HttpPost]
        public ActionResult Edit(UserProfileViewModel userProfile)
        {
            UserProfileDTO userProfileDTO = Mapper.Map<UserProfileViewModel, UserProfileDTO>(userProfile);
            _userProfileService.UpdateUserProfile(userProfileDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserProfileViewModel userProfile)
        {
            UserProfileDTO userProfileDTO = Mapper.Map<UserProfileViewModel, UserProfileDTO>(userProfile);
            _userProfileService.CreateUserProfile(userProfileDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int UserProfileId)
        {
            _userProfileService.DeleteUserProfile(UserProfileId);
            return RedirectToAction("Index");
        }
    }
}