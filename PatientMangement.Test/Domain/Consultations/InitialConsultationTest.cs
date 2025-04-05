using PatientManagement.Domain.Consultations;
using PatientManagement.Domain.Evaluations;
using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMangement.Test.Domain.Consultations
{
    public class InitialConsultationTest
    {
        [Fact]
        public void InitialConsultationCreateIsValid()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Guid idPatient = Guid.Parse("24f360f3-346a-4ae4-a54d-39cae1e89ef4");
            DateTime date = new DateTime(2025, 1, 1);
            string nota = "NOTAS DE LA EVALUACION PERIODICA";
            string observation = "OBSERVAICON DE LA EVALUACIÓN PERIODICA";
            //Act

            InitialConsultation initialConsultation = new InitialConsultation(id, idPatient, date, nota, observation);
            //Assert
            Assert.Equal(id, initialConsultation.Id);
            Assert.Equal(idPatient, initialConsultation.PatientId);
            Assert.Equal(date, initialConsultation.Date);
            Assert.Equal(nota, initialConsultation.Reason);
            Assert.Equal(observation,initialConsultation.Observations);

        }
    }
}
