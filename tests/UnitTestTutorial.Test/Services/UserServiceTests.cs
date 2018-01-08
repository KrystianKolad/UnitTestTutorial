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
    }
}