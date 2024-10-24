using AutoMapper;
using Filmax.Services;
using FilMax.Entidade;
using FilMax.Entidade.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApiTsuki.Controllers;

[ApiController]
[Route("[controller]")]
public class CarrinhoController : ControllerBase
{
    private readonly CarrinhoService _service;
    private readonly IMapper _mapper;
    public CarrinhoController(IConfiguration config, IMapper mapper)
    {
        string _config = config.GetConnectionString("DefaultConnection");
        _service = new CarrinhoService(_config);
        _mapper = mapper;
    }
    [HttpPost("adicionar-carrinho")]
    public void AdicionarCarrinho(Carrinho carrinhoDTO)
    {
        Carrinho carrinho = _mapper.Map<Carrinho>(carrinhoDTO);
        _service.Adicionar(carrinho);
    }
    [HttpGet("listar-carrinho")]
    public List<Carrinho> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpGet("listar-carrinho-do-Cliente")]
    public List<CarrinhoDTO> ListarCarrinhoDoUsuario([FromQuery] int usuarioId)
    {
        return _service.ListarCarrinhoDoUsuario(usuarioId);
    }
    [HttpPut("editar-carrinho")]
    public void EditarCarrinho(Carrinho p)
    {
        _service.Editar(p);
    }
    [HttpDelete("deletar-carrinho")]
    public void DeletarCarrinho(int id)
    {
        _service.Remover(id);
    }
}
