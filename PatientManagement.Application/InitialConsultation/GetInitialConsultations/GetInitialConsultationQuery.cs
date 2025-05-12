using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.InitialConsultation.GetInitialConsultations
{
     public record GetInitialConsultationQuery(string SearchTerm) : IRequest<IEnumerable<InitialConsultationDto>>;
}
