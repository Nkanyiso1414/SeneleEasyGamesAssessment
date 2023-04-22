using Senele.Solution.ApplicationContractsLayer.Clients;
using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using Senele.Solution.DomainLayer.Entities.Clients;
using Senele.Solution.DomainLayer.EntityInterfaces.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Senele.Solution.AppServiceLayer.Clients
{
	public class ClientAppService : SolutionAppService, IClientAppService
	{
		private readonly IClientRepository _clientRepository;
		public ClientAppService(IClientRepository clientRepositoryObj)
		{
			_clientRepository= clientRepositoryObj;
		}

		public async Task CreatClientAsync(CreateClientDto Model)
		{
			var DbModel = ObjectMapper.Map<CreateClientDto, CreateClient>(Model);
			await _clientRepository.CreatClientAsync(DbModel);
			
		}

		public async Task<IEnumerable<ClientInfoDto>> GetAllClientsAsync()
		{
			var ReturnResult = await _clientRepository.GetAllClientsAsync();
			return ObjectMapper.Map<IEnumerable<ClientInfo>, IEnumerable<ClientInfoDto>>(ReturnResult);
		}

		public async Task<ClientInfoDto> GetClientByIdAsync(int ClientId)
		{
			var ReturnResult = await _clientRepository.GetClientByIdAsync(ClientId);
			return ObjectMapper.Map < ClientInfo,  ClientInfoDto > (ReturnResult);
		}

		public async Task UpdateClientAsync(UpdateClientDto Model)
		{
			var DbModel = ObjectMapper.Map<UpdateClientDto, UpdateClient>(Model);
			await _clientRepository.UpdateClientAsync(DbModel);
		}
	}
}
