using FrontEnd.models;
using FrontEnd.models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.useCases
{
    public class CarrinhoUC
    {
        private readonly HttpClient _client;
        public CarrinhoUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public void CadastrarCarrinho(Carrinho carrinho)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Carrinho/adicionar-carrinho", carrinho).Result;
        }
        public List<CarrinhoDTO> ListarCarrinhoUsuarioLogado(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<CarrinhoDTO>>("Carrinho/listar-carrinho-do-usuario?usuarioId=" + usuarioId).Result;
        }
    }
}
