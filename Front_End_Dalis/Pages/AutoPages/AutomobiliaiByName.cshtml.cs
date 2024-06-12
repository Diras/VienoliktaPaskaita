using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Front_End_Dalis.Services;
using AutomobiliuNuoma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Front_End_Dalis.Pages.AutoPages
{
    public class AutomobiliaiByNameModel : PageModel
    {
        private readonly INuomaAPIService _nuomaAPIService;

        public AutomobiliaiByNameModel(INuomaAPIService nuomaAPIService)
        {
            _nuomaAPIService = nuomaAPIService;
        }

        [BindProperty(SupportsGet = true)]
        public string Pavadinimas { get; set; }

        public Automobiliai Automobiliai { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Pavadinimas))
            {
                Automobiliai = await _nuomaAPIService.GautiAutomobiliusPagalPavadinimaAsync(Pavadinimas);
            }
        }
    }
}
