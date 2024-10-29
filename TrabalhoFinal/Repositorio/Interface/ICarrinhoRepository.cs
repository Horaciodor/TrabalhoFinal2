using FilMax.Entidade;
using FilMax.Entidade.DTO;

namespace Filmax.Repositorio.Interface;

public interface ICarrinhoRepository
{
    void Adicionar(Carrinho carrinho);
    void Remover(int id);
    void Editar(Carrinho carrinho);
    List<Carrinho> Listar();
    List<CarrinhoDTO> ListarCarrinhoDoUsuario(int usuarioId);
    Carrinho BuscarPorId(int id);
}
