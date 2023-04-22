using Senele.Solution.Configuration.CommandAndConnectionManager;
using Senele.Solution.DomainLayer.Entities.Transactions;
using Senele.Solution.DomainLayer.Entities.TransactionTypes;
using Senele.Solution.DomainLayer.EntityInterfaces.TransactionTypes;
using Senele.Solution.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Senele.Solution.RepositoriesLayer.TransactionTypes
{
	public class TransactionTypeRepository : EfCoreRepository<SolutionDbContext, ITransactionType, int>, ITransactionTypeRepository
	{
		public TransactionTypeRepository(IDbContextProvider<SolutionDbContext> DbContextProvider) : base(DbContextProvider)
		{
		}

		public async Task<IEnumerable<TransactionTypeInfo>> GetAllTransactionTypesAsync(CancellationToken Token = default)
		{
			await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

			await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "GetAllTransactionTypes", CommandType.StoredProcedure);
			await using var DataReader = await Command.ExecuteReaderAsync(Token);
			return await DataReader.MapToList<TransactionTypeInfo>(Token);
		}
	}
}
