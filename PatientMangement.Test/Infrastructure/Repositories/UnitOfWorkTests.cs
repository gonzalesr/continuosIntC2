using Moq;
using PatientManagement.Infrastructure.Repositories;
using PatientManagement.Infrastructure.DomainModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using PatientManagement.Domain.Abstractions;


namespace PatientMangement.Test.Infrastructure.Repositories
{
    public class UnitOfWorkTests
    {
        private readonly Mock<DomainDbContext> _mockDbContext;
        private readonly Mock<IMediator> _mockMediator;
        private readonly UnitOfWork _unitOfWork;

        public UnitOfWorkTests()
        {
            _mockDbContext = new Mock<DomainDbContext>();
            _mockMediator = new Mock<IMediator>();
            _unitOfWork = new UnitOfWork(_mockDbContext.Object, _mockMediator.Object);
        }

        [Fact]
        public async Task CommitAsync_ShouldCallSaveChangesOnce_WhenTransactionCountIsOne()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            // Simulamos que la propiedad ChangeTracker tiene entradas con eventos de dominio
            var mockEntry = new Mock<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity>>();
            mockEntry.Setup(x => x.Entity.DomainEvents).Returns(new List<INotification> { new Mock<INotification>().Object });

            var mockChangeTracker = new Mock<Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker>();
            mockChangeTracker.Setup(x => x.Entries<Entity>()).Returns(new List<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity>> { mockEntry.Object });

            _mockDbContext.Setup(db => db.ChangeTracker).Returns(mockChangeTracker.Object);
            _mockDbContext.Setup(db => db.SaveChangesAsync(cancellationToken)).ReturnsAsync(1);

            // Act
            await _unitOfWork.CommitAsync(cancellationToken);

            // Assert
            _mockDbContext.Verify(db => db.SaveChangesAsync(cancellationToken), Times.Once);
        }
        [Fact]
        public async Task CommitAsync_ShouldPublishDomainEvents_WhenThereAreDomainEvents()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            var domainEventMock = new Mock<INotification>();
            var mockEntry = new Mock<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity>>();
            mockEntry.Setup(x => x.Entity.DomainEvents).Returns(new List<INotification> { domainEventMock.Object });

            var mockChangeTracker = new Mock<Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker>();
            mockChangeTracker.Setup(x => x.Entries<Entity>()).Returns(new List<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity>> { mockEntry.Object });

            _mockDbContext.Setup(db => db.ChangeTracker).Returns(mockChangeTracker.Object);

            // Act
            await _unitOfWork.CommitAsync(cancellationToken);

            // Assert
            _mockMediator.Verify(mediator => mediator.Publish(It.IsAny<INotification>(), cancellationToken), Times.Once);
        }

        [Fact]
        public async Task CommitAsync_ShouldNotCallSaveChanges_WhenTransactionCountIsGreaterThanOne()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            // Simulamos que la propiedad ChangeTracker tiene entradas con eventos de dominio
            var mockEntry = new Mock<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity>>();
            mockEntry.Setup(x => x.Entity.DomainEvents).Returns(new List<INotification> { new Mock<INotification>().Object });

            var mockChangeTracker = new Mock<Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker>();
            mockChangeTracker.Setup(x => x.Entries<Entity>()).Returns(new List<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity>> { mockEntry.Object });

            _mockDbContext.Setup(db => db.ChangeTracker).Returns(mockChangeTracker.Object);

            // Simulamos una transacción ya iniciada
            var unitOfWork = new UnitOfWork(_mockDbContext.Object, _mockMediator.Object);
            await unitOfWork.CommitAsync(cancellationToken);  // Primera llamada (transacción 1)

            // Act
            await unitOfWork.CommitAsync(cancellationToken);  // Segunda llamada (transacción > 1)

            // Assert
            _mockDbContext.Verify(db => db.SaveChangesAsync(cancellationToken), Times.Once);
        }
    }
}
