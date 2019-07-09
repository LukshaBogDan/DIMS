using System;
using System.Collections.Generic;
using HIMS.EF.DAL.Data;
using HIMS.Tests.Stub;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Tests
{
    public class TestDirectionRepository
    {
        private StubDirectionRepository stubDirectionRepository;

        public TestDirectionRepository()
        {
            stubDirectionRepository = new StubDirectionRepository();
        }

        [Test]
        public void Create_UserProfile()
        {
            var expectedDirection = new Direction() { DirectionId = 4, Name = "SaleForth" };
            stubDirectionRepository.Create(expectedDirection);

            Assert.AreEqual(4, stubDirectionRepository.GetAll().Count());
            Assert.AreEqual(expectedDirection, stubDirectionRepository.Get(4));
        }

        [Test]
        public void Delete_UserProfile()
        {

            stubDirectionRepository.Delete(2);

            Assert.AreEqual(2, stubDirectionRepository.GetAll().Count());
            Assert.AreEqual(null, stubDirectionRepository.Get(2));
        }

        [Test]
        public void Get_UserProfileFromRepository_IsNotNull()
        {
            //Arrange


            //Act
            var Direction = stubDirectionRepository.Get(2);

            //Assert
           // Assert.IsNotNull(Direction);
            Assert.That(Direction.Name == "Java");

        }

        [Test]
        public void Get_AllUserProfileFromRepository_IsNotNull()
        {
            var Direction = stubDirectionRepository.GetAll();

            Assert.IsNotNull(Direction);
            Assert.AreEqual(3, Direction.Count());
        }

        [Test]
        public void Get_FindVUserProfileFromRepository_IsNotNull()
        {
            var Direction = stubDirectionRepository.Find(x => x.Name == "Java").ToList();

            Assert.IsNotNull(Direction);
            Assert.AreEqual(2, Direction[0].DirectionId);
        }
    }
}
