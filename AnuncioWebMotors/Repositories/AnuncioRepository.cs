using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnuncioWebMotors.Data;
using AnuncioWebMotors.Models;
using Microsoft.EntityFrameworkCore;

namespace AnuncioWebMotors.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly AnuncioContext _context;
        public AnuncioRepository(AnuncioContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Anuncio anuncio)
        {
            _context.Update(anuncio);
            await _context.SaveChangesAsync();
        }

        public async Task<Anuncio> BuscarAnuncioPorId(int? id)
        {
            var anuncios = await _context.tb_AnuncioWebmotors
                .FirstOrDefaultAsync(a => a.ID == id);
            return anuncios;
        }

        public async Task Excluir(Anuncio anuncio)
        {
            _context.tb_AnuncioWebmotors.Remove(anuncio);
            await _context.SaveChangesAsync();
        }

        public bool Existe(int id)
        {
            return _context.tb_AnuncioWebmotors.Any(e => e.ID == id);
        }

        public async Task<Anuncio> GetAnuncioPorId(int? id)
        {
            var anuncio = await _context.tb_AnuncioWebmotors
                .FirstOrDefaultAsync(m => m.ID == id);
            return anuncio;
        }

        public async Task<IEnumerable<Anuncio>> GetListaAnuncios()
        {
            var lista = await _context.tb_AnuncioWebmotors.ToListAsync();
           return lista;
        }

        public async Task GravaAnuncioAsync(Anuncio anuncio)
        {
            if (anuncio.Versao.Length >= 45)
            {
                anuncio.Versao = anuncio.Versao.Substring(0, 45);
            }

            _context.Add(anuncio);
            await _context.SaveChangesAsync();
        }
    }
}