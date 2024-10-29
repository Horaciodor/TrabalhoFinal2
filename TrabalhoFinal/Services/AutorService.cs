﻿using F.Services.Interface;
using Filmax.Services.Interface;
using FilMax.Entidade;
using FilMax.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilMax.Services;

public class AutorService : IAutorService
{
    public AutorRepository repository { get; set; }
    public AutorService(string _config)
    {
        repository = new AutorRepository(_config);
    }
    public void Adicionar(Autor autor)
    {
        repository.Adicionar(autor);
    }
    public void Remover(int id)
    {
        repository.Remover(id);
    }
    public List<Autor> Listar()
    {
        return repository.Listar();
    }
    public void Editar(Autor editAutor)
    {
        repository.Editar(editAutor);
    }
}
