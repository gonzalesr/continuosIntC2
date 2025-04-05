using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Consultations
{
    public interface IInitialConsultationRepository: IRepository<InitialConsultation>
    {
        Task UpdateAsync(InitialConsultation initialConsultation);
        Task DeleteAsync(Guid id);
    }
}
