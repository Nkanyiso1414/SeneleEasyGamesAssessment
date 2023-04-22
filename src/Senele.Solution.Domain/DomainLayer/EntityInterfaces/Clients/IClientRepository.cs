using Senele.Solution.DomainLayer.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Senele.Solution.DomainLayer.EntityInterfaces.Clients
{
	public interface IClientRepository : IBasicRepository<IClient, int>
	{
		Task CreatClientAsync(CreateClient Model, CancellationToken Token = default);
		Task<ClientInfo> GetClientByIdAsync(int ClientId, CancellationToken Token = default);
		Task<IEnumerable<ClientInfo>> GetAllClientsAsync(CancellationToken Token = default);
		Task UpdateClientAsync(UpdateClient Model, CancellationToken Token = default);
	}
}
