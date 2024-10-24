using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.models
{
    public class Manga
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal NumeroCapitulo { get; set; }
        public int AnoLancamento { get; set; }
        public string Autor { get; set; }
        public double Preco { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome} - Preco: {Preco}";
        }
    }
}
