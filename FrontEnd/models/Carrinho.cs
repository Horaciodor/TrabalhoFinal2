using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int MangaId { get; set; }
    }
}
