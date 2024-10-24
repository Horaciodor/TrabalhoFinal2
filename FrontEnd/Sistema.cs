using FrontEnd.models;
using FrontEnd.models.DTOs;
using FrontEnd.useCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd;

public class Sistema
{
    private static Cliente clienteLogado { get; set; }
    private readonly ClienteUC _usuarioUC;
    private readonly MangaUC _produtoUC;
    private readonly CarrinhoUC _carrinhoUC;
    private readonly EnderecoUC _enderecoUC;
    public Sistema(HttpClient cliente)
    {
        _usuarioUC = new ClienteUC(cliente);
        _produtoUC = new MangaUC(cliente);
        _carrinhoUC = new CarrinhoUC(cliente);
        _enderecoUC = new EnderecoUC(cliente);
    }
    public void IniciarSistema()
    {
        int resposta = -1;
        while (resposta != 0)
        {
            if (clienteLogado == null)
            {
                resposta = ExibirLogin();

                if (resposta == 1)
                {
                    FazerLogin();
                }
                else if (resposta == 2)
                {
                    Cliente usuario = CriarCliente();
                    _usuarioUC.CadastrarUsuario(usuario);
                    Console.WriteLine("Usuário cadastrado com sucesso");
                }
                else if (resposta == 3)
                {
                    List<Cliente> usuarios = _usuarioUC.Listar();
                    foreach (Cliente c in usuarios)
                    {
                        Console.WriteLine(c.ToString());
                    }
                }
            }
            else
            {
                ExibirMenuPrincipal();
            }
        }
    }
    public int ExibirLogin()
    {
        Console.WriteLine("--------- LOGIN ---------");
        Console.WriteLine("1 - Deseja Fazer Login");
        Console.WriteLine("2 - Deseja se Cadastrar");
        Console.WriteLine("3 - Listar Usuario Cadastrados");
        return int.Parse(Console.ReadLine());
    }
    public Cliente CriarCliente()
    {
        Cliente cliente = new Cliente();
        Console.WriteLine("Digite seu nome: ");
        cliente.Nome = Console.ReadLine();
        Console.WriteLine("Digite seu username: ");
        cliente.Apelido = Console.ReadLine();
        Console.WriteLine("Digite seu senha: ");
        cliente.Senha = Console.ReadLine();
        Console.WriteLine("Digite seu email: ");
        cliente.Email = Console.ReadLine();
        return cliente;
    }
    public Manga CriarManga()
    {
        Manga usuario = new Manga();
        Console.WriteLine("Digite seu nome: ");
        usuario.Nome = Console.ReadLine();
        Console.WriteLine("Digite seu preco: ");
        usuario.Preco = double.Parse(Console.ReadLine());
        return usuario;
    }
    public Endereco CriarEndereco()
    {
        Endereco endereco = new Endereco();
        Console.WriteLine("Digite sua rua: ");
        endereco.Rua = Console.ReadLine();
        Console.WriteLine("Digite seu bairro: ");
        endereco.Bairro = Console.ReadLine();
        Console.WriteLine("Digite seu numero: ");
        endereco.Numero = int.Parse(Console.ReadLine());
        endereco.UsuarioId = clienteLogado.Id;
        return endereco;
    }
    public void FazerLogin()
    {
        Console.WriteLine("Digite seu username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Digite sua senha: ");
        string senha = Console.ReadLine();
        ClienteLogin usuDTO = new ClienteLogin
        {
            Apelido = username,
            Senha = senha
        };
        Cliente usuario = _usuarioUC.FazerLogin(usuDTO);
        if (usuario == null)
        {
            Console.WriteLine("Usuário ou senha inválidos!!!");
        }
        clienteLogado = usuario;
    }
    public void ExibirMenuPrincipal()
    {
        Console.WriteLine("1 - Listar Mangas");
        Console.WriteLine("2 - Cadastrar Manga");
        Console.WriteLine("3 - Realizar uma compra");
        Console.WriteLine("Qual operação deseja realizar?");
        int resposta = int.Parse(Console.ReadLine());
        if (resposta == 1)
        {
            ListarManga();
        }
        else if (resposta == 2)
        {
            Manga produto = CriarManga();
            _produtoUC.CadastrarProduto(produto);
            Console.WriteLine("Usuário cadastrado com sucesso");
        }
        else if (resposta == 3)
        {
            int opcao = 1;
            while (opcao == 1)
            {
                ListarManga();
                Console.WriteLine("Digite os Mangas que deseja comprar:");
                int MangaId = int.Parse(Console.ReadLine());
                Carrinho c = new Carrinho();
                c.MangaId = MangaId;
                c.ClienteId = clienteLogado.Id;
                _carrinhoUC.CadastrarCarrinho(c);

                Console.WriteLine("Escolha a opção: " +
                    "\n 1- Escolher mais produtos" +
                    "\n 2- Finalizar compra");
                opcao = int.Parse(Console.ReadLine());
            }
            List<CarrinhoDTO> carrinhosDTO = _carrinhoUC.ListarCarrinhoUsuarioLogado(clienteLogado.Id);
            foreach (CarrinhoDTO car in carrinhosDTO)
            {
                Console.WriteLine(car.ToString());
            }
            RealizarEntrega();
        }
    }

    private void RealizarEntrega()
    {
        int idEndereco = 0;
        Console.WriteLine("Escolha uma opção: \n 1- Retirar na loja \n 2- Entregar a domicilio");
        int alternativa = int.Parse(Console.ReadLine());
        if (alternativa == 1)
        {
            Console.WriteLine("Retire a sua compra na loja em 7 dias.");
        }
        else if (alternativa == 2)
        {
            Console.WriteLine("Escolha as opção: \n 1- Listar Enderecos cadastrados \n 2 - Cadastrar endereço");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                List<Endereco> enderecos = _enderecoUC.ListarEnderecosDoUsuario(clienteLogado.Id);
                foreach (Endereco end in enderecos)
                {
                    Console.WriteLine(end.ToString());
                }
                Console.WriteLine("Digite qual endereco deseja entregar");
                idEndereco = int.Parse(Console.ReadLine());
            }
            else
            {
                Endereco endereco = CriarEndereco();
                _enderecoUC.CadastrarEndereco(endereco);
                idEndereco = endereco.Id;
            }
        }
    }
    private void ListarManga()
    {
        List<Manga> produtos = _produtoUC.ListarManga();
        foreach (Manga u in produtos)
        {
            Console.WriteLine(u.ToString());
        }
    }
}
