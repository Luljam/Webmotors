using AnuncioWebMotors.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuncioWebMotors.Repositories
{
    public interface IAnuncioRepository
    {
        public Task<Anuncio> BuscarAnuncioPorId(int? id);
        Task GravaAnuncioAsync(Anuncio anuncio);
        public Task<Anuncio> GetAnuncioPorId(int? id);
        Task<IEnumerable<Anuncio>> GetListaAnuncios();
        Task Atualizar(Anuncio anuncio);
        Task Excluir(Anuncio anuncio);
        bool Existe(int id);
    }
}
