using AnuncioWebMotors.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnuncioWebMotors.Repositories
{
    public class VeiculoService : IVeiculoService
    {
        protected readonly HttpClient httpClient;

        public VeiculoService()
        {
            httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Modelo>> GetModelosAsync(int marcaId)
        {
            try
            {
                var uri = new Uri("http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID=" + marcaId);
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var modelos = JsonConvert.DeserializeObject<IEnumerable<Modelo>>(result);

                    if (modelos != null && modelos.Count() > 0)
                    {
                        return modelos;
                    }
                    throw new Exception("Nenhum modelo foi encontrado.");
                  
                }
                else
                {
                    throw new Exception("Não foi possível buscar os modelos.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar as modelos disponíveis na WebMotors.", ex);
            }

        }

        public async Task<IEnumerable<Marca>> GetMarcasAsync()
        {
            try
            {
                var uri = new Uri("http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make");

                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var marcas = JsonConvert.DeserializeObject<IEnumerable<Marca>>(result);

                    if (marcas != null && marcas.Count() > 0)
                    {
                        return marcas;
                    }

                    throw new Exception("Nenhum marcas foi encontrado.");
                }
                else
                {
                    throw new Exception("Não foi possível marcas os carros.");
                }
            }
           
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar as marcas disponíveis na WebMotors.", ex);
            }
        }

        public async Task<IEnumerable<Versao>> GetVersaoAsync(int idMarca)
        {
            try
            {
                var uri = new Uri("http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID="+ idMarca);

                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var versoes = JsonConvert.DeserializeObject<IEnumerable<Versao>>(result);

                    if (versoes != null && versoes.Count() > 0)
                    {
                        return versoes;
                    }

                    throw new Exception("Nenhuma versão foi encontrado.");
                }
                else
                {
                    throw new Exception("Não foi possível buscar versões.");
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar as versões disponíveis na WebMotors.", ex);
            }
        }
    }
}
