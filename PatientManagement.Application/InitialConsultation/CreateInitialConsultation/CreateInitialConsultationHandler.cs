using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Consultations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.InitialConsultation.CreateInitialConsultation
{
     public class CreateInitialConsultationHandler : IRequestHandler<CreateInitialConsultationCommand, Guid>
     {
          private readonly IInitialConsultationFactory _initialConsultationFactory;
          private readonly IInitialConsultationRepository _initialConsultationRepository;
          private readonly IUnitOfWork _unitOfWork;

          public CreateInitialConsultationHandler(IInitialConsultationFactory initialConsultationFactory,
              IInitialConsultationRepository initialConsultationRepository,
              IUnitOfWork unitOfWork) {
               _initialConsultationFactory = initialConsultationFactory;
               _initialConsultationRepository = initialConsultationRepository;
               _unitOfWork = unitOfWork;
          }
          public async Task<Guid> Handle(CreateInitialConsultationCommand request, CancellationToken cancellationToken) {
               var initialConsultation = _initialConsultationFactory.Create(request.id, request.patientId, request.date, request.reason, request.observations);

               await _initialConsultationRepository.AddAsync(initialConsultation);

               await _unitOfWork.CommitAsync(cancellationToken);

               return initialConsultation.Id;
          }

     }
}
