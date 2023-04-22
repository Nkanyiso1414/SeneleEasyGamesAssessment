using Microsoft.Data.SqlClient;
using Senele.Solution.Configuration.CommandAndConnectionManager;
using Senele.Solution.DomainLayer.Entities.Clients;
using Senele.Solution.DomainLayer.EntityInterfaces.Clients;
using Senele.Solution.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Senele.Solution.RepositoriesLayer.Clients
{
	public class ClientRepository : EfCoreRepository<SolutionDbContext, IClient, int>, IClientRepository
	{
		public ClientRepository(IDbContextProvider<SolutionDbContext> DbContextProvider) : base(DbContextProvider)
		{
		}

		public async Task CreatClientAsync(CreateClient Model, CancellationToken Token = default)
		{
			var Parameters = new[]
		   {
		
			   new SqlParameter("@Name", Model.Name),
			   new SqlParameter("@Surname", Model.Surname),

			};
			await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

			await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "CreateClient", CommandType.StoredProcedure, Parameters);
			await Command.ExecuteReaderAsync(Token);
		}

		public async Task<IEnumerable<ClientInfo>> GetAllClientsAsync(CancellationToken Token = default)
		{
			await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

			await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "GetAllClients", CommandType.StoredProcedure);
			await using var DataReader = await Command.ExecuteReaderAsync(Token);
			return await DataReader.MapToList<ClientInfo>(Token);
		}

		public async Task<ClientInfo> GetClientByIdAsync(int ClientId, CancellationToken Token = default)
		{
			var Parameters = new[]
		   {
			   new SqlParameter("@ClientId", ClientId)

			};
			await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

			await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "GetClientById", CommandType.StoredProcedure, Parameters);

			await using var DataReader = await Command.ExecuteReaderAsync(Token);
			return await DataReader.MapToObject<ClientInfo>(Token);
		}

		public async Task UpdateClientAsync(UpdateClient Model, CancellationToken Token = default)
		{
			var Parameters = new[]
		   {
			   new SqlParameter("@ClientId", Model.ClientID),
			   new SqlParameter("@Name", Model.Name),
			   new SqlParameter("@Surname", Model.Surname),

			};
			await RepositoryCommandAndConnectionManager.EnsureConnectionOpenAsync(await GetDbContextAsync(), Token);

			await using var Command = RepositoryCommandAndConnectionManager.CreateCommand(await GetDbContextAsync(), "UpdateClient", CommandType.StoredProcedure, Parameters);
			await Command.ExecuteReaderAsync(Token);
		}
	}
}
