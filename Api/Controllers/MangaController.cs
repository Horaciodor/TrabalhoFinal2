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

        /// <summary>
        /// Construtor da classe MangaController com configuração e injeção do serviço
        /// </summary>
        /// <param name="config">Configuração para conexão com o banco de dados</param>
        /// <param name="tsukiService">Serviço de mangá injetado</param>
        public MangaController(IConfiguration config, ITsukiService tsukiService)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            service = tsukiService;
        }

        /// <summary>
        /// Adiciona um novo mangá ao sistema
        /// </summary>
        /// <param name="m">Objeto Mangas que contém as informações do mangá a ser adicionado</param>
        [HttpPost("Adicionar-Manga")]
        public IActionResult AdicionarManga(Mangas m)
        {
            try
            {
                service.Adicionar(m);
                return Ok("Manga adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar Manga: {ex.Message}");
            }
        }

        /// <summary>
        /// Remove um mangá existente do sistema
        /// </summary>
        /// <param name="id">Identificador único do mangá a ser removido</param>
        [HttpDelete("Remover-Manga")]
        public IActionResult RemoverManga(int id)
        {
            try
            {
                service.Remover(id);
                return Ok("Manga removido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover Manga: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista todos os mangás cadastrados no sistema
        /// </summary>
        /// <returns>Retorna uma lista de todos os mangás</returns>
        [HttpGet("Listar-Manga")]
        public IActionResult ListarManga()
        {
            try
            {
                var mangas = service.Listar();
                return Ok(mangas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar Manga: {ex.Message}");
            }
        }

        /// <summary>
        /// Edita as informações de um mangá existente
        /// </summary>
        /// <param name="m">Objeto Mangas contendo as informações atualizadas do mangá</param>
        [HttpPut("Editar-Manga")]
        public IActionResult EditarManga(Mangas m)
        {
            try
            {
                service.Editar(m);
                return Ok("Manga editado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao editar Manga: {ex.Message}");
            }
        }
    }
}
