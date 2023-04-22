using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using Senele.Solution.ApplicationContractsLayer.Transactions.DTO;
using Senele.Solution.Web.ViewModels.Clients;
using System.Collections.Generic;

namespace Senele.Solution.Web.ViewModels.Transactions
{
    public class ClientTransactionInfoViewModel
    {
        public ClientInfoViewModel clientInfo { get; set; }
        public List<TransactionInfoViewModel> transactionInfo { get; set; }

        public ClientTransactionInfoViewModel()
        {
            clientInfo = new ClientInfoViewModel();
            transactionInfo = new List<TransactionInfoViewModel>();

        }
    }
}
