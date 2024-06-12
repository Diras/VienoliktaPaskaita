using Microsoft.AspNetCore.Mvc.RazorPages;
using Front_End_Dalis.Services;
using System.Collections.Generic;
using AutomobiliuNuoma.Models;
using Microsoft.AspNetCore.Mvc;

namespace Front_End_Dalis.Pages.AutoPages
{
    public class AutomobiliaiByTypeModel : PageModel
    {
        private readonly INuomaAPIService _nuomaAPIService;

        public AutomobiliaiByTypeModel(INuomaAPIService nuomaAPIService)
        {
            _nuomaAPIService = nuomaAPIService;
        }

        [BindProperty]
        public List<Elektromobilis> Elektromobiliai { get; set; }

        [BindProperty]
        public List<NaftosKuroAutomobilis> NaftosKuroAutomobiliai { get; set; }

        public void OnGet(string tipas)
        {
            if (!string.IsNullOrEmpty(tipas))
            {
                if (tipas == "Elektromobilis")
                {
                    Elektromobiliai = _nuomaAPIService.FiltruotiAutomobiliusPagalElektro(tipas);
                }
                else if (tipas == "NaftosKuroAutomobilis")
                {
                    NaftosKuroAutomobiliai = _nuomaAPIService.FiltruotiAutomobiliusPagalNaftos(tipas);
                }

            }
        }
    }
}