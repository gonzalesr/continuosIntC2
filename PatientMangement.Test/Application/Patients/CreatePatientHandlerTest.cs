using Microsoft.AspNetCore.Components.Forms;
using Moq;
using PatientManagement.Application.Patients.CreatePatient;
using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace PatientMangement.Test.Application.Patients
{
    public class CreatePatientHandlerTest

    {
        private readonly Mock<IPatientFactory> _patientFactory;
        private readonly Mock<IPatientRepository> _patientRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CreatePatientHandlerTest()
        {
            _patientFactory = new Mock<IPatientFactory>();
            _patientRepository = new Mock<IPatientRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }


        [Fact]
        public async Task Handle_CreatePatientAndSaveToRepository_WhenCommandIsValid()
        {
            // Arrange
            Guid patientId = Guid.NewGuid();

            var command = new CreatePatientCommand(
                patientId,
                "John Doe",
                new DateTime(2000, 1, 1),
                 "Male",
                "john.doe@example.com",
                 new List<CreatePatientPhoneCommand>
                   {
                       new CreatePatientPhoneCommand ("123-456-7890" )
                   });
            var mockPatient = new Patient(patientId, command.name, command.birthDate, command.gender, new EmailValue(command.email));
            foreach (var phone in command.phones)
            {
                mockPatient.AddPhone(phone.Number);
            }

            // Configura el mock de IPatientFactory
            _patientFactory.Setup(factory => factory.Create(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<string>(),
                It.IsAny<EmailValue>()
            )).Returns(mockPatient);

            // Mock de repositorio y unit of work
            _patientRepository.Setup(repo => repo.AddAsync(It.IsAny<Patient>()))
                .Returns(Task.CompletedTask);  // Asegúrate de que esto se devuelve sin problemas

            _unitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);  // Lo mismo para CommitAsync


            var handler = new CreatePatientHandler(_patientFactory.Object, _patientRepository.Object, _unitOfWork.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Single(mockPatient.Phones);

            Assert.Equal(patientId, result);

           // Verificar que los teléfonos se añaden al paciente
            Assert.Equal("123-456-7890", mockPatient.Phones.ToList()[0].Number);

            // Verificar que se guarda en el repositorio
            _patientRepository.Verify(repo => repo.AddAsync(mockPatient), Times.Once);

            // Verificar que se llama a CommitAsync
            _unitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
