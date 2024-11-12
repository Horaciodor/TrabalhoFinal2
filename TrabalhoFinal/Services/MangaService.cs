using Filmax.Repositorio.Interface;
using FilMax.Entidade;
using FilMax.Repositorio;
using FilMax.Services.Interface;
using Microsoft.Extensions.Configuration;

namespace FilMax.Services;

public class MangaService: IMangaService
{
    private readonly IMangaRepository repository;
    public MangaService(IMangaRepository mangaRepository)
    {
        repository = mangaRepository;
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
