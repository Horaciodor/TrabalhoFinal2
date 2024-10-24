using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilMax.Entidade.DTO;

public class CarrinhoDTO
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; }
    public Mangas Manga { get; set; }

}
