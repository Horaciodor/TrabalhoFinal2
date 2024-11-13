using AutoMapper;
using Filmax.Entidade.DTO;
using Filmax.Services.Interface;
using FilMax.Entidade;
using FilMax.Entidade.DTO;
using FilMax.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTsuki.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor da classe ClienteController com configuração e injeção do serviço
        /// </summary>
        /// <param name="config">Configuração para conexão com o banco de dados</param>
        /// <param name="clienteService">Serviço de cliente injetado</param>
        public ClienteController(IConfiguration config, IClienteService clienteService)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = clienteService;
        }

        /// <summary>
        /// Adiciona um novo cliente ao sistema
        /// </summary>
        /// <param name="clienteDTO">Objeto Cliente contendo as informações do cliente a ser adicionado</param>
        [HttpPost("adicionar-Cliente")]
        public IActionResult AdicionarCliente(Cliente clienteDTO)
        {
            try
            {
                _service.Adicionar(clienteDTO);
                return Ok("Cliente adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar cliente: {ex.Message}");
            }
        }

        /// <summary>
        /// Realiza o login de um cliente com base nas credenciais fornecidas
        /// </summary>
        /// <param name="usuarioLogin">Objeto ClienteLoginDTO contendo as informações de login do cliente</param>
        /// <returns>Retorna o cliente se as credenciais estiverem corretas</returns>
        [HttpPost("fazer-login")]
        public Cliente FazerLogin(ClienteLonginDTO usuarioLogin)
        {
            Cliente usuario = _service.FazerLogin(usuarioLogin);
            return usuario;
        }

        /// <summary>
        /// Lista todos os clientes cadastrados no sistema
        /// </summary>
        /// <returns>Retorna uma lista de todos os clientes</returns>
        [HttpGet("listar-Cliente")]
        public IActionResult ListarCliente()
        {
            try
            {
                var clientes = _service.Listar();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar cLiente: {ex.Message}");
            }
        }

        /// <summary>
        /// Edita as informações de um cliente existente
        /// </summary>
        /// <param name="p">Objeto Cliente contendo as informações atualizadas do cliente</param>
        [HttpPut("editar-Cliente")]
        public IActionResult EditarCliente(Cliente p)
        {
            try
            {
                _service.Editar(p);
                return Ok("Cliente editado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao editar cliente: {ex.Message}");
            }
        }

        /// <summary>
        /// Deleta um cliente existente do sistema
        /// </summary>
        /// <param name="id">Identificador único do cliente a ser deletado</param>
        [HttpDelete("deletar-Cliente")]
        public IActionResult DeletarCliente(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok("Cliente removido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao remover Cliente: {ex.Message}");
            }
        }
    }
}
