using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Senele.Solution.Web.ViewModels.Transactions;
using Senele.Solution.ApplicationContractsLayer.Transactions;
using Senele.Solution.ApplicationContractsLayer.Transactions.DTO;

namespace Senele.Solution.Web.Pages.Transactions
{
    public class GetTransactionInfoModel : SolutionPageModel
	{
		[BindProperty]
		public TransactionInfoViewModel ObjectToDisplay { get; set; }

		private readonly ITransactionAppService _transactionAppService;
		public GetTransactionInfoModel(ITransactionAppService transactionAppServiceObj)
		{
			_transactionAppService = transactionAppServiceObj;

		}
		public async Task<IActionResult> OnGetAsync(int TransactionId)
		{
			try
			{
				var ReturnResult = await _transactionAppService.GetTransactionByIdAsync(TransactionId);
				ObjectToDisplay = ObjectMapper.Map<TransactionInfoDto, TransactionInfoViewModel>(ReturnResult);
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not retrive data, try again";
			}

			return Page();
		}
	}
}
