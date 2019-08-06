using AutoMapper;
using HIMS.BL.DTO;
using HIMS.BL.Interfaces;
using HIMS.Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System;

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
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in directionDTOs)
            {
                selectListItems.Add(new SelectListItem { Text = item.Name, Value = item.DirectionId.ToString() });
            }
            ViewBag.Direction = direction.Name;
            ViewBag.Directions = selectListItems;
            ViewData["Directions"] = selectListItems;
            return View(userProfile);
        }

        [HttpPost]
        public ActionResult Edit(UserProfileViewModel userProfile)
        {
            if (ModelState.IsValid)
            {
                UserProfileDTO userProfileDTO = Mapper.Map<UserProfileViewModel, UserProfileDTO>(userProfile);
                _userProfileService.UpdateUserProfile(userProfileDTO);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserProfileViewModel userProfile)
        {
            if (ModelState.IsValid)
            {
                UserProfileDTO userProfileDTO = Mapper.Map<UserProfileViewModel, UserProfileDTO>(userProfile);
                _userProfileService.CreateUserProfile(userProfileDTO);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int UserProfileId)
        {
            var userProfileDTO = _userProfileService.GetUserProfile(UserProfileId);
            UserProfileViewModel userProfile = Mapper.Map<UserProfileDTO, UserProfileViewModel>(userProfileDTO);
            return View(userProfile);
        }

        [HttpPost]
        public ActionResult Delete(UserProfileViewModel userProfile)
        {
            _userProfileService.DeleteUserProfile(userProfile.UserId);
            return RedirectToAction("Index");
        }
    }
}