using HIMS.EF.DAL.Data.Repositories;
using HIMS.Tests.Stub;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests
{
    [TestClass]
    public class TestVUserProfileRepository
    {
        private StubvUserProfileRepository stubvUserProfileRepository;

        public TestVUserProfileRepository()
        {
            stubvUserProfileRepository = new StubvUserProfileRepository();
        }

        [TestMethod]
        public void Get_VUserProfileFromRepository_IsNotNull()
        {
            //Arrange


            //Act
            var VUserProfile = stubvUserProfileRepository.Get(2);

            //Assert
            Assert.IsNotNull(VUserProfile);
            Assert.AreEqual(2, VUserProfile.UserId);

        }

        [TestMethod]
        public void Get_AllVUserProfileFromRepository_IsNotNull()
        {
            var VUserProfiles = stubvUserProfileRepository.GetAll();

            Assert.IsNotNull(VUserProfiles);
            Assert.AreEqual(3, VUserProfiles.Count());
        }

        [TestMethod]
        public void Get_FindVUserProfileFromRepository_IsNotNull()
        {
            var VUserProfile = stubvUserProfileRepository.Find(x => x.FullName == "Petr Petrov").ToList();

            Assert.IsNotNull(VUserProfile);
            Assert.AreEqual(2, VUserProfile[0].UserId);
        }
    }
}
