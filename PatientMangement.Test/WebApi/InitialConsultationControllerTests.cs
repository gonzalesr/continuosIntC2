using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientManagement.Application.Evaluations.CreateEvaluation;
using PatientManagement.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PatientManagement.Application.Evaluations.GetEvaluations;
using Xunit;
using PatientManagement.Domain.Shared;
using PatientManagement.Domain.Patients;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PatientManagement.Application.InitialConsultation.CreateInitialConsultation;
using PatientManagement.Application.InitialConsultation.GetInitialConsultations;

namespace PatientMangement.Test.WebApi
{
    public class InitialConsultationControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly InitialConsultationController _controller;

        public InitialConsultationControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new InitialConsultationController(_mediatorMock.Object);
        }

        // Prueba para el método POST: CreateInitialConsultation
        [Fact]
        public async Task CreateInitialConsultation_ReturnsOk_WhenCommandIsValid()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid idPatient = Guid.Parse("24f360f3-346a-4ae4-a54d-39cae1e89ef4");
            DateTime date = new DateTime(2025, 1, 1);
            string reason = "Razon";
            string observation = "OBSERVATION";
            var command = new CreateInitialConsultationCommand(id, idPatient, date, reason, observation);
            var expectedId = id;
            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreateInitialConsultation(command);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().Be(expectedId);
        }

        [Fact]
        public async Task CreateInitialConsultation_Returns500_WhenExceptionOccurs()
        {
            // Arrange
            // Arrange
            Guid id = Guid.NewGuid();
            Guid idPatient = Guid.Parse("24f360f3-346a-4ae4-a54d-39cae1e89ef4");
            DateTime date = new DateTime(2025, 1, 1);
            string reason = "Razon";
            string observation = "OBSERVATION";
            var command = new CreateInitialConsultationCommand(id, idPatient, date, reason, observation);
            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.CreateInitialConsultation(command);

            // Assert
            result.Should().BeOfType<ObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            objectResult.Value.Should().Be("Database error");
        }

        // Prueba para el método GET: GetPeriodicEvaluation
        [Fact]
        public async Task GetInitialConsultation_ReturnsOk_WhenDataExists()
        {
            // Arrange
            var expectedData = new List<InitialConsultationDto>
        {
            new InitialConsultationDto { Id = Guid.NewGuid(), PatientId = Guid.Parse("24f360f3-346a-4ae4-a54d-39cae1e89ef4")},
            new InitialConsultationDto { Id = Guid.NewGuid(), PatientId = Guid.Parse("269d8e2c-1e91-454f-9423-c60db9023a55")}
        };
            
        _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetInitialConsultationQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedData);

            // Act
            var result = await _controller.GetInitialConsultations();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(expectedData);
        }

        [Fact]
        public async Task GetInitialConsultation_Returns500_WhenExceptionOccurs()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetInitialConsultationQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.GetInitialConsultations();

            // Assert
            result.Should().BeOfType<ObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            objectResult.Value.Should().Be("Database error");
        }
    }
}
