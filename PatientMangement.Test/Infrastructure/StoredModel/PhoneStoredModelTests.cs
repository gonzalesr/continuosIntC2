using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PatientManagement.Infrastructure.StoredModel.Entities;

namespace PatientMangement.Test.Infrastructure.StoredModel
{
    public class PhoneStoredModelTests
    {
        [Fact]
        public void PhoneStoredModel_Should_HaveValidProperties()
        {
            // Arrange
            var phone = new PhoneStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Number = "123456789"
            };

            // Act & Assert
            phone.Id.Should().NotBeEmpty();
            phone.PatientId.Should().NotBeEmpty();
            phone.Number.Should().HaveLength(9, "El número de teléfono debe tener 9 caracteres.");
        }

        [Fact]
        public void PhoneStoredModel_Should_ThrowValidationError_When_NumberIsNull()
        {
            // Arrange
            var phone = new PhoneStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Number = null // Debería fallar porque es [Required]
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(phone, null, null);

            // Act
            bool isValid = Validator.TryValidateObject(phone, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse();
            validationResults.Should().Contain(x => x.ErrorMessage.Contains("The Number field is required."));
        }

        [Fact]
        public void PhoneStoredModel_Should_ThrowValidationError_When_NumberExceedsMaxLength()
        {
            // Arrange
            var phone = new PhoneStoredModel
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Number = new string('1', 251) // 251 caracteres, debe fallar
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(phone, null, null);

            // Act
            bool isValid = Validator.TryValidateObject(phone, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse();
            validationResults.Should().Contain(x => x.ErrorMessage.Contains("The field Number must be a string with a maximum length of 250."));
        }
    }
}
