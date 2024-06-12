using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobiliuNuoma.Models;
using Front_End_Dalis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_End_Dalis.Pages.KlientaiPages
{
    public class KlientaiByNameModel : PageModel
    {
        private readonly INuomaAPIService _nuomaAPIService;

        public KlientaiByNameModel(INuomaAPIService nuomaAPIService)
        {
            _nuomaAPIService = nuomaAPIService;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public List<Klientas> Klientai { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                Klientai = await _nuomaAPIService.GautiKlientusPagalPavadinima(Name);
            }
        }
    }
}
