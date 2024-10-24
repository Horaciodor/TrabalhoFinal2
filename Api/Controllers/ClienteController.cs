using AutoMapper;
using Filmax.Entidade.DTO;
using FilMax.Entidade;
using FilMax.Entidade.DTO;
using FilMax.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTsuki.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _service;
    private readonly IMapper _mapper;
    public ClienteController(IConfiguration config, IMapper mapper)
    {
        string _config = config.GetConnectionString("DefaultConnection");
        _service = new ClienteService(_config);
        _mapper = mapper;
    }
    [HttpPost("adicionar-Cliente")]
    public void AdicionarCliente(Cliente clienteDTO)
    {
        _service.Adicionar(clienteDTO);
    }
    [HttpPost("fazer-login")]
    public Cliente FazerLogin(ClienteLonginDTO usuarioLogin)
    {
        Cliente usuario = _service.FazerLogin(usuarioLogin);
        return usuario;
    }
    [HttpGet("listar-Cliente")]
    public List<Cliente> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpPut("editar-Cliente")]
    public void EditarUsuario(Cliente p)
    {
        _service.Editar(p);
    }
    [HttpDelete("deletar-Cliente")]
    public void DeletarCliente(int id)
    {
        _service.Remover(id);
    }
}
