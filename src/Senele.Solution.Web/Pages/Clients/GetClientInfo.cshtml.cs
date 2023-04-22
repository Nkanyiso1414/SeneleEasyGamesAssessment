using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senele.Solution.ApplicationContractsLayer.Clients;
using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using Senele.Solution.Web.ViewModels.Clients;
using System;
using System.Threading.Tasks;

namespace Senele.Solution.Web.Pages.Clients
{
    public class GetClientInfoModel : SolutionPageModel
	{
		[BindProperty]
		public ClientInfoViewModel ObjectToDisplay { get; set; }

		private readonly IClientAppService _clientAppService;
		public GetClientInfoModel(IClientAppService clientAppServiceObj)
		{
			_clientAppService= clientAppServiceObj;

		}
		public async Task<IActionResult> OnGetAsync(int ClientId)
		{
			try
			{
				var ReturnResult = await _clientAppService.GetClientByIdAsync(ClientId);
				ObjectToDisplay = ObjectMapper.Map<ClientInfoDto, ClientInfoViewModel>(ReturnResult);
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not retrive data, try again";
			}
			
			return Page();
		}
	}
}
