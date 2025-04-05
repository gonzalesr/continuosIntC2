using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PatientManagement.Domain.Transactions
{
    public interface ITransactionFactory
    {
        Transaction CreateTransaction(Guid userCreatorId);
    }
}
