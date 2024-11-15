﻿using Dapper.Contrib.Extensions;
using Filmax.Entidade.DTO;
using Filmax.Repositorio.Interface;
using FilMax.Entidade;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilMax.Repositorio;

public class ClienteRepository : IClienteRepository
{
    private readonly string ConnectionString;
    public ClienteRepository(IConfiguration config)
    {
        ConnectionString = config.GetConnectionString("DefaultConnection");
    }
    public void Adicionar(Cliente cliente)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Cliente>(cliente);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Cliente cliente = BuscarPorId(id);
        connection.Delete<Cliente>(cliente);
    }
    public void Editar(Cliente cli)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Cliente>(cli);
    }
    public List<Cliente> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Cliente>().ToList();
    }
    public Cliente BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Cliente>(id);
    }
    public Cliente FazerLogin(ClienteLonginDTO ClienteLogin)
    {
        List<Cliente> listUsuario = Listar();
        foreach (Cliente usuario in listUsuario)
        {
            if (usuario.Apelido == ClienteLogin.Apelido
                && usuario.Senha == ClienteLogin.Senha)
            {
                return usuario;
            }
        }
        return null;
    }
}
