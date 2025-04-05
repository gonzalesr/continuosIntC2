using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Evaluations
{
    public interface IPeriodicEvaluationRepository : IRepository<PeriodicEvaluation>
    {
        Task UpdateAsync(PeriodicEvaluation periodicEvaluation);
        Task DeleteAsync(Guid id);
    }
}
