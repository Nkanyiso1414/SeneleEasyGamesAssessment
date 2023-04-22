
using Senele.Solution.ApplicationContractsLayer.TransactionTypes;
using Senele.Solution.ApplicationContractsLayer.TransactionTypes.DTO;
using Senele.Solution.DomainLayer.Entities.TransactionTypes;
using Senele.Solution.DomainLayer.EntityInterfaces.TransactionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Senele.Solution.AppServiceLayer.TransactionTypes
{
	public class TransactionTypeAppService : SolutionAppService, ITransactionTypeAppService
	{
		private readonly ITransactionTypeRepository _transactionTypeRepository;
		public TransactionTypeAppService(ITransactionTypeRepository transactionTypeAppServiceObj)
		{
			_transactionTypeRepository = transactionTypeAppServiceObj;
		}

		public async Task<IEnumerable<TransactionTypeInfoDto>> GetAllTransactionTypesAsync(CancellationToken Token = default)
		{
			var ReturnResult = await _transactionTypeRepository.GetAllTransactionTypesAsync();
			return ObjectMapper.Map<IEnumerable<TransactionTypeInfo>, IEnumerable<TransactionTypeInfoDto>>(ReturnResult);
		}
	}
}
