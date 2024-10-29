using FilMax.Entidade;

namespace Filmax.Repositorio.Interface;

public interface IAutorRepository
{
    void Adicionar(Autor autor);
    void Remover(int id);
    void Editar(Autor autor);
    List<Autor> Listar();
    Autor BuscarPorId(int id);

}
