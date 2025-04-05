using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Patients.Events;
using PatientManagement.Domain.Shared;
using PatientManagement.Domain.Consultations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Patients
{
    public class Patient:AggregateRoot
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public EmailValue Email { get; private set; }

        private List<Phone> _phones;
        public ICollection<Phone> Phones {
            get {
                return _phones;
            }
        }

        private readonly List<InitialConsultation> _consultations = new();
        public IReadOnlyCollection<InitialConsultation> Consultations => _consultations.AsReadOnly();

        public Patient(Guid id, string name, DateTime birthDate, string gender, EmailValue email): base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BirthDate = birthDate;
            Gender = gender ?? throw new ArgumentNullException(nameof(gender));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            _phones = new List<Phone>();
        }
      
        public void AddPhone(string number)
        {
            var phone = new Phone(Guid.NewGuid(), Id, number);
            _phones.Add(phone);
        }

        public void RemovePhone(Guid phoneId)
        {
            var phone = _phones.Find(p => p.Id == phoneId);
            if (phone != null)
            {
                _phones.Remove(phone);
            }
        }
    }
}
