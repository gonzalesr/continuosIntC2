using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientManagement.Application.Users.CreateUser;
using PatientManagement.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace PatientMangement.Test.WebApi
{
    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new UserController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateUser_ReturnsOk_WhenCommandIsValid()
        {
            // Arrange
            var command = new CreateUserCommand ( Guid.NewGuid(),  "john@example.com" );
            var expectedUserId = Guid.NewGuid();
            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedUserId);

            // Act
            var result = await _controller.CreateUser(command);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().Be(expectedUserId);
        }

        [Fact]
        public async Task CreateUser_Returns500_WhenExceptionOccurs()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var command = new CreateUserCommand (  Guid.NewGuid(),  "Jane Doe" );
            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.CreateUser(command);

            // Assert
            result.Should().BeOfType<ObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            objectResult.Value.Should().Be("Database error");
        }
    }
}
