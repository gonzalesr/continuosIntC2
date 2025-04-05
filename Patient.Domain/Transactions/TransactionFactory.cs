using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Transactions;

public class TransactionFactory : ITransactionFactory
{
    public Transaction CreateTransaction(Guid userCreatorId)
    {
        if (userCreatorId == Guid.Empty)
        {
            throw new ArgumentException("User creator id is required");
        }
        var transaction = new Transaction(userCreatorId);



        return transaction;
    }
}
