using Senele.Solution.DomainLayer.Entities.Transactions;
using Senele.Solution.DomainLayer.EntityInterfaces.Clients;
using Senele.Solution.DomainLayer.EntityInterfaces.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Senele.Solution.DomainLayer.Managers.Transactions
{
    public class TransManager : DomainService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ITransactionRepository _transactionRepository;
        public TransManager(IClientRepository clientRepositoryObj, ITransactionRepository transactionRepositoryObj)
        {
           _clientRepository= clientRepositoryObj;
           _transactionRepository= transactionRepositoryObj;
        }
        public async Task<ClientTransactionInfo> GetTransactionByClientIdAsync(int ClientId)
        {
          var ClientInfo = await _clientRepository.GetClientByIdAsync(ClientId);
          var TransactionInfo = await _transactionRepository.GetTransactionByClientIdAsync(ClientId);

            return new ClientTransactionInfo
            {
                clientInfo = ClientInfo,
                transactionInfo = TransactionInfo.ToList()
            };
        }

        public async Task CreatTransactionAsync(CreateTransaction Model)
        {
            if(Model.Comment == null)
            {
                Model.Comment = "";
            }
            _transactionRepository.CreatTransactionAsync(Model);
        }

        public async Task UpdateTransactionAsync(UpdateTransaction Model)
        {
            if (Model.Comment == null)
            {
                Model.Comment = "";
            }
            _transactionRepository.UpdateTransactionAsync(Model);
        }
      }
}
