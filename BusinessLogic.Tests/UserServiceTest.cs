using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services;
using Domain.Interfaces;
using Moq;
using Domain.Models;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User).Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new Customer() { FirstName = "", LastName = "", BirthDate = DateOnly.MaxValue, Username = "", Email = "", Pass = "" } },
                new object[] { new Customer() { FirstName = "Test", LastName = "", BirthDate = DateOnly.MaxValue, Username = "", Email = "", Pass = "" } },
                new object[] { new Customer() { FirstName = "Test", LastName = "Test", BirthDate = DateOnly.MaxValue, Username = "", Email = "", Pass = "" } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            // Act
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

            // Assert
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Never);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsync_NewUser_ShouldNotCreateNewUser(Customer user)
        {
            // Arrange
            var newUser = user;

            // Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(newUser));

            // Assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsync_NewUser_ShouldCreateNewUser()
        {
            var newUser = new Customer
            {
                FirstName = "Test",
                LastName = "Test",
                BirthDate = DateOnly.MaxValue,
                Username = "Test",
                Email = "test@test.com",
                Pass = ""
            };

            // Act
            await service.Create(newUser);

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Once);
        }
    }
}
