using FluentAssertions;
using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMangement.Test.Domain.Patients
{
    public class PatientFactoryTests
    {
        private readonly PatientFactory _factory;

        public PatientFactoryTests()
        {
            _factory = new PatientFactory();
        }

        [Fact]
        public void Create_ShouldReturnPatient_WhenDataIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "John Doe";
            var birthDate = new DateTime(1990, 1, 1);
            var gender = "Male";
            var email = new EmailValue("johndoe@example.com");

            // Act
            var patient = _factory.Create(id, name, birthDate, gender, email);

            // Assert
            patient.Should().NotBeNull();
            patient.Id.Should().Be(id);
            patient.Name.Should().Be(name);
            patient.BirthDate.Should().Be(birthDate);
            patient.Gender.Should().Be(gender);
            patient.Email.Should().Be(email);
        }

        [Fact]
        public void Create_ShouldThrowArgumentException_WhenIdIsEmpty()
        {
            // Arrange
            var id = Guid.Empty;
            var name = "John Doe";
            var birthDate = new DateTime(1990, 1, 1);
            var gender = "Male";
            var email = new EmailValue("johndoe@example.com");

            // Act
            Action act = () => _factory.Create(id, name, birthDate, gender, email);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Id es requerido*")
                .And.ParamName.Should().Be("id");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Create_ShouldThrowArgumentException_WhenNameIsNullOrEmpty(string invalidName)
        {
            // Arrange
            var id = Guid.NewGuid();
            var birthDate = new DateTime(1990, 1, 1);
            var gender = "Male";
            var email = new EmailValue("johndoe@example.com");

            // Act
            Action act = () => _factory.Create(id, invalidName, birthDate, gender, email);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("nombre es requerido*")
                .And.ParamName.Should().Be("name");
        }
    }
}
