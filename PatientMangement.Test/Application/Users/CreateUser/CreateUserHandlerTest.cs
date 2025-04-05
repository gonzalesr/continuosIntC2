using FluentAssertions;
using Moq;
using PatientManagement.Application.Users.CreateUser;
using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMangement.Test.Application.Users.CreateUser
{
    public class CreateUserHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateUserHandler _handler;

        public CreateUserHandlerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _handler = new CreateUserHandler(
                _mockUserRepository.Object,
                _mockUnitOfWork.Object
            );
        }

        [Fact]
        public async Task Handle_ShouldCreateAndSaveUser()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var command = new CreateUserCommand(Guid.NewGuid(),"John Doe");
            
            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().Be(command.UserId);

            _mockUserRepository.Verify(r => r.AddAsync(It.Is<User>(u => u.Id == command.UserId && u.FullName == command.FullName)), Times.Once);
            _mockUnitOfWork.Verify(u => u.CommitAsync(cancellationToken), Times.Once);
        }
    }
}
