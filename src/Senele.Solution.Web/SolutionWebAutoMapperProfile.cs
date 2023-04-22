using AutoMapper;
using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using Senele.Solution.ApplicationContractsLayer.Transactions.DTO;
using Senele.Solution.ApplicationContractsLayer.TransactionTypes.DTO;
using Senele.Solution.Web.ViewModels.Clients;
using Senele.Solution.Web.ViewModels.Transactions;
using Senele.Solution.Web.ViewModels.TransactionTypes;
using System.Collections.Generic;

namespace Senele.Solution.Web;
public class SolutionWebAutoMapperProfile : Profile
{
	public SolutionWebAutoMapperProfile()
	{
		CreateMap<CreateClientViewModel, CreateClientDto>();
		CreateMap<ClientInfoDto, ClientInfoViewModel>();
		CreateMap<UpdateClientViewModel, UpdateClientDto>();

		CreateMap<CreateTransactionViewModel, CreateTransactionDto>();
		CreateMap<TransactionInfoDto, TransactionInfoViewModel>();
		CreateMap<UpdateTransactionViewModel, UpdateTransactionDto>();
		
		CreateMap <TransactionTypeInfoDto,TransactionTypeInfoViewModel> ();
		CreateMap<ClientTransactionInfoDto, ClientTransactionInfoViewModel>();
	}
}
