using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome} - Email: {Email} - Senha: {Senha}";
        }
    }
}
