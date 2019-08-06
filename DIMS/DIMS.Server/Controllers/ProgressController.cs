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
    public class ProgressController : Controller
    {
        private readonly IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }

        [HttpGet]
        public ActionResult Index(int userId)
        {
            IEnumerable<ProgressDTO> progressDTOs = _progressService.GetUserProgress(userId).ToList();
            var progressViewModels = Mapper.Map<IEnumerable<ProgressDTO>, List<ProgressViewModel>>(progressDTOs);
            return View(progressViewModels);
        }

        [HttpGet]
        public ActionResult Details(int ProgressId)
        {
            var progressDTO = _progressService.GetProgress(ProgressId);
            ProgressViewModel progressViewModel = Mapper.Map<ProgressDTO, ProgressViewModel>(progressDTO);
            return View(progressViewModel);
        }
    }
}