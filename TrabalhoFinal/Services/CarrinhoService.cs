using FilMax.Entidade;
using Filmax.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilMax.Entidade.DTO;
using Filmax.Repositorio.Interface;
using Filmax.Services.Interface;
using Microsoft.Extensions.Configuration;

namespace Filmax.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        public ICarrinhoRepository repository { get; set; }
        public CarrinhoService(ICarrinhoRepository carrinhoRepository)
        {
            repository = carrinhoRepository;
        }
        public void Adicionar(Carrinho carrinho)
        {
            repository.Adicionar(carrinho);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Carrinho> Listar()
        {
            return repository.Listar();
        }

        public List<CarrinhoDTO> ListarCarrinhoDoUsuario(int usuarioId)
        {
            return repository.ListarCarrinhoDoUsuario(usuarioId);
        }
        public Carrinho BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Carrinho editPessoa)
        {
            repository.Editar(editPessoa);
        }
    }
}
