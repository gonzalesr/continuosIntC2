using FluentAssertions;
using Moq;
using PatientManagement.Application.InitialConsultation.CreateInitialConsultation;
using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMangement.Test.Application.InitialConsultation
{
    public class CreateInitialConsultationHandlerTests
    {
        private readonly Mock<IInitialConsultationFactory> _mockFactory;
        private readonly Mock<IInitialConsultationRepository> _mockRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public CreateInitialConsultationHandlerTests()
        {
            _mockFactory = new Mock<IInitialConsultationFactory>();
            _mockRepository = new Mock<IInitialConsultationRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

        }

        [Fact]
        public async Task Handle_ShouldCreateAndSaveInitialConsultation()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var command = new CreateInitialConsultationCommand
            ( Guid.NewGuid(),
                 Guid.NewGuid(),
                DateTime.UtcNow,
                "Routine check-up",
                "No observations"
            );

            var expectedConsultation = new PatientManagement.Domain.Consultations.InitialConsultation (command.id, command.patientId, command.date, command.reason, command.observations);

            _mockFactory.Setup(f => f.Create(command.id, command.patientId, command.date, command.reason, command.observations))
                        .Returns(expectedConsultation);
            var handler = new CreateInitialConsultationHandler (_mockFactory.Object, _mockRepository.Object, _mockUnitOfWork.Object);

            // Act
            var result = await handler.Handle(command, cancellationToken);

            // Assert
            result.Should().Be(expectedConsultation.Id);

            _mockFactory.Verify(f => f.Create(command.id, command.patientId, command.date, command.reason, command.observations), Times.Once);
            _mockRepository.Verify(r => r.AddAsync(expectedConsultation), Times.Once);
            _mockUnitOfWork.Verify(u => u.CommitAsync(cancellationToken), Times.Once);
        }
    }
}
