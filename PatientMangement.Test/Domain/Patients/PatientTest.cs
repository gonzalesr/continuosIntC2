using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMangement.Test.Domain.Patients
{
    public class PatientTest
    {
        [Fact]
        public void PatientCreateIsValid()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            string name = "RONY GONZALES";
            DateTime birthDate= new DateTime(1990, 1, 1);
            string gender = "Male"; 
            EmailValue email = new EmailValue("john.doe@example.com");
            //Act
            Patient patient = new Patient(id, name, birthDate, gender, email);

            //Assert
            Assert.Equal(id, patient.Id);
            Assert.Equal(name, patient.Name);
            Assert.Equal(birthDate, patient.BirthDate);
            Assert.Equal(gender, patient.Gender);
            Assert.Equal(email, patient.Email);
        }

        [Fact]
        public void AddPhoneIsValid()
        {
            //Arrange
            Patient patient = CreateValidPatient();
            var phoneNumber = "71069586";
            //Act
            patient.AddPhone(phoneNumber);
            //Assert
            Assert.Single(patient.Phones);
        }

        [Fact]
        public void RemovePhoneIsValid()
        {
            // Arrange
            Patient patient = CreateValidPatient();
            var phoneNumber = "123-456-7890";

            // Se añade un teléfono para luego eliminarlo
            patient.AddPhone(phoneNumber);
            var phoneId = patient.Phones.ToList()[0].Id;

            // Act
            patient.RemovePhone(phoneId);

            // Assert
            Assert.Empty(patient.Phones); // Asegura que la lista de teléfonos esté vacía
        }
        // Método auxiliar para crear un paciente válido
        private Patient CreateValidPatient()
        {
            return new Patient(
                Guid.NewGuid(),                     // Genera un ID único para el paciente
                "John Doe",                         // Un nombre genérico válido
                new DateTime(1990, 1, 1),           // Una fecha de nacimiento válida
                "Male",                             // Un género válido
                new EmailValue("john.doe@example.com") // Una dirección de correo válida encapsulada en EmailValue
            );
        }
    }
}
