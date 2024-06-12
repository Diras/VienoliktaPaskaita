using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Models;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]

public class NuomaController : ControllerBase
{
    private readonly INuomaService _nuomaService;

    public NuomaController(INuomaService nuomaService)
    {
        _nuomaService = nuomaService;
    }


    [HttpGet("GetNuoma")]
    public List<Nuoma> GetNuomosSarasas()
    {
        List<Nuoma> nuoma = _nuomaService.GautiVisasNuomas().ToList();
        return nuoma;
    }

    [HttpGet("GautiNuomaPagalId")]
    public Nuoma GautiNuomaPagalId(int id)
    {
        Nuoma nuoma = _nuomaService.GautiNuomaPagalId(id);
        return nuoma;
    }

    [HttpPost("NuomotiAutomobili")]
    public void NuomotiAutomobili(Nuoma nuoma)
    {
        _nuomaService.NuomotiAutomobili(nuoma);
    }

    [HttpPatch("AtnaujintiNuoma")]
    public void AtnaujintiNuoma(int id, Nuoma nuoma)
    {
        _nuomaService.AtnaujintiNuoma(nuoma, id);
    }

    [HttpDelete("IstrintiNuoma")]
    public void IstrintiNuoma(int id)
    {
        _nuomaService.IstrintiNuoma(id);
    }


}



