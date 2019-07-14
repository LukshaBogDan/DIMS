using System;
using System.Collections.Generic;
using HIMS.EF.DAL.Data;
using HIMS.Tests.Stub;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests
{
    [TestFixture]
    public class TestUserProfileRepository
    {
        private StubUserProfileRepository stubUserProfileRepository;

        public TestUserProfileRepository()
        {
            stubUserProfileRepository = new StubUserProfileRepository();
        }

        [Test]
        public void Create_UserProfile()
        {
            var expectedUserProfile = new UserProfile() { UserId = 4, Name = "Bogdan" };
            stubUserProfileRepository.Create(expectedUserProfile);

            Assert.AreEqual(4, stubUserProfileRepository.GetAll().Count());
            Assert.AreEqual(expectedUserProfile, stubUserProfileRepository.Get(4));
        }

        [Test]
        public void Delete_UserProfile()
        {
          
            stubUserProfileRepository.Delete(2);

           
            Assert.AreEqual(null, stubUserProfileRepository.Get(2));
        }

        [Test]
        public void Get_UserProfileFromRepository_IsNotNull()
        {
            //Arrange


            //Act
            var UserProfile = stubUserProfileRepository.Get(1);

            //Assert
            Assert.IsNotNull(UserProfile);
            Assert.AreEqual(1, UserProfile.UserId);

        }

        [Test]
        public void Get_AllUserProfileFromRepository_IsNotNull()
        {
            var UserProfiles = stubUserProfileRepository.GetAll();

            Assert.IsNotNull(UserProfiles);
            Assert.AreEqual(3, UserProfiles.Count());
        }

        [Test]
        public void Get_FindVUserProfileFromRepository_IsNotNull()
        {
            var UserProfile = stubUserProfileRepository.Find(x => x.Name == "Ivan").ToList();

            Assert.IsNotNull(UserProfile);
            Assert.AreEqual(1, UserProfile[0].UserId);
        }



    }
}
