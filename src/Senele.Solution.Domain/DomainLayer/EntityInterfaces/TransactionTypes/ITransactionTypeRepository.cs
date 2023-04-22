
using Senele.Solution.DomainLayer.Entities.TransactionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Senele.Solution.DomainLayer.EntityInterfaces.TransactionTypes
{
	public interface ITransactionTypeRepository : IBasicRepository<ITransactionType, int>
	{
		Task<IEnumerable<TransactionTypeInfo>> GetAllTransactionTypesAsync(CancellationToken Token = default);
	}
}
