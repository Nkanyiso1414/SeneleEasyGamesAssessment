using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senele.Solution.ApplicationContractsLayer.Clients;
using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using Senele.Solution.Web.ViewModels.Clients;
using System;
using System.Threading.Tasks;

namespace Senele.Solution.Web.Pages.Clients
{
    public class CreateClientModel : SolutionPageModel
	{
		[BindProperty]
		public CreateClientViewModel ObjectToCreate { get; set; }

		private readonly IClientAppService _clientAppService;
		public CreateClientModel(IClientAppService clientAppServiceObj)
		{
			_clientAppService = clientAppServiceObj;

		}

		public void OnGet()
		{
		}
		public async Task<IActionResult> OnPostAsync()
		{

			if (!ModelState.IsValid)
			{

				return Page();
			}

			try
			{
				var DtoObject = ObjectMapper.Map<CreateClientViewModel, CreateClientDto>(ObjectToCreate);
				await _clientAppService.CreatClientAsync(DtoObject);

				return RedirectToPage("/Clients/Index");
			}
			catch(Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not create client, try again";
				return Page();
			}
			
			
			
		}
	}
}
