using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PatientManagement.Domain.Consultations
{
    public class InitialConsultationFactory:IInitialConsultationFactory
    {
        public InitialConsultation Create(Guid id, Guid patientId, DateTime date, string reason, string observations)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id es requerido", nameof(id));
            }

            if (patientId == Guid.Empty)
            {
                throw new ArgumentException("paciente es requerido", nameof(patientId));
            }

            return new InitialConsultation(id, patientId, date, reason, observations);

        }

    }
}
