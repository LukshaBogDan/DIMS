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
    public class TestVUserProfileRepository
    {
        private StubvUserProfileRepository stubvUserProfileRepository;

        public TestVUserProfileRepository()
        {
            stubvUserProfileRepository = new StubvUserProfileRepository();
        }

        [Test]
        public void Get_VUserProfileFromRepository_IsNotNull()
        {
            //Arrange


            //Act
            var VUserProfile = stubvUserProfileRepository.Get(2);

            //Assert
            Assert.IsNotNull(VUserProfile);
            Assert.AreEqual(2, VUserProfile.UserId);

        }

        [Test]
        public void Get_AllVUserProfileFromRepository_IsNotNull()
        {
            var VUserProfiles = stubvUserProfileRepository.GetAll();

            Assert.IsNotNull(VUserProfiles);
            Assert.AreEqual(3, VUserProfiles.Count());
        }

        [Test]
        public void Get_FindVUserProfileFromRepository_IsNotNull()
        {
            var VUserProfile = stubvUserProfileRepository.Find(x => x.FullName == "Petr Petrov").ToList();

            Assert.IsNotNull(VUserProfile);
            Assert.AreEqual(2, VUserProfile[0].UserId);
        }
    }
}
