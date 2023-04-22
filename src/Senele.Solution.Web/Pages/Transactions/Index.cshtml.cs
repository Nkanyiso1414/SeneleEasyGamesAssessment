using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Senele.Solution.Web.ViewModels.Transactions;
using Senele.Solution.ApplicationContractsLayer.Transactions;
using Senele.Solution.ApplicationContractsLayer.Transactions.DTO;
using System.Collections;

namespace Senele.Solution.Web.Pages.Transactions
{
    public class IndexModel : SolutionPageModel
	{
		[BindProperty]
		public ClientTransactionInfoViewModel ObjectToDisplay { get; set; }

		private readonly ITransactionAppService _transactionAppService;

		public IndexModel(ITransactionAppService transactionAppServiceObj)
		{
			_transactionAppService = transactionAppServiceObj;

		}
		public async Task<IActionResult> OnGetAsync(int ClientId)
		{
			try
			{
				var ReturnResult = await _transactionAppService.GetTransactionByClientIdAsync(ClientId);
                ObjectToDisplay = ObjectMapper.Map<ClientTransactionInfoDto,ClientTransactionInfoViewModel> (ReturnResult);
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not retrive data, try again";
			}
			return Page();
		}
	}
}
