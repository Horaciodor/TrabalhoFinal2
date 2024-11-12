using AutoMapper;
using Dapper.Contrib.Extensions;
using Filmax.Repositorio.Interface;
using FilMax.Entidade;
using FilMax.Services;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.Entity;
using System.Data.SQLite;

namespace FilMax.Repositorio
{
    public class MangaRepository : IMangaRepository
    {

        public readonly string ConnectionString;

        public MangaRepository(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        public void AdicionarManga(Mangas manga)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Mangas>(manga);

        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Mangas novoManga = BuscarManga(id);
            connection.Delete<Mangas>(novoManga);
        }
        public List<Mangas> Lista()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Mangas>().ToList();
        }
        public void Editar(Mangas m)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Mangas>(m);
        }

        public Mangas BuscarManga(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Mangas>(id);
        }
    }
}
