using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Front_End_Dalis.Services;

namespace Front_End_Dalis.Pages.AutoPages
{
    public class AutomobiliaiDeleteModel : PageModel
    {
        private readonly INuomaAPIService _nuomaAPIService;

        public AutomobiliaiDeleteModel(INuomaAPIService nuomaAPIService)
        {
            _nuomaAPIService = nuomaAPIService;
        }

        [BindProperty]
        public int Id { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _nuomaAPIService.IstrintiAutomobili(Id);
            return RedirectToPage("/AutomobiliaiMenu");
        }
    }
}
