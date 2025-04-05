using FluentAssertions;
using PatientManagement.Domain.Patients;
using PatientManagement.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PatientMangement.Test.Infrastructure.StoredModel
{
    public class PatientStoredModelTests
    {
        [Fact]
        public void PatientStoredModel_ShouldHaveRequiredAttributes()
        {
            // Arrange
            var patient = new PatientStoredModel
            {
                Id = Guid.NewGuid(),
                Name = "", // Esto ya generará un error de validación por el atributo [Required]
                BirthDate = DateTime.MinValue, // Esto generará un error de validación por ser un valor no válido
                Gender = "", // Esto ya generará un error de validación por el atributo [Required]
                Email = "", // Esto ya generará un error de validación por el atributo [Required]
                Phone = new List<PhoneStoredModel>(),
                Consultations = new List<InitialConsultationStoredModel>()
            };
            // Act
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse(); // Debe ser inválido porque algunos campos requeridos están vacíos

            validationResults.Should().Contain(r => r.MemberNames.Contains("Name"));
            validationResults.Should().Contain(r => r.MemberNames.Contains("BirthDate"));
            validationResults.Should().Contain(r => r.MemberNames.Contains("Gender"));
            validationResults.Should().Contain(r => r.MemberNames.Contains("Email"));
        }

        [Fact]
        public void PatientStoredModel_ShouldBeValidWhenAllRequiredFieldsAreFilled()
        {
            // Arrange
            var patient = new PatientStoredModel
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                BirthDate = new DateTime(1980, 1, 1),
                Gender = "Male",
                Email = "john.doe@example.com",
                Phone = new List<PhoneStoredModel>(),
                Consultations = new List<InitialConsultationStoredModel>()
            };

            // Act
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(patient, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeTrue(); // Debe ser válido porque todos los campos requeridos están llenos
            validationResults.Should().BeEmpty();
        }
    }
}
