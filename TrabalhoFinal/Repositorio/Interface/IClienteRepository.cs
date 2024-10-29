using Filmax.Entidade.DTO;
using FilMax.Entidade;

namespace Filmax.Repositorio.Interface;

public interface IClienteRepository
{
    void Adicionar(Cliente cliente);
    void Remover(int id);
    void Editar(Cliente cli);
    List<Cliente> Listar();
    Cliente BuscarPorId(int id);
    Cliente FazerLogin(ClienteLonginDTO ClienteLogin);

}
