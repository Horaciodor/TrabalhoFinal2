using Filmax.Entidade.DTO;
using FilMax.Entidade;

namespace Filmax.Services.Interface;

public interface IClienteService
{
    void Adicionar(Cliente cliente);
    void Remover(int id);
    List<Cliente> Listar();
    Cliente BuscarTimePorId(int id);
    void Editar(Cliente editClien);
    Cliente FazerLogin(ClienteLonginDTO usuarioLogin);

}
