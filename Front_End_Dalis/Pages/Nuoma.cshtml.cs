using AutomobiliuNuoma.Models;
using Front_End_Dalis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_End_Dalis.Pages
{
    public class NuomaModel : PageModel
    {
		private readonly INuomaAPIService _nuomaAPIService;

		[BindProperty]
		public List<Nuoma> Nuoma { get; set; }


		public NuomaModel(INuomaAPIService nuomaAPIService)
		{
			_nuomaAPIService = nuomaAPIService;
		}


		public void OnGet()
		{
			Nuoma = _nuomaAPIService.GautiVisasNuomas();
		}
	}
}
