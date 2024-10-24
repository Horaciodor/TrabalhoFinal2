using FrontEnd.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.useCases
{
    public class EnderecoUC
    {
        private readonly HttpClient _client;
        public EnderecoUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Endereco> ListarEnderecosDoUsuario(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<Endereco>>("Endereco/listar-endereco-usuario?usuarioId=" + usuarioId).Result;
        }
        public Endereco CadastrarEndereco(Endereco endereco)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Endereco/adicionar-endereco", endereco).Result;

            Endereco enderecoCadastrado = response.Content.ReadFromJsonAsync<Cliente>().Result;
            return enderecoCadastrado;
        }
    }
}
