using FilMax.Entidade;
using FilMax.Entidade.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmax.Services.Interface;

public interface ICarrinhoService
{
    void Adicionar(Carrinho carrinho);
    void Remover(int id);
    List<Carrinho> Listar();
    List<CarrinhoDTO> ListarCarrinhoDoUsuario(int usuarioId);
    Carrinho BuscarTimePorId(int id);
    void Editar(Carrinho editPessoa);
}
