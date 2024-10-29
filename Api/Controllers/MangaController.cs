using AutoMapper;
using Filmax.Aplicação;
using FilMax.Aplicação;
using FilMax.Entidade;
using FilMax.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilMax.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MangaController : ControllerBase
    {
        private readonly ITsukiService service;
        private readonly IMapper _mapper;
        public MangaController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString ("DefaultConnection");
            service = new TsukiService(_config);
            _mapper = mapper;
        }
        [HttpPost("Adicionar-Manga")]
        public void AdicionarManga(Mangas m)
        {
            service.Adicionar(m);
        }
        [HttpDelete("Remover-Manga")]
        public void RemoverManga(int id)
        {
            service.Remover(id);
        }
        [HttpGet("Listar-Manga")]
        public List<Mangas> ListarManga()
        {
            return service.Listar();
        }
        [HttpPut("Editar-Manga")]
        public void EditarManga(Mangas m)
        {
            service.Editar(m);
        }
    }
}
