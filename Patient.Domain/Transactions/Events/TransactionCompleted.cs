using PatientManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Transactions.Events
{
    public record TransactionCompleted : DomainEvent
    {
        public Guid TransactionId { get; init; }

        public TransactionCompleted(Guid transactionId)
        {
            TransactionId = transactionId;
           
        }
    }
}
