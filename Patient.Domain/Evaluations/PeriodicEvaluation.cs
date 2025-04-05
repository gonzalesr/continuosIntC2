using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Evaluations
{
    public class PeriodicEvaluation : AggregateRoot
    {
        public Guid PatientId { get; private set; }
        public DateTime Date { get; private set; }
        public string EvaluationNotes { get; private set; }
        public WeightValue Weight { get; private set; }
        public HeightValue Height { get; private set; }
        public BloodPressureValue BloodPressure { get; private set; }
        public HeartRateValue HeartRate { get; private set; }



        public PeriodicEvaluation(Guid id, Guid patientId, DateTime date, string evaluationNotes, WeightValue weight, HeightValue height, BloodPressureValue bloodPressure, HeartRateValue heartRate) : base(id)
        {
            PatientId = patientId;
            Date = date;
            EvaluationNotes = evaluationNotes ?? throw new ArgumentNullException(nameof(evaluationNotes));
            Weight = weight;
            Height = height;
            BloodPressure = bloodPressure;
            HeartRate = heartRate;
        }
        public void UpdateEvaluationNotes(string evaluationNotes)
        {
            if (string.IsNullOrWhiteSpace(evaluationNotes))
                throw new ArgumentException("Las notas de la evaluación no pueden estar vacías.", nameof(evaluationNotes));

            EvaluationNotes = evaluationNotes;
        }
        private PeriodicEvaluation() { }
    }
}
