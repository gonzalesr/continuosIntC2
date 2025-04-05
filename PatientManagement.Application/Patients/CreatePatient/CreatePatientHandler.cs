using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Patients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Patients.CreatePatient
{
    public class CreatePatientHandler: IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientFactory _patientFactory;
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientHandler(IPatientFactory patientFactory,
            IPatientRepository patientRepository,
            IUnitOfWork unitOfWork)
        {
            _patientFactory = patientFactory;
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {

            var patient = _patientFactory.Create(request.Id, request.name, request.birthDate,  request.gender, request.email);


                foreach (var phone in request.phones)
                {
                if (phone != null)
                {
                    patient.AddPhone(phone.Number);
                }
            }


            await _patientRepository.AddAsync(patient);

            await _unitOfWork.CommitAsync(cancellationToken);

            return patient.Id;
        }

    }
}
