using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Evaluations.GetEvaluations
{
     public class PeriodicEvaluationDto
     {
          public Guid Id { get; set; }
          public Guid PatientId { get; set; }
          public DateTime Date { get; set; }
          public string EvaluationNotes { get; set; }
          public decimal Weight { get; set; }
          public decimal Height { get; set; }
          public int Systolic { get; set; }
          public int Diastolic { get; set; }
          public int HeartRate { get; set; }
     }
}
