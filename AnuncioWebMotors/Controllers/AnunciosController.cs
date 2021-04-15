using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnuncioWebMotors.Data;
using AnuncioWebMotors.Models;
using AnuncioWebMotors.Repositories;

namespace AnuncioWebMotors.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly AnuncioContext _context;
        private readonly IAnuncioRepository _anuncioRepository;

        public AnunciosController(AnuncioContext context, IAnuncioRepository anuncioRepository)
        {
            _context = context;
            _anuncioRepository = anuncioRepository;
        }


        public async Task<IActionResult> Index()
        {
            var anuncios = await _anuncioRepository.GetListaAnuncios();
            return View(anuncios);
        }
        // GET: Anuncios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _anuncioRepository.GetAnuncioPorId(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // GET: Anuncios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                await _anuncioRepository.GravaAnuncioAsync(anuncio);
                return RedirectToAction(nameof(Index));
            };
            return View(anuncio);
        }

        // GET: Anuncios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _anuncioRepository.GetAnuncioPorId(id);
            if (anuncio == null)
            {
                return NotFound();
            }
            return View(anuncio);
        }

        // POST: Anuncios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] Anuncio anuncio)
        {
            if (id != anuncio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _anuncioRepository.Atualizar(anuncio);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuncioExists(anuncio.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(anuncio);
        }

        // GET: Anuncios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _anuncioRepository.BuscarAnuncioPorId(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anuncio = await _anuncioRepository.GetAnuncioPorId(id);
            await _anuncioRepository.Excluir(anuncio);
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioExists(int id)
        {
            return _anuncioRepository.Existe(id);
        }
    }
}
