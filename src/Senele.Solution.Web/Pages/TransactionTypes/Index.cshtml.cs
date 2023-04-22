using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Senele.Solution.Web.ViewModels.TransactionTypes;
using Senele.Solution.ApplicationContractsLayer.TransactionTypes;
using Senele.Solution.ApplicationContractsLayer.TransactionTypes.DTO;

namespace Senele.Solution.Web.Pages.TransactionTypes
{
    public class IndexModel : SolutionPageModel
	{
		[BindProperty]
		public IEnumerable<TransactionTypeInfoViewModel> ObjectToList { get; set; }

		private readonly ITransactionTypeAppService _transactionTypeAppService;

		public IndexModel(ITransactionTypeAppService transactionTypeAppServiceObj)
		{
			_transactionTypeAppService = transactionTypeAppServiceObj;

		}
		public async Task<IActionResult> OnGetAsync()
		{
			try
			{
				var ReturnResult = await _transactionTypeAppService.GetAllTransactionTypesAsync();
				ObjectToList = ObjectMapper.Map<IEnumerable<TransactionTypeInfoDto>, IEnumerable<TransactionTypeInfoViewModel>>(ReturnResult);
               
            }
			catch (Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not retrive data, try again";
			}
			return Page();
		}
	}
}
