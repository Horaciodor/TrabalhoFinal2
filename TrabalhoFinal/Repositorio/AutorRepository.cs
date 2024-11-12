using Dapper.Contrib.Extensions;
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

public class AutorRepository : IAutorRepository
{
    private readonly string ConnectionString;
    public AutorRepository(IConfiguration config)
    {
        ConnectionString = config.GetConnectionString("DefaultConnection");
    }
    public void Adicionar(Autor autor)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Autor>(autor);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Autor autor = BuscarPorId(id);
        connection.Delete<Autor>(autor);
    }
    public void Editar(Autor autor)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Autor>(autor);
    }
    public List<Autor> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Autor>().ToList();
    }
    public Autor BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Autor>(id);
    }
}
