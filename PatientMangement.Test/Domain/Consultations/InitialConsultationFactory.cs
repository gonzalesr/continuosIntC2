using FluentAssertions;
using PatientManagement.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMangement.Test.Domain.Consultations
{
    public class InitialConsultationFactoryTests
    {
        private readonly InitialConsultationFactory _factory;

        public InitialConsultationFactoryTests()
        {
            _factory = new InitialConsultationFactory();
        }

        [Fact]
        public void Create_WithValidParameters_ShouldReturnInitialConsultation()
        {
            // Arrange
            var id = Guid.NewGuid();
            var patientId = Guid.NewGuid();
            var date = DateTime.UtcNow;
            var reason = "General Checkup";
            var observations = "Patient is in good health.";

            // Act
            var consultation = _factory.Create(id, patientId, date, reason, observations);

            // Assert
            consultation.Should().NotBeNull();
            consultation.Id.Should().Be(id);
            consultation.PatientId.Should().Be(patientId);
            consultation.Date.Should().Be(date);
            consultation.Reason.Should().Be(reason);
            consultation.Observations.Should().Be(observations);
        }

        [Fact]
        public void Create_WithEmptyId_ShouldThrowArgumentException()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var date = DateTime.UtcNow;
            var reason = "General Checkup";
            var observations = "Patient is in good health.";

            // Act
            Action act = () => _factory.Create(Guid.Empty, patientId, date, reason, observations);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Id es requerido*")
                .And.ParamName.Should().Be("id");
        }

        [Fact]
        public void Create_WithEmptyPatientId_ShouldThrowArgumentException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var date = DateTime.UtcNow;
            var reason = "General Checkup";
            var observations = "Patient is in good health.";

            // Act
            Action act = () => _factory.Create(id, Guid.Empty, date, reason, observations);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("paciente es requerido*")
                .And.ParamName.Should().Be("patientId");
        }
    }
}
