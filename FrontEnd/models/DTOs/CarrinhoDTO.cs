using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.models.DTOs
{
    public class CarrinhoDTO
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Manga Manga { get; set; }

        public override string ToString()
        {
            return $"Usuario {Cliente.Nome} - Produto : {Manga.Nome} - Preço: {Manga.Preco}";
        }
    }
}
