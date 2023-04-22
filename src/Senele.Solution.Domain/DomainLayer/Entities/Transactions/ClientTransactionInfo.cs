using Senele.Solution.DomainLayer.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senele.Solution.DomainLayer.Entities.Transactions
{
   public class ClientTransactionInfo
    {
        public ClientInfo clientInfo { get; set; }
        public List<TransactionInfo> transactionInfo { get; set; }
        public ClientTransactionInfo()
        {
            clientInfo = new ClientInfo();
            transactionInfo = new List<TransactionInfo>();
           
        }
    }
}

