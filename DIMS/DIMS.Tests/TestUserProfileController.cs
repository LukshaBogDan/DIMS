using System;
using System.Collections.Generic;
using HIMS.EF.DAL.Data;
using HIMS.Tests.Stub;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIMS.Server.Controllers;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HIMS.BL.Models;
using HIMS.Server.Models;
using HIMS.BL.DTO;
using HIMS.Server.utils;

namespace HIMS.Tests
{
    [TestFixture]
    class TestUserProfileController
    {
        UserProfileController userProfileController;

        [OneTimeSetUp]
        public void BeforeTestSuit()
        {
            AutomapperConfig.Initialize();
            StubUserProfileService stubUserProfileService = new StubUserProfileService(new StubUserProfileRepository());
            StubvUserProfileService stubvUserProfileService = new StubvUserProfileService(new StubvUserProfileRepository());
            StubDirectionService stubDirectionService = new StubDirectionService(new StubDirectionRepository());
            userProfileController = new UserProfileController(stubvUserProfileService, stubUserProfileService, stubDirectionService);
        }

        [Test]
        public void Get_IndexPage_Test()
        {    
            ViewResult page = (ViewResult)userProfileController.Index();
            List<vUserProfileViewModel> vUserProfileViewModels = (List<vUserProfileViewModel>)page.Model;
            Assert.IsNotNull(page);
            Assert.IsNotNull(page.Model);
            Assert.That(vUserProfileViewModels[0].FullName == "Ivan Ivanov");
        }

        [Test]
        public void Get_DetailsPage_Test()
        {
            ViewResult page = (ViewResult)userProfileController.Details(1);
            UserProfileViewModel userProfileViewModel = (UserProfileViewModel)page.Model;
            string directionName = page.ViewBag.Direction;
            Assert.IsNotNull(page);
            Assert.IsNotNull(page.Model);
            Assert.That(userProfileViewModel.Name == "Ivan");
            Assert.That(directionName == ".Net");
        }

        [Test]
        public void Get_EditPage_Test()
        {
            ViewResult page = (ViewResult)userProfileController.Edit(1);
            UserProfileViewModel userProfileViewModel = (UserProfileViewModel)page.Model;
            string directionName = page.ViewBag.Direction;
            Assert.IsNotNull(page);
            Assert.IsNotNull(page.Model);
            Assert.That(userProfileViewModel.Name == "Ivan");
            Assert.That(directionName == ".Net");
        }

        [Test]
        public void Post_EditPage_Test()
        {
            RedirectToRouteResult page = (RedirectToRouteResult)userProfileController.Edit(new UserProfileViewModel() { UserId = 3, Name = "Bogdan", DirectionId = 1 });
            Assert.IsNotNull(page);
            Assert.IsNotNull(page.RouteValues);
            Assert.That(page.RouteValues["action"].ToString() == "Index");
        }

        [Test]
        public void Get_CreatePage_Test()
        {
            ViewResult page = (ViewResult)userProfileController.Create();
            Assert.IsNotNull(page);
            Assert.IsNull(page.Model);
        }

        [Test]
        public void Post_CreatePage_Test()
        {
            RedirectToRouteResult page = (RedirectToRouteResult)userProfileController.Create(new UserProfileViewModel() { UserId = 4, Name = "Bogdan", DirectionId = 1 });
            Assert.IsNotNull(page);
            Assert.IsNotNull(page.RouteValues);
            Assert.That(page.RouteValues["action"].ToString() == "Index");
        }

        [Test]
        public void Get_DeletePage_Test()
        {
            RedirectToRouteResult page = (RedirectToRouteResult)userProfileController.Delete(2);
            Assert.IsNotNull(page);
            Assert.IsNotNull(page.RouteValues);
            Assert.That(page.RouteValues["action"].ToString() == "Index");
        }
    }
}
