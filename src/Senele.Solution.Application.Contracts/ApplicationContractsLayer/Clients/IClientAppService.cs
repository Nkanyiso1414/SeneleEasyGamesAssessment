using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Application.Services;
using Senele.Solution.ApplicationContractsLayer.Clients.DTO;

namespace Senele.Solution.ApplicationContractsLayer.Clients
{
	public interface IClientAppService : IApplicationService
	{
		Task CreatClientAsync(CreateClientDto Model);
		Task<ClientInfoDto> GetClientByIdAsync(int ClientId);
		Task<IEnumerable<ClientInfoDto>> GetAllClientsAsync();
		Task UpdateClientAsync(UpdateClientDto Model);
	}
}
