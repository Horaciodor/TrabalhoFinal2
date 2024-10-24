using FrontEnd.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.useCases
{
    public class MangaUC
    {
        private readonly HttpClient _client;
        public MangaUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Manga> ListarManga()
        {
            return _client.GetFromJsonAsync<List<Manga>>("Produto/listar-produto").Result;
        }
        public void CadastrarProduto(Manga manga)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Produto/adicionar-produto", manga).Result;
        }
    }
}
