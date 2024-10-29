using FilMax.Entidade;

namespace Filmax.Services.Interface;

public interface IAutorService
{
    void Adicionar(Autor autor);
    void Remover(int id);
    List<Autor> Listar();
    void Editar(Autor editAutor);

}
