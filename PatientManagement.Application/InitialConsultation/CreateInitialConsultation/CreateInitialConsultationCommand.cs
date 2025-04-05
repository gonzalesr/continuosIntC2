using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.InitialConsultation.CreateInitialConsultation
{
   public record CreateInitialConsultationCommand(Guid id, Guid patientId, DateTime date, string reason, string observations) : IRequest<Guid>;
}
