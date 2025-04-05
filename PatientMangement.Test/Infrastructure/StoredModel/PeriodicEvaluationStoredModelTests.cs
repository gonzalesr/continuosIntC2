using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Infrastructure.StoredModel.Entities;


namespace PatientMangement.Test.Infrastructure.StoredModel
{
    public class PeriodicEvaluationStoredModelTests
    {
        private List<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);
            return validationResults;
        }

        [Fact]
        public void PeriodicEvaluationStoredModel_Should_HaveValidProperties()
        {
            // Arrange
            var evaluation = new PeriodicEvaluationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                EvaluationNotes = "Paciente estable con buena recuperación.",
                Weight = 70.5m,
                Height = 1.75m,
                Systolic = 120,
                Diastolic = 80,
                HeartRate = 72
            };

            // Act & Assert
            evaluation.Id.Should().NotBeEmpty();
            evaluation.PatientId.Should().NotBeEmpty();
            evaluation.Date.Should().BeBefore(DateTime.UtcNow.AddMinutes(1)); // Fecha válida
            evaluation.EvaluationNotes.Should().NotBeNullOrEmpty();
            evaluation.Weight.Should().BePositive();
            evaluation.Height.Should().BePositive();
            evaluation.Systolic.Should().BeGreaterThan(0);
            evaluation.Diastolic.Should().BeGreaterThan(0);
            evaluation.HeartRate.Should().BeGreaterThan(0);
        }

        [Fact]
        public void PeriodicEvaluationStoredModel_Should_ThrowValidationError_When_EvaluationNotes_ExceedsMaxLength()
        {
            // Arrange
            var evaluation = new PeriodicEvaluationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                EvaluationNotes = new string('A', 2001), // Excede el límite de 2000 caracteres
                Weight = 70.5m,
                Height = 1.75m,
                Systolic = 120,
                Diastolic = 80,
                HeartRate = 72
            };

            // Act
            var validationResults = ValidateModel(evaluation);

            // Assert
            validationResults.Should().Contain(x => x.ErrorMessage.Contains("The field EvaluationNotes must be a string with a maximum length of 2000."));
        }

        [Fact]
        public void PeriodicEvaluationStoredModel_Should_ThrowValidationError_When_EvaluationNotes_IsNull()
        {
            // Arrange
            var evaluation = new PeriodicEvaluationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                EvaluationNotes = null, // Campo requerido
                Weight = 70.5m,
                Height = 1.75m,
                Systolic = 120,
                Diastolic = 80,
                HeartRate = 72
            };

            // Act
            var validationResults = ValidateModel(evaluation);

            // Assert
            validationResults.Should().Contain(x => x.ErrorMessage.Contains("The EvaluationNotes field is required."));
        }

        [Fact]
        public void PeriodicEvaluationStoredModel_Should_ThrowValidationError_When_Date_IsMissing()
        {
            // Arrange
            var evaluation = new PeriodicEvaluationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = default,
                EvaluationNotes = "Paciente estable.",
                Weight = 70.5m,
                Height = 1.75m,
                Systolic = 120,
                Diastolic = 80,
                HeartRate = 72
            };

            // Act
            var validationResults = ValidateModel(evaluation);

            // Assert
            validationResults.Should().Contain(x => x.ErrorMessage.Contains("The Date field is required."));
        }

        [Fact]
        public void PeriodicEvaluationStoredModel_Should_Allow_ValidWeightAndHeight()
        {
            // Arrange
            var evaluation = new PeriodicEvaluationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                EvaluationNotes = "Paciente estable.",
                Weight = 75.5m,  // Peso válido
                Height = 1.80m,  // Altura válida
                Systolic = 120,
                Diastolic = 80,
                HeartRate = 72
            };

            // Act & Assert
            evaluation.Weight.Should().BeGreaterThan(0);
            evaluation.Height.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(0)]     // Peso inválido
        [InlineData(-1.5)]  // Peso inválido
        public void PeriodicEvaluationStoredModel_Should_ThrowValidationError_When_Weight_IsInvalid(decimal weight)
        {
            // Arrange
            var evaluation = new PeriodicEvaluationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                EvaluationNotes = "Paciente estable.",
                Weight = weight,  // Peso no válido
                Height = 1.80m,
                Systolic = 120,
                Diastolic = 80,
                HeartRate = 72
            };

            // Act
            var validationResults = ValidateModel(evaluation);

            // Assert
            validationResults.Should().Contain(x => x.ErrorMessage.Contains("The Weight field is required."));
        }
    }
}
