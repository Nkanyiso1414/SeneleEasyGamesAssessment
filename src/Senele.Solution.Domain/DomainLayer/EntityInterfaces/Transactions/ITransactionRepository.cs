
using Senele.Solution.DomainLayer.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Senele.Solution.DomainLayer.EntityInterfaces.Transactions
{
	public interface ITransactionRepository : IBasicRepository<ITransaction, int>
	{
		Task CreatTransactionAsync(CreateTransaction Model, CancellationToken Token = default);
		Task<TransactionInfo> GetTransactionByIdAsync(int TransactionId, CancellationToken Token = default);
        Task<IEnumerable<TransactionInfo>> GetTransactionByClientIdAsync(int ClientId, CancellationToken Token = default);
        Task<IEnumerable<TransactionInfo>> GetAllTransactionsAsync(CancellationToken Token = default);
		Task UpdateTransactionAsync(UpdateTransaction Model, CancellationToken Token = default);
	}
}
