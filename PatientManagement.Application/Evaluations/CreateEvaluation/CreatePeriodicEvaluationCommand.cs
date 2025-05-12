using MediatR;
using PatientManagement.Domain.Evaluations;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Evaluations.CreateEvaluation
{
     public record CreatePeriodicEvaluationCommand(Guid id, Guid patientId, DateTime date, string evaluationNotes, decimal weight, decimal height, int Systolic, int Diastolic, int heartRate) : IRequest<Guid>;
}
