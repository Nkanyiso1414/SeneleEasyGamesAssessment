using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Application.Services;
using Senele.Solution.ApplicationContractsLayer.Transactions.DTO;

namespace Senele.Solution.ApplicationContractsLayer.Transactions
{
	public interface ITransactionAppService : IApplicationService
	{
		Task CreatTransactionAsync(CreateTransactionDto Model);
		Task<TransactionInfoDto> GetTransactionByIdAsync(int TransactionId);
        Task<ClientTransactionInfoDto> GetTransactionByClientIdAsync(int ClientId);
        Task<IEnumerable<TransactionInfoDto>> GetAllTransactionsAsync();
		Task UpdateTransactionAsync(UpdateTransactionDto Model);
	}
}
