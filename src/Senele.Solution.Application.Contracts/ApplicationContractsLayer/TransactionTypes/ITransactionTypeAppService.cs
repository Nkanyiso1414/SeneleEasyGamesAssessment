using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Application.Services;
using Senele.Solution.ApplicationContractsLayer.TransactionTypes.DTO;

namespace Senele.Solution.ApplicationContractsLayer.TransactionTypes
{
	public interface ITransactionTypeAppService : IApplicationService
	{
		Task<IEnumerable<TransactionTypeInfoDto>> GetAllTransactionTypesAsync(CancellationToken Token = default);
	}
}
