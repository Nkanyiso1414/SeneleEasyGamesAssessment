using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using Senele.Solution.ApplicationContractsLayer.Clients;
using Senele.Solution.Web.ViewModels.Clients;
using System.Threading.Tasks;
using System;
using Senele.Solution.Web.ViewModels.Transactions;
using Senele.Solution.ApplicationContractsLayer.Transactions;
using Senele.Solution.AppServiceLayer.Transactions;
using Senele.Solution.ApplicationContractsLayer.Transactions.DTO;
using System.Collections.Generic;
using Senele.Solution.DomainLayer.Entities.Clients;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Senele.Solution.Web.Pages.Transactions
{
    public class CreateTransactionModel : SolutionPageModel
	{
		[BindProperty]
		public CreateTransactionViewModel ObjectToCreate { get; set; }
        [BindProperty]
        public ClientInfoViewModel ObjectToDisplay { get; set; }

        private readonly ITransactionAppService _transactionAppService;
        private readonly IClientAppService _clientAppService;
        public CreateTransactionModel(ITransactionAppService transactionAppServiceObj, IClientAppService clientAppServiceObj)
		{
			_transactionAppService = transactionAppServiceObj;
			_clientAppService= clientAppServiceObj;
		}

        public async Task<IActionResult> OnGetAsync(int ClientId)
        {
            try
            {
                var ReturnResult = 	await _clientAppService.GetClientByIdAsync(ClientId);
                ObjectToDisplay = ObjectMapper.Map<ClientInfoDto, ClientInfoViewModel>(ReturnResult);

				ObjectToCreate = new CreateTransactionViewModel
				{
					ClientID= ClientId,
				};
            }
            catch (Exception e)
            {
                ViewData["Error"] = "Error: something went wrong, try again";
               
            }
            return Page();
        }
		public async Task<IActionResult> OnPostAsync()
		{

			if (ObjectToCreate.TransactionTypeID == null || (ObjectToCreate.Amount == 0 || ObjectToCreate.Amount <=0))
			{
				if(ObjectToCreate.Amount <= 0)
				{
                    ViewData["Error"] = "Error: amount must be greate than zero";
                }
				return Page();
			}

			try
			{
				var DtoObject = ObjectMapper.Map<CreateTransactionViewModel, CreateTransactionDto>(ObjectToCreate);
				await _transactionAppService.CreatTransactionAsync(DtoObject);

				return RedirectToPage("/Transactions/Index", new { ClientId = ObjectToCreate.ClientID});
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not create transaction, try again";
				return Page();
			}



		}
	}
}
