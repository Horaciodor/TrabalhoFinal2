using FilMax.Entidade;

namespace Filmax.Aplicação;

public interface ITsukiService
{
    void Adicionar(Mangas manga);
    void Remover(int id);
    List<Mangas> Listar();
    void Editar(Mangas m);
}
