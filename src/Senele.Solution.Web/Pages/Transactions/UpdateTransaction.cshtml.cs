using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Senele.Solution.Web.ViewModels.Transactions;
using Senele.Solution.ApplicationContractsLayer.Transactions;
using Senele.Solution.AppServiceLayer.Transactions;
using Senele.Solution.ApplicationContractsLayer.Transactions.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Senele.Solution.Web.Pages.Transactions
{
    public class UpdateTransactionModel : SolutionPageModel
	{
		[BindProperty]
		public UpdateTransactionViewModel ObjectToUpdate { get; set; }

		private readonly ITransactionAppService _transactionAppService;
		public UpdateTransactionModel(ITransactionAppService transactionAppServiceObj)
		{
			_transactionAppService = transactionAppServiceObj;

		}
		public async Task<IActionResult> OnGetAsync(int TransactionId,int ClientId)
		{
			try
			{
				var ReturnResult = await _transactionAppService.GetTransactionByIdAsync(TransactionId);

				ObjectToUpdate = new UpdateTransactionViewModel
				{
					Comment= ReturnResult.Comment,
					TransactionID=TransactionId,
					Surname= ReturnResult.Surname,
					Name= ReturnResult.Name,
					TransactionTypeName= ReturnResult.TransactionTypeName,
					Amount= ReturnResult.Amount,
					ClientId = ReturnResult.ClientID
				};
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not retrive data, try again";
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			

			try
			{
				var DtoObject = ObjectMapper.Map<UpdateTransactionViewModel, UpdateTransactionDto>(ObjectToUpdate);
				await _transactionAppService.UpdateTransactionAsync(DtoObject);

				return RedirectToPage("/Transactions/Index", new { ClientId = ObjectToUpdate.ClientId });
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not update transaction, try again";
				return Page();
			}



		}
	}
}
