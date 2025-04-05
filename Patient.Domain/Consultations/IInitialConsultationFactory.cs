using PatientManagement.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Consultations
{
    public interface IInitialConsultationFactory
    {
        InitialConsultation Create(Guid id, Guid patientId, DateTime date, string reason, string observations);
    }
}
