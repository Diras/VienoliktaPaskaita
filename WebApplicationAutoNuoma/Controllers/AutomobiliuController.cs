using Microsoft.AspNetCore.Mvc;
using AutomobiliuNuoma.Services;
using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Models;
using Serilog;
[ApiController]
[Route("api/[controller]")]
public class AutomobiliuController : ControllerBase
{
    private readonly INuomaService _nuomaService;
 

    public AutomobiliuController(INuomaService nuomaService)
    {
        _nuomaService = nuomaService;
    }

    [HttpGet("GetAutomobiliai")]
    public async Task<Automobiliai> GetAutomobiliuSarasas()
    {
        Log.Information("Uzklausa - gauti visus automobilius");
        try
        {
            List<Automobilis> automobiliai = (await _nuomaService.GautiVisusAutomobilius()).ToList();
            var elektromobiliai = automobiliai.OfType<Elektromobilis>().ToList();
            var naftosKuroAutomobiliai = automobiliai.OfType<NaftosKuroAutomobilis>().ToList();

            Log.Information("Automobiliai gauti sekmingai");
            return new Automobiliai
            {
                elektromobiliai = elektromobiliai,
                naftosKuroAutomobiliai = naftosKuroAutomobiliai
            };
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Klaida bandant gauti visus automobilius");
            throw;
        }
        

       
    }




    [HttpGet("GetAutoPagalTipa/{tipas}")]
    public List<Automobilis> FiltruotiAutomobiliusPagalTipa(string tipas)
    {
        Log.Information($"Uzklausa - gauti auto pagal tipa: {tipas}");
        try
        {
            List<Automobilis> automobiliuSarasas = _nuomaService.GautiAutomobiliusPagalTipa(tipas).ToList();

            Log.Information($"Gauti auto pagal tipa: {tipas}");
            return automobiliuSarasas;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Klaida bandant gauti automobili pagal tipa");
            throw;
        }
        
    }

    [HttpGet("GetAutoPagalId/{id}")]
    public IActionResult GetAutoPagalId(int id)
    {
        Log.Information($"Uzklausa - gauti auto pagal ID: {id}");
        try
        {
            Automobilis automobilis = _nuomaService.GautiAutomobiliPagalId(id);
            if (automobilis == null)
            {
                Log.Information($"Auto su ID: {id} nerastas.");
                return NotFound();
            }
            Log.Information($"Auto su ID: {id} sekmingai rastas");
            return Ok(automobilis);

        }
        catch (Exception ex)
        {
            Log.Error(ex, "Klaida bandant gauti automobili pagal ID");
            throw;
        }
       
    }

    [HttpPost("InsertElektromobilis")]
    public IActionResult InsertElektromobilis([FromForm] Elektromobilis automobilis)
    {
        Log.Information($"Uzklausa - elektromobilio registracija");
        try
        {
            _nuomaService.RegistruotiAutomobili(automobilis);
            Log.Information($"Elektromobilio registracija sekminga");
            return Ok(); // Grąžina statuso kodą 200 (OK)
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Klaida bandant registruoti elektromobili");
            throw;
        }
       
    }

    [HttpPost("InsertNaftosKuroAutomobilis")]
    public IActionResult InsertNaftosKuroAutomobilis([FromForm] NaftosKuroAutomobilis automobilis)
    {
        Log.Information($"Uzklausa - naftoskuroautomobilio registracija");
        try
        {
            _nuomaService.RegistruotiAutomobili(automobilis);
            Log.Information($"NaftoskuroAutomobilio registracija sekminga");
            return Ok(); // Grąžina statuso kodą 200 (OK)
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Klaida bandant registruoti naftoskuroautomobilio");
            throw;
        }
    }  

    [HttpPatch("AtnaujintiAutomobilisElektro/{id}")]
    public IActionResult AtnajintiAutomobilisElektro(int id, [FromBody] Elektromobilis automobilis)
    {
        Log.Information("Uzklausa - atnaujinti elektromobili");
        try
        {
            _nuomaService.AtnaujintiAutomobilioInformacija(automobilis, id);
            return Ok();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Klaida vykdant elektromobilio atnaujinima");
            throw;
        }
    }

    [HttpPatch("AtnaujintiAutomobilisNaftos/{id}")]
    public IActionResult AtnajintiAutomobilisNaftos(int id, [FromBody] NaftosKuroAutomobilis automobilis)
    {
        Log.Information("Uzklausa - atnaujinti naftoskuroautomobili");
        try
        {
            _nuomaService.AtnaujintiAutomobilioInformacija(automobilis, id);
            return Ok();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Klaida vykdant naftoskuroautomobilio atnaujinima");
            throw;
        }
       
    }

    [HttpDelete("DeleteAutomobilis")]
    public void DeleteAutomobilis(int id)
    {
        _nuomaService.IstrintiAutomobili(id);
    }

    [HttpGet("GetAutoPagalPavadinima/{pavadinimas}")]
    public async Task<IActionResult> FiltruotiAutomobiliusPagalPavadinima(string pavadinimas)
    {
        Log.Information($"Uzklausa - auto filtravimas pagal pavadinima");
        try
        {
            Automobiliai automobiliai = await _nuomaService.GautiAutomobiliusPagalPavadinimaAsync(pavadinimas);
            Log.Information($"Automobiliu filtravimas pagal pavadinima sekmingas");
            return Ok(automobiliai);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Klaida bandant filtruoti automobilius pagal pavadinima");
            throw;
        }
        
    }
}
