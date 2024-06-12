using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Front_End_Dalis.Services;
using AutomobiliuNuoma.Models;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

namespace Front_End_Dalis.Pages.AutoPages
{
    public class AutomobiliaiUpdateModel : PageModel
    {
        private readonly INuomaAPIService _nuomaAPIService;

        public AutomobiliaiUpdateModel(INuomaAPIService nuomaAPIService)
        {
            _nuomaAPIService = nuomaAPIService;
        }

        [BindProperty]
        public Elektromobilis Elektro { get; set; }

        [BindProperty]
        public NaftosKuroAutomobilis Naftos { get; set; }



        public async Task<IActionResult> OnPost(int id)
        {
            string apiUrl = "";

            // Patikriname, koks automobilio tipas ir nustatome API URL
            if (Elektro.BaterijosTalpa != 0)
            {
                _nuomaAPIService.AtnaujintiElektromobili(id, Elektro);
                return Redirect("/AutoPages/AutomobiliaiMenuModel/AutomobiliaiMenuModel");

            }
            else if (Naftos.BakoTalpa != 0)
            {
                _nuomaAPIService.AtnaujintiNaftosKuroAutomobili(id, Naftos);
                return Redirect("/AutoPages/AutomobiliaiMenuModel/AutomobiliaiMenuModel");
            }
            else
            {
                return BadRequest("Automobilio tipas nerastas.");
            }

            
            
        }
    }
}
