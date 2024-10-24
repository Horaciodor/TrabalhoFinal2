using AutoMapper;
using FilMax.Entidade;
using FilMax.Repositorio;
using FilMax.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilMax.Aplicação;

public class TsukiService
{
    public MangaRepository _repository { get; set; }

    public TsukiService(string _config)
    {
        _repository = new MangaRepository(_config);
    }

    public void Adicionar(Mangas manga)
    {
        _repository.AdicionarManga(manga);
    }

    public void Remover(int id)
    {
        _repository.Remover(id);
    }

    public List<Mangas> Listar()
    {
        return _repository.Lista();
    }

    public void Editar(Mangas m)
    {
        _repository.Editar(m);
    }
}  
