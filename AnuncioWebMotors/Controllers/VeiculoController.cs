using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnuncioWebMotors.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnuncioWebMotors.Controllers
{
    public class VeiculoController : Controller
    {
        protected readonly IVeiculoService veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            this.veiculoService = veiculoService;

        }


        public IActionResult IncluirAnuncio()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListaMarcas()
        {
            var marcas = await veiculoService.GetMarcasAsync();
            return StatusCode(200, marcas);
        }

        [HttpGet]
        public async Task<IActionResult> GetListaModelos(int idMarca)
        {
            var modelos = await veiculoService.GetModelosAsync(idMarca);
            return StatusCode(200, modelos);
        }

        [HttpGet]
        public async Task<IActionResult> GetListaVersao(int idVersao)
        {
            var versoes = await veiculoService.GetVersaoAsync(idVersao);
            return StatusCode(200, versoes);
        }
    }
}