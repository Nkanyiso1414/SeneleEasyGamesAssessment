using AutoMapper;
using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using Senele.Solution.ApplicationContractsLayer.Transactions.DTO;
using Senele.Solution.ApplicationContractsLayer.TransactionTypes.DTO;
using Senele.Solution.DomainLayer.Entities.Clients;
using Senele.Solution.DomainLayer.Entities.Transactions;
using Senele.Solution.DomainLayer.Entities.TransactionTypes;
using System.Collections.Generic;

namespace Senele.Solution;

public class SolutionApplicationAutoMapperProfile : Profile
{
    public SolutionApplicationAutoMapperProfile()
    {
        CreateMap<CreateClientDto, CreateClient>();
        CreateMap<ClientInfo, ClientInfoDto>();
        CreateMap<UpdateClientDto, UpdateClient>();

		CreateMap<CreateTransactionDto, CreateTransaction>();
		CreateMap<TransactionInfo, TransactionInfoDto>();
        CreateMap<UpdateTransactionDto, UpdateTransaction>();

        CreateMap<TransactionTypeInfo, TransactionTypeInfoDto>();
        CreateMap<ClientTransactionInfo, ClientTransactionInfoDto>();

	}
}
