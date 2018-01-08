using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using UnitTestTutorial.Model;
using UnitTestTutorial.ReadRepository.Interfaces;
using UnitTestTutorial.Services;
using UnitTestTutorial.Services.Interfaces;
using UnitTestTutorial.WriteRepository.Interfaces;

namespace UnitTestTutorial.Test.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserService _sut;

        private Mock<IWriteRepository<User>> _userWriteRepositoryMock;

        private Mock<IReadRepository<User>> _userReadRepositoryMock;

        [SetUp]

        public void SetUp()
        {
            _userReadRepositoryMock = new Mock<IReadRepository<User>>();
            _userWriteRepositoryMock = new Mock<IWriteRepository<User>>();

            _sut = new UserService(_userWriteRepositoryMock.Object,_userReadRepositoryMock.Object);
        }

        [Test]
        public void AddUser_Should_Call_Add_From_Repository()
        {
            User user = new User();

            _sut.AddUser(user);

            _userWriteRepositoryMock.Verify(x=>x.Add(It.IsAny<User>()));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GetUsersByType_Should_GetUsers_With_Only_That_Type(int userType)
        {
            IList<User> users = new List<User>(){
                new User(){UserType = 1},
                new User(){UserType = 2},
                new User(){UserType = 0}
            };

            _userReadRepositoryMock.Setup(x=>x.GetAll()).Returns(users);

            var result = _sut.GetUsersByType(userType);

            Assert.IsNotEmpty(result);
            Assert.AreEqual(userType,result[0].UserType);
        }
    }
}