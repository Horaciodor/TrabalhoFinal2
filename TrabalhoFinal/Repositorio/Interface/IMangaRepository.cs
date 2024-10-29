using FilMax.Entidade;

namespace Filmax.Repositorio.Interface;

public interface IMangaRepository
{
    void AdicionarManga(Mangas manga);
    void Remover(int id);
    List<Mangas> Lista();
    void Editar(Mangas m);
    Mangas BuscarManga(int id);
}
