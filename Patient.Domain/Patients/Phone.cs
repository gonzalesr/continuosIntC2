using PatientManagement.Domain.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PatientManagement.Domain.Patients
{
    public class Phone : AggregateRoot
    {
        public string Number { get; private set; }
        public Phone(Guid id, string number) : base(id)
        {
            Number = number;
        }
        public Guid PatientId { get; private set; }
        public Phone(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("El número de teléfono no puede estar vacío.", nameof(number));

            Number = number;
        }

        public Phone(Guid id, Guid patientId, string number)
        {
            if (id == Guid.Empty) throw new ArgumentException("Id cannot be empty", nameof(id));
            if (patientId == Guid.Empty) throw new ArgumentException("PatientId cannot be empty", nameof(patientId));
            if (string.IsNullOrEmpty(number)) throw new ArgumentException("Number cannot be empty", nameof(number));

            Id = id;
            PatientId = patientId;
            Number = number;
        }

        //Need for EF Core
        private Phone() { }

    }
}
