using Filmax.Entidade.DTO;
using FrontEnd.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.useCases
{
    public class ClienteUC
    {
        private readonly HttpClient _client;
        public ClienteUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public List<Cliente> Listar()
        {
            return _client.GetFromJsonAsync<List<Cliente>>("Usuario/listar-usuario").Result;
        }
        public void CadastrarUsuario(Cliente usuario)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Usuario/adicionar-usuario", usuario).Result;
        }
        public Cliente FazerLogin(ClienteLonginDTO usuLogin)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Usuario/fazer-login", usuLogin).Result;
            Cliente usuario = response.Content.ReadFromJsonAsync<Cliente>().Result;
            return usuario;
        }
    }
}
