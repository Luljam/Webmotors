using AnuncioWebMotors.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuncioWebMotors.Repositories
{
    public interface IVeiculoService
    {
        Task<IEnumerable<Marca>> GetMarcasAsync();
        Task<IEnumerable<Modelo>> GetModelosAsync(int idMarca);
        Task<IEnumerable<Versao>> GetVersaoAsync(int idMarca);
    }
}
