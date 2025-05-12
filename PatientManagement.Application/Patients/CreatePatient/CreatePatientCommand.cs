using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Patients.CreatePatient
{
     public record CreatePatientCommand(Guid Id, string name, DateTime birthDate, string gender, string email, ICollection<CreatePatientPhoneCommand> phones) : IRequest<Guid>;
     public record CreatePatientPhoneCommand(string Number);
}
