using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senele.Solution.ApplicationContractsLayer.Clients;
using Senele.Solution.ApplicationContractsLayer.Clients.DTO;
using Senele.Solution.AppServiceLayer.Clients;
using Senele.Solution.DomainLayer.Entities.Clients;
using Senele.Solution.Web.ViewModels.Clients;
using System;
using System.Threading.Tasks;

namespace Senele.Solution.Web.Pages.Clients
{
    public class UpdateClientModel : SolutionPageModel
	{
		[BindProperty]
		public UpdateClientViewModel ObjectToUpdate { get; set; }

		private readonly IClientAppService _clientAppService;
		public UpdateClientModel(IClientAppService clientAppServiceObj)
		{
			_clientAppService = clientAppServiceObj;

		}
		public async Task<IActionResult> OnGetAsync(int ClientId)
		{
			try
			{
				var ReturnResult = await _clientAppService.GetClientByIdAsync(ClientId); 

				ObjectToUpdate = new UpdateClientViewModel
				{
					ClientBalance = ReturnResult.ClientBalance,
					ClientID = ReturnResult.ClientID,
					Name = ReturnResult.Name,
					Surname = ReturnResult.Surname,

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

			if (!ModelState.IsValid)
			{

				return Page();
			}

			try
			{
				var DtoObject = ObjectMapper.Map<UpdateClientViewModel, UpdateClientDto>(ObjectToUpdate);
				await _clientAppService.UpdateClientAsync(DtoObject);

				return RedirectToPage("/Clients/GetClientInfo", new { ClientId = ObjectToUpdate.ClientID });
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error: something went wrong, we could not update client, try again";
				return Page();
			}



		}
	}
}
