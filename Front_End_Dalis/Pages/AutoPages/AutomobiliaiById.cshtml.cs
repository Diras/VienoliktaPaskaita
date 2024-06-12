using Microsoft.AspNetCore.Mvc.RazorPages;
using Front_End_Dalis.Services;
using AutomobiliuNuoma.Models;
using Microsoft.AspNetCore.Mvc;

namespace Front_End_Dalis.Pages.AutoPages
{
    public class AutomobiliaiByIdModel : PageModel
    {
        private readonly INuomaAPIService _nuomaAPIService;

        public AutomobiliaiByIdModel(INuomaAPIService nuomaAPIService)
        {
            _nuomaAPIService = nuomaAPIService;
        }

        [BindProperty]
        public Automobilis Automobilis { get; set; }

        public void OnGet(int id)
        {
            Automobilis = _nuomaAPIService.GautiAutomobiliPagalId(id);
        }
    }
}
