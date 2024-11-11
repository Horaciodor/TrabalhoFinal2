using FilMax.Entidade;

namespace FilMax.Services.Interface;

public interface IMangaService
{
    void Adicionar(Mangas manga);
    void RemoverManga(int id);
    List<Mangas> ListarManga();
    void EditarManga(Mangas editmanga);

}
