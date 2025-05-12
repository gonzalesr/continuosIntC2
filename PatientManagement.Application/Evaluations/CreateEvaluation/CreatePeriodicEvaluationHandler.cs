using MediatR;
using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Evaluations;
using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PatientManagement.Application.Evaluations.CreateEvaluation
{
    public class CreatePeriodicEvaluationHandler : IRequestHandler<CreatePeriodicEvaluationCommand, Guid>
    {
        private readonly IPeriodicEvaluationFactory _periodicEvaluationFactory;
        private readonly IPeriodicEvaluationRepository _periodicEvaluationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePeriodicEvaluationHandler(IPeriodicEvaluationFactory periodicEvaluationFactory,
            IPeriodicEvaluationRepository periodicEvaluationRepository,
            IUnitOfWork unitOfWork) {
            _periodicEvaluationFactory = periodicEvaluationFactory;
            _periodicEvaluationRepository = periodicEvaluationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePeriodicEvaluationCommand request, CancellationToken cancellationToken) {
            // Reconstruir BloodPressureValue desde los valores separados
            var bloodPressure = new BloodPressureValue(request.Systolic, request.Diastolic);
            var periodicEvaluation = _periodicEvaluationFactory.Create(request.id, request.patientId, request.date, request.evaluationNotes, request.weight, request.height, bloodPressure, request.heartRate);

            await _periodicEvaluationRepository.AddAsync(periodicEvaluation);

            await _unitOfWork.CommitAsync(cancellationToken);

            return periodicEvaluation.Id;
        }


    }
}
