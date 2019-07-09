using HIMS.EF.DAL.Data;
using HIMS.Tests.Stub;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests
{
    [TestClass]
    public class TestUserProfileRepository
    {
        private StubUserProfileRepository stubUserProfileRepository;

        public TestUserProfileRepository()
        {
            stubUserProfileRepository = new StubUserProfileRepository();
        }

        [TestMethod]
        public void Create_UserProfile()
        {
            var expectedUserProfile = new UserProfile() { UserId = 4, Name = "Bogdan" };
            stubUserProfileRepository.Create(expectedUserProfile);

            Assert.AreEqual(4, stubUserProfileRepository.GetAll().Count());
            Assert.AreEqual(expectedUserProfile, stubUserProfileRepository.Get(4));
        }

        [TestMethod]
        public void Delete_UserProfile()
        {
          
            stubUserProfileRepository.Delete(2);

            Assert.AreEqual(2, stubUserProfileRepository.GetAll().Count());
            Assert.AreEqual(null, stubUserProfileRepository.Get(2));
        }

        [TestMethod]
        public void Get_UserProfileFromRepository_IsNotNull()
        {
            //Arrange


            //Act
            var UserProfile = stubUserProfileRepository.Get(2);

            //Assert
            Assert.IsNotNull(UserProfile);
            Assert.AreEqual(2, UserProfile.UserId);

        }

        [TestMethod]
        public void Get_AllUserProfileFromRepository_IsNotNull()
        {
            var UserProfiles = stubUserProfileRepository.GetAll();

            Assert.IsNotNull(UserProfiles);
            Assert.AreEqual(3, UserProfiles.Count());
        }

        [TestMethod]
        public void Get_FindVUserProfileFromRepository_IsNotNull()
        {
            var UserProfile = stubUserProfileRepository.Find(x => x.Name == "Petr").ToList();

            Assert.IsNotNull(UserProfile);
            Assert.AreEqual(2, UserProfile[0].UserId);
        }



    }
}
