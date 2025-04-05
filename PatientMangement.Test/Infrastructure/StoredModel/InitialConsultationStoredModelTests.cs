using FluentAssertions;
using PatientManagement.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PatientMangement.Test.Infrastructure.StoredModel
{
    public class InitialConsultationStoredModelTests
    {
        [Fact]
        public void InitialConsultationStoredModel_ShouldHaveRequiredAttributes()
        {
            // Arrange
            // Arrange
            var consultation = new InitialConsultationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = default, // Esto hará que falle la validación porque la fecha está vacía
                Reason = "", // Esto ya generará un error de validación por el atributo [Required]
                Observations = "No issues observed"
            };
            // Act
            var validationContext = new ValidationContext(consultation);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(consultation, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse(); // Debe ser inválido porque algunos campos requeridos están vacíos

            validationResults.Should().Contain(r => r.MemberNames.Contains("Date"));
            validationResults.Should().Contain(r => r.MemberNames.Contains("Reason"));
        }

        [Fact]
        public void InitialConsultationStoredModel_ShouldBeValidWhenAllRequiredFieldsAreFilled()
        {
            // Arrange
            var consultation = new InitialConsultationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = DateTime.Now,
                Reason = "Routine check-up",
                Observations = "No issues observed"
            };

            // Act
            var validationContext = new ValidationContext(consultation);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(consultation, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeTrue(); // Debe ser válido porque todos los campos requeridos están completos
            validationResults.Should().BeEmpty();
        }

        [Fact]
        public void InitialConsultationStoredModel_ShouldFailValidationForTooLongReason()
        {
            // Arrange
            var consultation = new InitialConsultationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = DateTime.Now,
                Reason = new string('a', 251), // Esto debe fallar porque la longitud máxima es 250
                Observations = "No issues observed"
            };

            // Act
            var validationContext = new ValidationContext(consultation);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(consultation, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse(); // Debe ser inválido por el campo Reason demasiado largo
            validationResults.Should().Contain(r => r.MemberNames.Contains("Reason"));
        }

        [Fact]
        public void InitialConsultationStoredModel_ShouldFailValidationIfDateIsNotProvided()
        {
            // Arrange
            var consultation = new InitialConsultationStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = default, // Esto debe fallar porque la fecha es requerida
                Reason = "Routine check-up",
                Observations = "No issues observed"
            };

            // Act
            var validationContext = new ValidationContext(consultation);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(consultation, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse(); // Debe ser inválido debido a la fecha no proporcionada
            validationResults.Should().Contain(r => r.MemberNames.Contains("Date"));
        }
    }
}
