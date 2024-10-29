using AutoMapper;
using Filmax.Services.Interface;
using FilMax.Entidade;
using FilMax.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilMax.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AutorController : ControllerBase
    {
        private readonly IAutorService _service;
        private readonly IMapper _mapper;
        public AutorController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new AutorService(_config);
            _mapper = mapper;
        }
        [HttpPost("adicionar-Autor")]
        public void AdicionarAutor(Autor AutorDTO)
        {
            _service.Adicionar(AutorDTO);
        }
        [HttpPost("Listar-Autor")]
        public List<Autor> ListarAluno()
        {
            return _service.Listar();
        }
        [HttpPut("editar-usuario")]
        public void EditarUsuario(Autor a)
        {
            _service.Editar(a);
        }
        [HttpDelete("deletar-usuario")]
        public void DeletarUsuario(int id)
        {
            _service.Remover(id);
        }
    }
}
