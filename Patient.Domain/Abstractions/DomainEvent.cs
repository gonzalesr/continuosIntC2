using MediatR;

namespace PatientManagement.Domain.Abstractions;

public abstract record DomainEvent : INotification
    {
        public Guid Id { get; set; }
        public DateTime OccurredOn { get; set; }       
        public DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.Now;
        }
    }