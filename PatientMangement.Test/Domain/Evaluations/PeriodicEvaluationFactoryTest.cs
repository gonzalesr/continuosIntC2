using FluentAssertions;
using PatientManagement.Domain.Evaluations;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMangement.Test.Domain.Evaluations
{
    public class PeriodicEvaluationFactoryTests
    {
        private readonly PeriodicEvaluationFactory _factory;

        public PeriodicEvaluationFactoryTests()
        {
            _factory = new PeriodicEvaluationFactory();
        }

        [Fact]
        public void Create_WithValidParameters_ShouldReturnPeriodicEvaluation()
        {
            // Arrange
            var id = Guid.NewGuid();
            var patientId = Guid.NewGuid();
            var date = DateTime.UtcNow;
            var evaluationNotes = "Healthy";
            var weight = new WeightValue(70);
            var height = new HeightValue(175);
            var bloodPressure = new BloodPressureValue(120, 80);
            var heartRate = new HeartRateValue(72);

            // Act
            var evaluation = _factory.Create(id, patientId, date, evaluationNotes, weight, height, bloodPressure, heartRate);

            // Assert
            evaluation.Should().NotBeNull();
            evaluation.Id.Should().Be(id);
            evaluation.PatientId.Should().Be(patientId);
            evaluation.Date.Should().Be(date);
            evaluation.EvaluationNotes.Should().Be(evaluationNotes);
            evaluation.Weight.Should().Be(weight);
            evaluation.Height.Should().Be(height);
            evaluation.BloodPressure.Should().Be(bloodPressure);
            evaluation.HeartRate.Should().Be(heartRate);
        }

        [Fact]
        public void Create_WithEmptyId_ShouldThrowArgumentException()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var date = DateTime.UtcNow;
            var evaluationNotes = "Healthy";
            var weight = new WeightValue(70);
            var height = new HeightValue(175);
            var bloodPressure = new BloodPressureValue(120, 80);
            var heartRate = new HeartRateValue(72);

            // Act
            Action act = () => _factory.Create(Guid.Empty, patientId, date, evaluationNotes, weight, height, bloodPressure, heartRate);

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
            var evaluationNotes = "Healthy";
            var weight = new WeightValue(70);
            var height = new HeightValue(175);
            var bloodPressure = new BloodPressureValue(120, 80);
            var heartRate = new HeartRateValue(72);

            // Act
            Action act = () => _factory.Create(id, Guid.Empty, date, evaluationNotes, weight, height, bloodPressure, heartRate);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("paciente es requerido*")
                .And.ParamName.Should().Be("patientId");
        }
    }
}
