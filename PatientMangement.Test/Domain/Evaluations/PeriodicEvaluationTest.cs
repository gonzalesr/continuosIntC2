using PatientManagement.Domain.Evaluations;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMangement.Test.Domain.Evaluations
{
    public class PeriodicEvaluationTest
    {
        [Fact]
        public void PeriodicEvaluationCreateIsValid()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Guid idPatient = Guid.Parse("24f360f3-346a-4ae4-a54d-39cae1e89ef4");
            DateTime date = new DateTime(2025, 1, 1);
            string nota = "NOTAS DE LA EVALUACION PERIODICA";
            HeightValue height = 170;
            WeightValue weight = 90;
            BloodPressureValue bloodPressureValue = new BloodPressureValue(100, 40);
            HeartRateValue heartRateValue = new HeartRateValue(50);

            //Act

            PeriodicEvaluation periodic = new PeriodicEvaluation(id, idPatient, date, nota, weight, height, bloodPressureValue, heartRateValue);

            //Assert
            Assert.Equal(id, periodic.Id);
            Assert.Equal(idPatient, periodic.PatientId);
            Assert.Equal(date, periodic.Date);
            Assert.Equal(nota, periodic.EvaluationNotes);
            Assert.Equal(weight, periodic.Weight);
            Assert.Equal(height, periodic.Height);
            Assert.Equal(bloodPressureValue, periodic.BloodPressure);
            Assert.Equal(heartRateValue, periodic.HeartRate);

        }
    }
}
