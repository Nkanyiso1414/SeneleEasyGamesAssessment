using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senele.Solution.ApplicationContractsLayer.Transactions.DTO
{
   public class ClientTransactionInfoDto
    {
        public ClientInfoDto clientInfo { get; set; }
        public List<TransactionInfoDto> transactionInfo { get; set; }

        public ClientTransactionInfoDto()
        {
            clientInfo = new ClientInfoDto();
            transactionInfo = new List<TransactionInfoDto>();

        }
    }
}
