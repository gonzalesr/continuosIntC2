
using Moq;
using PatientManagement.Application.Evaluations.CreateEvaluation;
using PatientManagement.Application.Patients.CreatePatient;
using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Evaluations;
using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace PatientMangement.Test.Application.Evaluations.CreateEvaluation
{
    public class CreatePeriodicEvaluationHandlerTest
    {
        private readonly Mock<IPeriodicEvaluationFactory> _periodicEvaluationFactory;
        private readonly Mock<IPeriodicEvaluationRepository> _periodicEvaluationRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CreatePeriodicEvaluationHandlerTest()
        {
            _periodicEvaluationFactory = new Mock<IPeriodicEvaluationFactory>();
            _periodicEvaluationRepository = new Mock<IPeriodicEvaluationRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task Handle_CreatePeriodicEvaluationAndSaveToRepository_WhenCommandIsValid()
        {
            // Arrange
            Guid Id = Guid.NewGuid();

            var command = new CreatePeriodicEvaluationCommand(
                Id,
                Guid.Parse("24f360f3-346a-4ae4-a54d-39cae1e89ef4"),
                new DateTime(1990, 1, 1),
                "NOTAS DE LA EVALUACION PERIODICA",
                new WeightValue(78),
                new HeightValue(170),
                100,
                40,
                100
                );
            var mockpPeriodicEvaluation = new PeriodicEvaluation(Id,command.patientId,command.date,command.evaluationNotes,command.weight,command.height,
                new BloodPressureValue(command.Systolic,command.Diastolic), new HeartRateValue(command.heartRate));
           
            // Configura el mock de IPeriodicEvaluationFactory
            _periodicEvaluationFactory.Setup(factory => factory.Create(
                It.IsAny<Guid>(),
                It.IsAny<Guid>(),
                It.IsAny<DateTime>(),
                It.IsAny<string>(),
                It.IsAny<WeightValue>(),
                It.IsAny<HeightValue>(),
                It.IsAny<BloodPressureValue>(),
                                It.IsAny<HeartRateValue>()
            )).Returns(mockpPeriodicEvaluation);

            // Mock de repositorio y unit of work
            _periodicEvaluationRepository.Setup(repo => repo.AddAsync(It.IsAny<PeriodicEvaluation>()))
                .Returns(Task.CompletedTask);  // Asegúrate de que esto se devuelve sin problemas

            _unitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);  // Lo mismo para CommitAsync


            var handler = new CreatePeriodicEvaluationHandler(_periodicEvaluationFactory.Object, _periodicEvaluationRepository.Object, _unitOfWork.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            //Assert.Single(mockpPeriodicEvaluation.Id);

            Assert.Equal(Id, result);

            // Verificar que el paciente se crea correctamente
            _periodicEvaluationFactory.Verify(factory => factory.Create(command.id,command.patientId,command.date,command.evaluationNotes,command.weight,
                command.height,new BloodPressureValue(100,40), new HeartRateValue(100)), Times.Once);

            
            // Verificar que se guarda en el repositorio
            _periodicEvaluationRepository.Verify(repo => repo.AddAsync(mockpPeriodicEvaluation), Times.Once);

            // Verificar que se llama a CommitAsync
            _unitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
