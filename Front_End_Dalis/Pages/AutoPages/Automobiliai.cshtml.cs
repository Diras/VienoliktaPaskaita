using AutomobiliuNuoma.Models;
using Front_End_Dalis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_End_Dalis.Pages.AutoPages
{
    public class AutomobiliaiModel : PageModel
    {
        private readonly INuomaAPIService _nuomaAPIService;

        public Automobiliai Automobil { get; set; }

        public AutomobiliaiModel(INuomaAPIService nuomaAPIService)
        {
            _nuomaAPIService = nuomaAPIService;
        }

        public void OnGet()
        {

            Automobil = _nuomaAPIService.GautiVisusAutomobilius();
        }
    }
}