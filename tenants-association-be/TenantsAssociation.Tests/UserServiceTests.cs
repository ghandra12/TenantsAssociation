using Microsoft.Extensions.Configuration;
using Moq;
using Moq.AutoMock;
using NUnit.Framework.Internal;
using TenantsAssociation.BusinessLogic.DTOs;
using TenantsAssociation.BusinessLogic.enums;
using TenantsAssociation.BusinessLogic.Services;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();

        public UserServiceTests()
        {
            _unitOfWork.Setup(uow => uow.Users).Returns(_userRepository.Object);

            var inMemorySettings = new Dictionary<string, string> {
                {"Secret", "Secretttasdasdas12312312123sadas231321sd"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

            _userService = new UserService(_unitOfWork.Object, configuration);
        }

        [TestMethod]
        public void Login_WithInvalidCredentials_ShouldReturnNotFound()
        {
            //Arrange
            _userRepository.Setup(ur => ur.VerifyUser(It.IsAny<string>(), It.IsAny<string>())).Returns<User?>(null);
            //Act
            var result = _userService.Login(new UserDto { Email = "Test11111", Password = "Test111111" });
            //Assert
            Assert.IsNull(result.UserId);
            Assert.IsNull(result.Token);
            Assert.AreEqual(result.LoginResult, LoginResult.UserNotFound);
        }

        [TestMethod]
        public void Login_WithValidCredentials_ShouldReturnAdministrator()
        {
            //Arrange
            var user = new User()
            {
                IsAdmin = true,
                Email = "Test",
                ApartmentNumber = 1,
                FirstName = "Test",
                Id = 1,
                LastName = "Test",
                Password = "Test",
                PhoneNumber = "0712312312"
            };

            _userRepository.Setup(ur => ur.VerifyUser(It.IsAny<string>(), It.IsAny<string>())).Returns(user);
            //Act
            var result = _userService.Login(new UserDto { Email = "Test11111", Password = "Test111111" });
            //Assert
            Assert.IsNotNull(result.UserId);
            Assert.IsNotNull(result.Token);
            Assert.AreEqual(result.LoginResult, LoginResult.LoggedInAsAdmin);
        }

        [TestMethod]
        public void Login_WithValidCredentials_ShouldReturnTenant()
        {
            //Arrange
            var user = new User()
            {
                IsAdmin = false,
                Email = "Test123231",
                ApartmentNumber = 1,
                FirstName = "Test",
                Id = 1,
                LastName = "Test",
                Password = "Test123213",
                PhoneNumber = "0712312312"
            };

            _userRepository.Setup(ur => ur.VerifyUser(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            //Act
            var result = _userService.Login(new UserDto { Email = "Test11111", Password = "Test11111" });

            //Assert
            Assert.IsNotNull(result.UserId);
            Assert.IsNotNull(result.Token);
            Assert.AreEqual(result.LoginResult, LoginResult.LoggedInAsTenant);
        }

        [TestMethod]
        public async Task AddUser_ShouldAddUser()
        {
            //Arrange
            var userDto = new UserDto()
            {
                Email = "Test12321",
                Password = "Test123213",
                IsAdmin = true,
                ApartmentNumber = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "0123Test"
            };

            _userRepository.Setup(ur => ur.InsertAsync(It.IsAny<User>())).Verifiable();
            //Act
            await _userService.AddUser(userDto);
            //Assert
            _userRepository.Verify(ur => ur.InsertAsync(It.IsAny<User>()), Times.Once);
            _unitOfWork.Verify(uow => uow.SaveChanges(), Times.Once);
        }
    }
}