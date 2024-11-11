using Filmax.Entidade.DTO;
using Filmax.Services.Interface;
using FilMax.Entidade;
using FilMax.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilMax.Services;

public class ClienteService : IClienteService
{
    public ClienteRepository repository { get; set; }
    public ClienteService(string _config)
    {
        repository = new ClienteRepository(_config);
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
