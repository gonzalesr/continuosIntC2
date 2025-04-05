using Moq;
using PatientManagement.Infrastructure.Repositories;
using PatientManagement.Domain.Users;
using PatientManagement.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;


namespace PatientMangement.Test.Infrastructure.Repositories
{
    public class UserRepositoryTests
    {
        private readonly Mock<DbSet<User>> _mockUserDbSet;
        private readonly Mock<DomainDbContext> _mockDbContext;
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        {
            _mockUserDbSet = new Mock<DbSet<User>>();
            _mockDbContext = new Mock<DomainDbContext>();
            _mockDbContext.Setup(db => db.Set<User>()).Returns(_mockUserDbSet.Object); // Se configura Set<User> en lugar de db.User
            _userRepository = new UserRepository(_mockDbContext.Object);
        }


      
        [Fact]
        public async Task AddAsync_ShouldAddUser()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), "Test User");


            // Act
            await _userRepository.AddAsync(user);

            // Assert
            _mockUserDbSet.Verify(dbSet => dbSet.AddAsync(user, default), Times.Once); // Verifica si AddAsync fue invocado
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnUser_WhenReadOnlyIsFalse()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User(userId, "Test User");

            _mockDbContext.Setup(db => db.User.FindAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await _userRepository.GetByIdAsync(userId, false);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(userId);
            result.FullName.Should().Be("Test User");
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenUserNotFound()
        {
            // Arrange
            var userId = Guid.NewGuid();

            _mockDbContext.Setup(db => db.User.FindAsync(userId)).ReturnsAsync((User)null);

            // Act
            var result = await _userRepository.GetByIdAsync(userId, false);

            // Assert
            result.Should().BeNull();
        }

        private Mock<DbSet<User>> MockDbSet(User user)
        {
            var data = new List<User> { user }.AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
    }
}
