using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Patients.GetPatients
{
    public record GetPatientsQuery(string SearchTerm) : IRequest<IEnumerable<PatientDto>>;
}
