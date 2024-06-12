using Microsoft.AspNetCore.Mvc;
using AutomobiliuNuoma.Services;
using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Models;

[ApiController]
[Route("api/[controller]")]


public class KlientaiController : ControllerBase
{
    private readonly INuomaService _nuomaService;

    public KlientaiController(INuomaService nuomaService)
    {
        _nuomaService = nuomaService;
    }

    [HttpGet("GetKlientai")]
    public List<Klientas> GetKlientuSarasas()
    {
        List<Klientas> klientai = _nuomaService.GautiVisusKlientus().ToList();
        return klientai;
    }

    [HttpGet("GetKlientaiPagalPavadinima/{pavadinimas}")]
    public async Task<ActionResult<List<Klientas>>> GetKlientaiPagalPavadinima(string pavadinimas)
    {
        var klientai = await _nuomaService.GautiVisusKlientusPagalPavadinima(pavadinimas);
        return Ok(klientai);
    }

    [HttpGet("GetKlientaPagalId")]
    public Klientas GetKlientasPagalId(int id)
    {
        Klientas klientas = _nuomaService.GautiKlientaPagalId(id);
        return klientas;
    }

    [HttpPost("PridetiKlienta")]
    public void PridetiKlienta(Klientas klientas)
    {
        _nuomaService.PridetiKlienta(klientas);
    }

    [HttpPatch("AtnaujintiKlienta")]
    public void AtnaujintiKlienta(int id, Klientas klientas)
    {
        _nuomaService.AtnaujintiKlienta(klientas, id);
    }

    [HttpDelete("IstrintiKlienta")]
    public void IstrintiKlienta(int id)
    {
        _nuomaService.IstrintiKlienta(id);
    }
    

}

