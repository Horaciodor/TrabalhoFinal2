using AutoMapper;
using Filmax.Services;
using Filmax.Services.Interface;
using FilMax.Entidade;
using FilMax.Entidade.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApiTsuki.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor da classe CarrinhoController com configuração e injeção do serviço
        /// </summary>
        /// <param name="config">Configuração para conexão com o banco de dados</param>
        /// <param name="carrinhoService">Serviço de carrinho injetado</param>
        public CarrinhoController(IConfiguration config, ICarrinhoService carrinhoService)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = carrinhoService;
        }

        /// <summary>
        /// Adiciona um novo carrinho ao sistema
        /// </summary>
        /// <param name="carrinhoDTO">Objeto Carrinho que contém as informações do carrinho a ser adicionado</param>
        [HttpPost("adicionar-carrinho")]
        public IActionResult AdicionarCarrinho(Carrinho carrinhoDTO)
        {
            try
            {
                Carrinho carrinho = _mapper.Map<Carrinho>(carrinhoDTO);
                _service.Adicionar(carrinho);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Lista todos os carrinhos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de todos os carrinhos</returns>
        [HttpGet("listar-carrinho")]
        public List<Carrinho> ListarAluno()
        {
            return _service.Listar();
        }

        /// <summary>
        /// Lista os carrinhos associados a um cliente específico
        /// </summary>
        /// <param name="usuarioId">ID do usuário para listar os carrinhos</param>
        /// <returns>Retorna uma lista de carrinhos do cliente especificado</returns>
        [HttpGet("listar-carrinho-do-Cliente")]
        public List<CarrinhoDTO> ListarCarrinhoDoUsuario([FromQuery] int usuarioId)
        {
            return _service.ListarCarrinhoDoUsuario(usuarioId);
        }

        /// <summary>
        /// Edita as informações de um carrinho existente
        /// </summary>
        /// <param name="p">Objeto Carrinho contendo as informações atualizadas</param>
        [HttpPut("editar-carrinho")]
        public IActionResult EditarCarrinho(Carrinho p)
        {
            try
            {
                _service.Editar(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar carrinho: { ex.Message}");
            }
        }

        /// <summary>
        /// Deleta um carrinho existente do sistema
        /// </summary>
        /// <param name="id">Identificador único do carrinho a ser deletado</param>
        [HttpDelete("deletar-carrinho")]
        public IActionResult DeletarCarrinho(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro no carrinho { ex.Message}");
            }

        }
    }
}

