using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Evaluations.GetEvaluations
{
    public record GetPeriodicEvaluationQuery(string SearchTerm): IRequest<IEnumerable<PeriodicEvaluationDto>>;
   
}
