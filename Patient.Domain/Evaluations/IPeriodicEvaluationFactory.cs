using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Evaluations
{
    public interface IPeriodicEvaluationFactory
    {
        PeriodicEvaluation Create(Guid id, Guid patientId, DateTime date, string evaluationNotes, WeightValue weight, HeightValue height, BloodPressureValue bloodPressure, HeartRateValue heartRate);

    }
}
