using Microsoft.AspNetCore.Mvc;
using AutomobiliuNuoma.Services;
using AutomobiliuNuoma.Models;
using System.Collections.Generic;
using AutomobiliuNuoma.Contracts;

namespace AutomobiliuNuoma.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutomobiliaiController : ControllerBase
    {
        private readonly INuomaService _nuomaService;

        public AutomobiliaiController(INuomaService nuomaService)
        {
            _nuomaService = nuomaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Automobilis>> GetAutomobiliai()
        {
            var automobiliai = _nuomaService.GautiVisusAutomobilius();
            return Ok(automobiliai);
        }
    }
}