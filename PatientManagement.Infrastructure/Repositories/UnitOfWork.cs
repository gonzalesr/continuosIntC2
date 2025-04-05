using PatientManagement.Domain.Abstractions;
using PatientManagement.Infrastructure.DomainModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace PatientManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DomainDbContext _dbContext;
        private readonly IMediator _mediator;

        private int _transactionCount = 0;

        public UnitOfWork(DomainDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            _transactionCount++;

            var domainEvents = _dbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x =>
                {
                    var domainEvents = x.Entity
                                    .DomainEvents
                                    .ToImmutableArray();
                    x.Entity.ClearDomainEvents();

                    return domainEvents;
                })
                .SelectMany(domainEvents => domainEvents)
                .ToList();

            foreach (var e in domainEvents)
            {
                await _mediator.Publish(e, cancellationToken);

            }

            if (_transactionCount == 1)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                _transactionCount--;
            }


        }
    }
}
