using Microsoft.Data.SqlClient;
using Senele.Solution.Configuration.CommandAndConnectionManager;
using Senele.Solution.DomainLayer.Entities.Clients;
using Senele.Solution.DomainLayer.Entities.Transactions;
using Senele.Solution.DomainLayer.EntityInterfaces.Transactions;
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

namespace Senele.Solution.RepositoriesLayer.Transactions
{
	public class TransactionRepository : EfCoreRepository<SolutionDbContext, ITransaction, int>, ITransactionRepository
	{
		public TransactionRepository(IDbContextProvider<SolutionDbContext> DbContextProvider) : base(DbContextProvider)
		{
		}

		public async  Task CreatTransactionAsync(CreateTransaction Model, CancellationToken Token = default)
		{
			var Parameters = new[]
		   {

			   new SqlParameter("@Amount", Model.Amount),
			   new SqlParameter("@TransactionTypeId", Model.TransactionTypeID),
			   new SqlParameter("@ClientId", Model.ClientID),
			   new SqlParameter("@Comment", Model.Comment),

			};
			await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

			await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "CreateTransaction", CommandType.StoredProcedure, Parameters);
			await Command.ExecuteReaderAsync(Token);
		}

		public async Task<IEnumerable<TransactionInfo>> GetAllTransactionsAsync(CancellationToken Token = default)
		{
			await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

			await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "GetAllTransactions", CommandType.StoredProcedure);
			await using var DataReader = await Command.ExecuteReaderAsync(Token);
			return await DataReader.MapToList<TransactionInfo>(Token);
		}

        public async Task<IEnumerable<TransactionInfo>> GetTransactionByClientIdAsync(int ClientId, CancellationToken Token = default)
        {
            var Parameters = new[]
              {
               new SqlParameter("@ClientId", ClientId)

            };
            await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

            await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "GetTransactionByClientId", CommandType.StoredProcedure, Parameters);

            await using var DataReader = await Command.ExecuteReaderAsync(Token);
            return await DataReader.MapToList<TransactionInfo>(Token);
        }

        public async Task<TransactionInfo> GetTransactionByIdAsync(int TransactionId, CancellationToken Token = default)
		{
			var Parameters = new[]
			 {
			   new SqlParameter("@TransactionId", TransactionId)

			};
			await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

			await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "GetTransactionById", CommandType.StoredProcedure, Parameters);

			await using var DataReader = await Command.ExecuteReaderAsync(Token);
			return await DataReader.MapToObject<TransactionInfo>(Token);
		}

		public async Task UpdateTransactionAsync(UpdateTransaction Model, CancellationToken Token = default)
		{
			var Parameters = new[]
		   {
			   new SqlParameter("@TransactionId", Model.TransactionID),
			   new SqlParameter("@Comment", Model.Comment),

			};
			await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

			await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "UpdateTransaction", CommandType.StoredProcedure, Parameters);
			await Command.ExecuteReaderAsync(Token);
		}
	}
}
