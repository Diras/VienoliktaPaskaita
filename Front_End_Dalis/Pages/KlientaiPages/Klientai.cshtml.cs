using AutomobiliuNuoma.Models;
using Front_End_Dalis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_End_Dalis.Pages.KlientaiPages
{
    public class KlientaiModel : PageModel
    {
        private readonly INuomaAPIService _nuomaAPIService;

        [BindProperty]
        public List<Klientas> Klientai { get; set; }


        public KlientaiModel(INuomaAPIService nuomaAPIService)
        {
            _nuomaAPIService = nuomaAPIService;
        }


        public void OnGet()
        {
            Klientai = _nuomaAPIService.GautiVisusKlientus();
        }
    }
}
