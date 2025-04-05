using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PatientManagement.Domain.Evaluations
{
    public class PeriodicEvaluationFactory : IPeriodicEvaluationFactory
    {
        public PeriodicEvaluation Create(Guid id, Guid patientId, DateTime date, string evaluationNotes, WeightValue weight, HeightValue height, BloodPressureValue bloodPressure, HeartRateValue heartRate)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id es requerido", nameof(id));
            }

            if (patientId == Guid.Empty)
            {
                throw new ArgumentException("paciente es requerido", nameof(patientId));
            }

            return new PeriodicEvaluation(id, patientId, date, evaluationNotes, weight, height, bloodPressure, heartRate);
        }

    }
}
