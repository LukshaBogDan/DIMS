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
    public class TestDirectionRepository
    {
        private StubDirectionRepository stubDirectionRepository;

        public TestDirectionRepository()
        {
            stubDirectionRepository = new StubDirectionRepository();
        }

        [Test]
        public void Create_Direction()
        {
            var expectedDirection = new Direction() { DirectionId = 4, Name = "SaleForth" };
            stubDirectionRepository.Create(expectedDirection);

           
            Assert.That(expectedDirection == stubDirectionRepository.Get(4));
        }

        [Test]
        public void Delete_Direction()
        {

            stubDirectionRepository.Delete(2);

            
            Assert.That(null == stubDirectionRepository.Get(2));
        }

        [Test]
        public void Get_Direction()
        {
            //Arrange


            //Act
            var Direction = stubDirectionRepository.Get(1);

            //Assert
           // Assert.IsNotNull(Direction);
            Assert.That(Direction.Name == ".Net");

        }

        [Test]
        public void Get_AllDirectionFromRepository_IsNotNull()
        {
            var Direction = stubDirectionRepository.GetAll();

            Assert.That(Direction != null);
            Assert.That(3 == Direction.Count());
        }

        [Test]
        public void Get_FindDirectionFromRepository_IsNotNull()
        {
            var Direction = stubDirectionRepository.Find(x => x.Name == ".Net").ToList();

            Assert.IsNotNull(Direction);
            Assert.That(1 == Direction[0].DirectionId);
        }
    }
}
