using Dominio;
using Infraestrutura;
using System;
using System.Globalization;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

            var repositorio = new CarroRepositorio();
            
            const string pressioneQualquerTecla = "Pressione qualquer tecla para exibir o menu principal...";

            string opcaoEscolhida;
            do
            {
                Console.Clear();
                Console.WriteLine("Sistema de Agência de Carros");
                Console.WriteLine("1 - Pesquisar Carros");
                Console.WriteLine("2 - Adicionar Carros");
                Console.WriteLine("3 - Sair");

                opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida)
                {
                    case "1":
                        Console.WriteLine("Digite o nome ou parte do nome do carro para pesquisar:");
                        var termoDePesquisa = Console.ReadLine();
                        var carrosEncontrados = repositorio.Pesquisar(termoDePesquisa);

                        if (carrosEncontrados.Count > 0)
                        {
                            Console.WriteLine($"Informe o número do carro encontrado para exibir os detalhes:");
                            for (var index = 0; index < carrosEncontrados.Count; index++)
                                Console.WriteLine($"{index} - Carro: {carrosEncontrados[index].Nome}");

                            ushort indexAExibir;
                            if (!ushort.TryParse(Console.ReadLine(), out indexAExibir) || indexAExibir >= carrosEncontrados.Count)
                            {
                                Console.WriteLine($"Opcao inválida! {pressioneQualquerTecla}");
                                Console.ReadKey();
                                break;
                            }

                            if (indexAExibir < carrosEncontrados.Count)
                            {
                                var carroEscolhido = carrosEncontrados[indexAExibir];

                                var qtdeAnos = carroEscolhido.CalcularHaQuantosAnosFoiFabricado();

                                Console.WriteLine("Dados do carro:");
                                Console.WriteLine($"Nome: {carroEscolhido.Nome}");
                                Console.WriteLine($"Ano: {carroEscolhido.Ano}");
                                Console.WriteLine($"Este carro foi fabricado há {qtdeAnos} anos.");
                                Console.WriteLine(pressioneQualquerTecla);
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Não foi encontrado nenhum carro! {pressioneQualquerTecla}");
                            Console.ReadKey();
                        }
                        break;

                    case "2":

                        Console.WriteLine("Informe o nome do carro");
                        var nome = Console.ReadLine();

                        Console.WriteLine("Informe o ano do carro");

                        int ano;
                        if (!int.TryParse(Console.ReadLine(), out ano))
                        {
                            Console.WriteLine($"Ano inválido! Dados descartados! {pressioneQualquerTecla}");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Dados do carro:");
                        Console.WriteLine($"Nome: {nome}");
                        Console.WriteLine($"Ano: {ano}");
                        Console.WriteLine("Deseja adicionar este carro?");
                        Console.WriteLine("1 - Sim \n2 - Não");
                        var opcaoAdicionar = Console.ReadLine();

                        if (opcaoAdicionar == "1")
                        {
                            var carro = new Carro(nome, ano);

                            repositorio.Adicionar(carro);

                            Console.WriteLine($"Carro adicionado com sucesso! {pressioneQualquerTecla}");
                        }
                        else if (opcaoAdicionar == "2")
                            Console.WriteLine($"Dados descartados! {pressioneQualquerTecla}");
                        else
                            Console.WriteLine($"Opção inválida! {pressioneQualquerTecla}");

                        Console.ReadKey();
                        break;

                    case "3":
                        break;

                    default:
                        Console.WriteLine($"Opção inválida! {pressioneQualquerTecla}");
                        Console.ReadKey();
                        break;
                }
            }
            while (opcaoEscolhida != "3");
        }


    }
}
