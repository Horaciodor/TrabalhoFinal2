﻿using AutoMapper;
using Filmax.Aplicação;
using Filmax.Repositorio.Interface;
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

public class TsukiService : ITsukiService
{
    public IMangaRepository _repository { get; set; }

    public TsukiService(IMangaRepository mangaRepository)
    {
        _repository = mangaRepository;
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
