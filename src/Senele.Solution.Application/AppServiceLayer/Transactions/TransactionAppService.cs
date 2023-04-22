
using Senele.Solution.ApplicationContractsLayer.Transactions;
using Senele.Solution.ApplicationContractsLayer.Transactions.DTO;
using Senele.Solution.DomainLayer.Entities.Transactions;
using Senele.Solution.DomainLayer.EntityInterfaces.Transactions;
using Senele.Solution.DomainLayer.Managers.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Volo.Abp.ObjectMapping;

namespace Senele.Solution.AppServiceLayer.Transactions
{
	public class TransactionAppService : SolutionAppService, ITransactionAppService
	{
		private readonly ITransactionRepository _transactionRepository;
        private readonly TransManager _transactionManager;
        public TransactionAppService(ITransactionRepository transactionAppServiceObj,TransManager transactionManagerObj)
		{
			_transactionRepository = transactionAppServiceObj;
			_transactionManager = transactionManagerObj;
		}

		public async Task CreatTransactionAsync(CreateTransactionDto Model)
		{
			var DbModel = ObjectMapper.Map<CreateTransactionDto, CreateTransaction>(Model);
			await _transactionManager.CreatTransactionAsync(DbModel);
		}

		public async Task<IEnumerable<TransactionInfoDto>> GetAllTransactionsAsync()
		{
			var ReturnResult = await _transactionRepository.GetAllTransactionsAsync();
			return ObjectMapper.Map<IEnumerable<TransactionInfo>, IEnumerable<TransactionInfoDto>>(ReturnResult);
		}

        public async Task<ClientTransactionInfoDto> GetTransactionByClientIdAsync(int ClientId)
		{
            var ReturnResult = await _transactionManager.GetTransactionByClientIdAsync(ClientId);
            return ObjectMapper.Map<ClientTransactionInfo, ClientTransactionInfoDto>(ReturnResult);
        }

        public async Task<TransactionInfoDto> GetTransactionByIdAsync(int TransactionId)
		{
			var ReturnResult = await _transactionRepository.GetTransactionByIdAsync(TransactionId);
			return ObjectMapper.Map<TransactionInfo, TransactionInfoDto>(ReturnResult);
		}

		public async Task UpdateTransactionAsync(UpdateTransactionDto Model)
		{
			var DbModel = ObjectMapper.Map<UpdateTransactionDto, UpdateTransaction > (Model);
            await _transactionManager.UpdateTransactionAsync(DbModel);
		}
	}
}
