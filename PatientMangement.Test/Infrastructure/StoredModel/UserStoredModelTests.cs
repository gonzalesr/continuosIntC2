
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PatientManagement.Infrastructure.StoredModel.Entities;
using System.Reflection.PortableExecutable;
using Xunit.Sdk;

namespace PatientMangement.Test.Infrastructure.StoredModel
{
    public class UserStoredModelTests
    {
        [Fact]
        public void UserStoredModel_Should_HaveValidProperties()
        {
            // Arrange
            var user = new UserStoredModel
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe"
            };

            // Act & Assert
            user.Id.Should().NotBeEmpty();
            user.FullName.Should().NotBeNullOrEmpty().And.HaveLength(8, "John Doe");
        }

        [Fact]
        public void UserStoredModel_Should_ThrowValidationError_When_FullNameIsNull()
        {
            // Arrange
            var user = new UserStoredModel
            {
                Id = Guid.NewGuid(),
                FullName = null // Esto debería causar un error de validación
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(user, null, null);

            // Act
            bool isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse();
            validationResults.Should().Contain(x => x.ErrorMessage.Contains("The FullName field is required."));
        }

        [Fact]
        public void UserStoredModel_Should_ThrowValidationError_When_FullNameExceedsMaxLength()
        {
            // Arrange
            var user = new UserStoredModel
            {
                Id = Guid.NewGuid(),
                FullName = new string('A', 251) // 251 caracteres, debe fallar
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(user, null, null);

            // Act
            bool isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            isValid.Should().BeFalse();
            validationResults.Should().Contain(x => x.ErrorMessage.Contains("The field FullName must be a string with a maximum length of 250."));
            
        }
    }
}