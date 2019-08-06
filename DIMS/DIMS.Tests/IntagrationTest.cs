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
using HIMS.BL.Services;
using HIMS.EF.DAL.Data.Repositories;

namespace HIMS.Tests
{
    [TestFixture]
    class IntagrationTest
    {

        UserProfileController userProfileController;

        [OneTimeSetUp]
        public void BeforeTestSuit()
        {
            AutomapperConfig.Initialize();
            IUnitOfWork uof = new EFUnitOfWork("metadata=res://*/HIMS.csdl|res://*/HIMS.ssdl|res://*/HIMS.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-GD7KKE4;initial catalog=DIMS;integrated security=False;User ID=sa;Password=12345;MultipleActiveResultSets=True;App=EntityFramework&quot;");
            UserProfileService UserProfileService = new UserProfileService(uof, new UserService(new EF.DAL.Identity.Repositories.IdentityUnitOfWork("Data Source=DESKTOP-GD7KKE4;Initial Catalog=HIMSIdentity;Integrated Security=False;User ID=sa;Password=12345;MultipleActiveResultSets=True")));
            VUserProfileService vUserProfileService = new VUserProfileService(uof);
            DirectionService DirectionService = new DirectionService(uof);
            userProfileController = new UserProfileController(vUserProfileService, UserProfileService, DirectionService);
        }

        [Test]
        public void Post_EditPage_Test()
        {
            RedirectToRouteResult page = (RedirectToRouteResult)userProfileController.Edit(new UserProfileViewModel() { UserId = 17, Address = "118-15", BirthDate= System.DateTime.Now,
            DirectionId = 2, Education = "BGTU", Email= "bogdanluksha@gmail.com", LastName = "Luksha", MathScore = 9.6, MobilePhone= "+37525333667", Name="Bogdan", Role = "user", Sex="M",
            Skype= "kirilxxx", StartDate = System.DateTime.Now, UniversityAverageScore=8.9
            });
            Assert.IsNotNull(page);
            Assert.IsNotNull(page.RouteValues);
            Assert.That(page.RouteValues["action"].ToString() == "Index");
        }
    }
}
