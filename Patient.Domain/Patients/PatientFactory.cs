using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Domain.Shared;

namespace PatientManagement.Domain.Patients
{
    public class PatientFactory:IPatientFactory
    {
        public Patient Create(Guid id, string name, DateTime birthDate, string gender, EmailValue email)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id es requerido", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("nombre es requerido", nameof(name));
            }

            return new Patient(id, name,birthDate,gender,email);

        }
    }
}
