using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senele.Solution.ApplicationContractsLayer.Clients;
using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using Senele.Solution.Web.ViewModels.Clients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senele.Solution.Web.Pages.Clients
{
    public class IndexModel : SolutionPageModel
	{
		[BindProperty]
		public IEnumerable<ClientInfoViewModel> ObjectToList { get; set; }

		private readonly IClientAppService _clientAppService;
		
		public IndexModel(IClientAppService clientAppServiceObj)
		{
			_clientAppService = clientAppServiceObj;

		}
		public async Task<IActionResult> OnGetAsync()
		{
			try
			{
				var ReturnResult = await _clientAppService.GetAllClientsAsync();
				ObjectToList = ObjectMapper.Map<IEnumerable<ClientInfoDto>, IEnumerable<ClientInfoViewModel>>(ReturnResult);
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not retrive data, try again";
			}
			return Page();
		}
	}
}
