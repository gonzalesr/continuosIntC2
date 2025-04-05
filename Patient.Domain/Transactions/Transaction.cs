using PatientManagement.Domain.Abstractions;
using PatientManagement.Domain.Patients;
using PatientManagement.Domain.Transactions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PatientManagement.Domain.Transactions;
    public class Transaction : AggregateRoot
    {
        public Guid CreatorId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? CompletedDate { get; private set; }
        public DateTime? CancelDate { get; private set; }
        public TransactionStatus Status { get; private set; }
        private List<Phone> _phones;
    public Transaction(Guid creatorId) : base(Guid.NewGuid())
        {
            CreatorId = creatorId;
            Status = TransactionStatus.Active;
            CreationDate = DateTime.Now;            
        }

        public void Complete()
        {            
            Status = TransactionStatus.Active;
            CompletedDate = DateTime.Now;      
            AddDomainEvent(new TransactionCompleted(Id));
        }

        public void Cancel()
        {          
            Status = TransactionStatus.Inactive;
            CancelDate = DateTime.Now;
        }

       //Need for EF Core
        private Transaction() { }

}
