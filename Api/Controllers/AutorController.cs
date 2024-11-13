using AutoMapper;
using Filmax.Services.Interface;
using FilMax.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace FilMax.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        // Injeção de dependência do serviço de autores
        private readonly IAutorService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor da classe com configuração e injeção do serviço
        /// </summary>
        /// <param name="config">Configuração do serviço</param>
        /// <param name="autorService">Serviço de autores injetado</param>
        public AutorController(IConfiguration config, IAutorService autorService)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = autorService;
        }

        /// <summary>
        /// Adiciona um novo autor ao sistema
        /// </summary>
        /// <param name="AutorDTO">Objeto Autor que contém as informações do autor a ser adicionado</param>
        /// <returns>Retorna uma resposta de sucesso ou erro</returns>
        [HttpPost("adicionar-Autor")]
        public IActionResult AdicionarAutor(Autor AutorDTO)
        {
            try
            {
                _service.Adicionar(AutorDTO);
                return Ok("Autor adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar autor: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista todos os autores cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de autores ou uma resposta de erro</returns>
        [HttpGet("Listar-Autor")]
        public IActionResult ListarAluno()
        {
            try
            {
                var autores = _service.Listar();
                return Ok(autores);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar autores: {ex.Message}");
            }
        }

        /// <summary>
        /// Edita as informações de um autor existente
        /// </summary>
        /// <param name="a">Objeto Autor contendo as informações atualizadas do autor</param>
        /// <returns>Retorna uma resposta de sucesso ou erro</returns>
        [HttpPut("editar-usuario")]
        public IActionResult EditarUsuario(Autor a)
        {
            try
            {
                _service.Editar(a);
                return Ok("Autor editado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao editar autor: {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta um autor existente do sistema
        /// </summary>
        /// <param name="id">Identificador único do autor a ser deletado</param>
        /// <returns>Retorna uma resposta de sucesso ou erro</returns>
        [HttpDelete("deletar-usuario")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok("Autor deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar autor: {ex.Message}");
            }
        }
    }
}
