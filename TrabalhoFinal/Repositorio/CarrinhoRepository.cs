using Dapper;
using Dapper.Contrib.Extensions;
using Filmax.Repositorio.Interface;
using FilMax.Entidade;
using FilMax.Entidade.DTO;
using FilMax.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmax.Repositorio;

public class CarrinhoRepository : ICarrinhoRepository
{
    private readonly string ConnectionString;
    private readonly IMangaRepository _repositoryManga;
    private readonly IClienteRepository _repositoryCliente;
    public CarrinhoRepository(string connectionString)
    {
        ConnectionString = connectionString;
        _repositoryManga = new MangaRepository(connectionString);
        _repositoryCliente = new ClienteRepository(connectionString);
    }
    public void Adicionar(Carrinho carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Carrinho>(carrinho);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Carrinho carrinho = BuscarPorId(id);
        connection.Delete<Carrinho>(carrinho);
    }
    public void Editar(Carrinho carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Carrinho>(carrinho);
    }
    public List<Carrinho> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Carrinho> list = connection.GetAll<Carrinho>().ToList();
        //TransformarListaCarrinhoEmCarrinhoDTO();
        return list;
    }
    private List<CarrinhoDTO> TransformarListaCarrinhoEmCarrinhoDTO(List<Carrinho> list)
    {
        List<CarrinhoDTO> listDTO = new List<CarrinhoDTO>();

        foreach (Carrinho car in list)
        {
            CarrinhoDTO readCarrinho = new CarrinhoDTO();
            readCarrinho.Manga = _repositoryManga.BuscarManga(car.MangasId);
            readCarrinho.Cliente = _repositoryCliente.BuscarPorId(car.ClienteId);
            listDTO.Add(readCarrinho);
        }
        return listDTO;
    }
    public List<CarrinhoDTO> ListarCarrinhoDoUsuario(int usuarioId)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Carrinho> list = connection.Query<Carrinho>($"SELECT Id, UsuarioId, ProdutoId FROM Carrinhos WHERE UsuarioId = {usuarioId}").ToList();
        List<CarrinhoDTO> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
        return listDTO;
    }
    public Carrinho BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Carrinho>(id);
    }
}
