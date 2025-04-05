using PatientManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Patients.Events
{
    public record PatientCreated : DomainEvent
    {       
        public Guid PatientId { get; init; }

        public PatientCreated(Guid patientId)
        {
            PatientId = patientId;
        }
    }
}
