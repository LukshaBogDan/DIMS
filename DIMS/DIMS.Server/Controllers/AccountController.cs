using AutoMapper;
using Email.Interfaces;
using HIMS.BL.DTO;
using HIMS.BL.Infrastructure;
using HIMS.BL.Interfaces;
using HIMS.BL.Models;
using HIMS.Server.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HIMS.Server.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IUserProfileService _userProfileService;

        public AccountController(IUserService userService, IEmailService emailService, IUserProfileService userProfileService)
        {
            _userService = userService;
            _emailService = emailService;
            _userProfileService = userProfileService;
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            await SetInitialDataAsync().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                var userDto = new UserDTO { Email = viewModel.Email, Password = viewModel.Password };
                ClaimsIdentity claim = await _userService.Authenticate(userDto).ConfigureAwait(false);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Invalid login or password.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Sample");
        }

        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Register(UserProfileViewModel viewModel)
        {
            await SetInitialDataAsync().ConfigureAwait(false);
            if (ModelState.IsValid)
            {
                UserProfileDTO userProfileDTO = Mapper.Map<UserProfileViewModel, UserProfileDTO>(viewModel);
                _userProfileService.CreateUserProfile(userProfileDTO);
                var userDto = new UserDTO
                {
                    Email = viewModel.Email,
                    Password = "password",
                    Address = viewModel.Address,
                    Name = viewModel.Name,
                    Role = viewModel.Role
                };
                OperationDetails operationDetails = await _userService.Create(userDto).ConfigureAwait(false);
                if (operationDetails.Succedeed)
                {
                    await SendEmailConfirmationTokenAsync(userDto);
                    return RedirectToAction("Index", "UserProfile");
                }
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return RedirectToAction("Create", "UserProfile");
        }

        private async Task<string> SendEmailConfirmationTokenAsync(UserDTO user)
        {
            var token = await _userService.GenerateToken(user).ConfigureAwait(false);

            var callbackUrl = Url.Action(
                            "ConfirmEmail",
                            "Account",
                            new { Username = user.Email, Token = token },
                            protocol: Request.Url.Scheme);

            await _emailService.MessageToUserAsync(user, "Account confirmation",
                    $"<span>Please, confirm your account by following this </span>" +
                    $"<a href='{callbackUrl}'>link</a>");


            return callbackUrl;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string username, string token)
        {
            var user = await _userService.FindByName(username);

            if (user == null || token == null)
            {
                return View("Error");
            }
            var isConfirmed = await _userService.ConfirmEmail(user, token);
            return View(isConfirmed ? "ConfirmEmail" : "Error");
        }

        private async Task SetInitialDataAsync()
        {
            await _userService.SetInitialData(new UserDTO
            {
                Email = "alex.meleschenko@gmail.com",
                UserName = "Alex",
                Password = "superadmin",
                Name = "Alex",
                Address = "Revoljucionnaja 11-301",
                Role = "admin",
            }, new List<string> { "user", "admin" }).ConfigureAwait(false);
        }
    }
}