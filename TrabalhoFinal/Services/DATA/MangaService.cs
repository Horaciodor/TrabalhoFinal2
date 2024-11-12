using FilMax.Entidade;
using FilMax.Repositorio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DATA;

public class MangaService
{
    public MangaRepository repository { get; set; }
    public MangaService(IConfiguration _config)
    {
        repository = new MangaRepository(_config);
    }
    public void Adicionar(Mangas manga)
    {
        repository.AdicionarManga(manga);
    }
    public void Remover(int id)
    {
        repository.Remover(id);
    }
    public List<Mangas> Listar()
    {
        return repository.Lista();
    }
    public void Editar(Mangas m)
    {
        repository.Editar(m);
    }
    public Mangas BuscarManga(int id)
    {
        return repository.BuscarManga(id);
    }
}
