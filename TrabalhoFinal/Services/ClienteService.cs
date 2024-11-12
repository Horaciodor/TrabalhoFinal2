using Filmax.Entidade.DTO;
using Filmax.Repositorio.Interface;
using Filmax.Services.Interface;
using FilMax.Entidade;
using FilMax.Repositorio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilMax.Services;

public class ClienteService : IClienteService
{
    public IClienteRepository repository { get; set; }
    public ClienteService(IClienteRepository clienteRepository)
    {
        repository = clienteRepository;
    }
    public void Adicionar(Cliente cliente)
    {
        repository.Adicionar(cliente);
    }
    public void Remover(int id)
    {
        repository.Remover(id);
    }
    public List<Cliente> Listar()
    {
        return repository.Listar();
    }
    public Cliente BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Cliente editClien)
    {
        repository.Editar(editClien);
    }
    public Cliente FazerLogin(ClienteLonginDTO usuarioLogin)
    {
        List<Cliente> listUsuario = Listar();
        foreach (Cliente usuario in listUsuario)
        {
            if (usuario.Apelido == usuarioLogin.Apelido
                && usuario.Senha == usuarioLogin.Senha)
            {
                return usuario;
            }
        }
        return null;
    }
}
