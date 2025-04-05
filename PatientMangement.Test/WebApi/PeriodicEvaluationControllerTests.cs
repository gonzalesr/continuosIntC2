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

namespace PatientMangement.Test.WebApi
{
    public class PeriodicEvaluationControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly PeriodicEvaluationController _controller;

        public PeriodicEvaluationControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new PeriodicEvaluationController(_mediatorMock.Object);
        }

        // Prueba para el método POST: CreatePeriodicEvaluation
        [Fact]
        public async Task CreatePeriodicEvaluation_ReturnsOk_WhenCommandIsValid()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid idPatient = Guid.Parse("24f360f3-346a-4ae4-a54d-39cae1e89ef4");
            DateTime date = new DateTime(2025, 1, 1);
            string nota = "NOTAS DE LA EVALUACION PERIODICA";
            decimal height = 170;
            decimal weight = 90;
            int systolic = 100;
            int diastolic = 80;
            int heartRate = 100;
            HeartRateValue heartRateValue = new HeartRateValue(50);

            var command = new CreatePeriodicEvaluationCommand(id,idPatient, date,nota,80,170,systolic,diastolic,heartRate);
            var expectedId = id;
            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreatePeriodicEvaluation(command);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().Be(expectedId);
        }

        [Fact]
        public async Task CreatePeriodicEvaluation_Returns500_WhenExceptionOccurs()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid idPatient = Guid.Parse("24f360f3-346a-4ae4-a54d-39cae1e89ef4");
            DateTime date = new DateTime(2025, 1, 1);
            string nota = "NOTAS DE LA EVALUACION PERIODICA";
            decimal height = 170;
            decimal weight = 90;
            int systolic = 100;
            int diastolic = 80;
            int heartRate = 100;
            var command = new CreatePeriodicEvaluationCommand(id, idPatient, date, nota, 80, 170, systolic, diastolic, heartRate);
            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.CreatePeriodicEvaluation(command);

            // Assert
            result.Should().BeOfType<ObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            objectResult.Value.Should().Be("Database error");
        }

        // Prueba para el método GET: GetPeriodicEvaluation
        [Fact]
        public async Task GetPeriodicEvaluation_ReturnsOk_WhenDataExists()
        {
            // Arrange
            var expectedData = new List<PeriodicEvaluationDto>
        {
            new PeriodicEvaluationDto { Id = Guid.NewGuid(), PatientId = Guid.Parse("24f360f3-346a-4ae4-a54d-39cae1e89ef4")},
            new PeriodicEvaluationDto { Id = Guid.NewGuid(), PatientId = Guid.Parse("269d8e2c-1e91-454f-9423-c60db9023a55")}
        };
            
        _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetPeriodicEvaluationQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedData);

            // Act
            var result = await _controller.GetPeriodicEvaluation();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(expectedData);
        }

        [Fact]
        public async Task GetPeriodicEvaluation_Returns500_WhenExceptionOccurs()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetPeriodicEvaluationQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.GetPeriodicEvaluation();

            // Assert
            result.Should().BeOfType<ObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            objectResult.Value.Should().Be("Database error");
        }
    }
}
