using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientManagement.Application.Patients.CreatePatient;
using PatientManagement.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;
using PatientManagement.Application.Patients.GetPatients;
using Xunit;
using PatientManagement.Domain.Patients;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PatientManagement.Application.InitialConsultation.GetInitialConsultations;

namespace PatientMangement.Test.WebApi
{
    public class PatientControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly PatientController _controller;

        public PatientControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new PatientController(_mediatorMock.Object);
        }

        // ✅ Prueba para el método POST: CreatePatient
        [Fact]
        public async Task CreatePatient_ReturnsOk_WhenCommandIsValid()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = "NOMBRE PACIENTE";
            DateTime fecnac = new DateTime(2010, 1, 1);
            string gender = "MALE";
            string mail = "user@gmail.com";
            var phones = new List<CreatePatientPhoneCommand>
{
    new CreatePatientPhoneCommand("566666555|||111111"),
    new CreatePatientPhoneCommand("22222222345348")
};
            var command = new CreatePatientCommand(id, name, fecnac, gender, mail, phones);
            var expectedId = Guid.NewGuid();
            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedId);

            // Act
            var result = await _controller.CreatePatient(command);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().Be(expectedId);
        }

        [Fact]
        public async Task CreatePatient_Returns500_WhenExceptionOccurs()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = "NOMBRE PACIENTE";
            DateTime fecnac = new DateTime(2010, 1, 1);
            string gender = "MALE";
            string mail = "user@gmail.com";
            var phones = new List<CreatePatientPhoneCommand>
{
    new CreatePatientPhoneCommand("566666555|||111111"),
    new CreatePatientPhoneCommand("22222222345348")
};
            var command = new CreatePatientCommand(id, name, fecnac, gender, mail, phones);

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.CreatePatient(command);

            // Assert
            result.Should().BeOfType<ObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            objectResult.Value.Should().Be("Database error");
        }

        // ✅ Prueba para el método GET: GetPatients
        [Fact]
        public async Task GetPatients_ReturnsOk_WhenDataExists()
        {
            // Arrange
            var expectedPatients = new List<PatientDto>
        {
            new PatientDto { Id = Guid.NewGuid(), Name = "John Doe" },
            new PatientDto { Id = Guid.NewGuid(), Name = "Jane Smith" }
        };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetPatientsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedPatients);

            // Act
            var result = await _controller.GetPatients();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(expectedPatients);
        }

        [Fact]
        public async Task GetPatients_Returns500_WhenExceptionOccurs()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetPatientsQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.GetPatients();

            // Assert
            result.Should().BeOfType<ObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            objectResult.Value.Should().Be("Database error");
        }
    }
}
