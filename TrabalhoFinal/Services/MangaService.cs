using Filmax.Repositorio.Interface;
using FilMax.Entidade;
using FilMax.Repositorio;
using FilMax.Services.Interface;

namespace FilMax.Services;

public class MangaService: IMangaService
{
    public MangaRepository repository { get; set; }
    public MangaService(string _config)
    {
        repository = new MangaRepository(_config);
    }
    public void Adicionar(Mangas manga)
    {
        repository.AdicionarManga(manga);
    }
    public void RemoverManga(int id)
    {
        repository.Remover(id);
    }
    public List<Mangas> ListarManga()
    {
        return repository.Lista();
    }
    public void EditarManga(Mangas editmanga)
    {
        repository.Editar(editmanga);
    }
}
