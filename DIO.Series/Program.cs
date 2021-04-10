using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            Console.WriteLine($"Bem Vindo - Dio Séries");
            string opcao = ObterOpcaoUsuario();
            while(opcao != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, por fazer digite novamente.");
                        break;
                }
                Console.WriteLine($"Aperte um botão para continuar.");
                Console.ReadKey();
                opcao = ObterOpcaoUsuario();
            }
            Console.WriteLine("Pode desligar o sistema!");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            throw new NotImplementedException();
        }

        private static void ExcluirSerie()
        {
            throw new NotImplementedException();
        }

        private static void AtualizarSerie()
        {
            throw new NotImplementedException();
        }
        // Mudanças
        // 1 - Adição de verificação de input númerico
        // 2 - Simplificação do código de impressão dos gêneros.
        private static void InserirSerie()
        {
            Console.WriteLine($"Inserir nova série");

            int generos = 0;
            foreach (var item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{(int)item} - {item}");
                ++generos;
            }

            Console.WriteLine($"Digite o gênero entre as opções acima: ");
            if(!int.TryParse(Console.ReadLine(),out int opGenero) || opGenero < 1 || opGenero > generos)
            {
                Console.WriteLine($"Erro na entrada de gênero.");
                return;
            }

            Console.WriteLine($"Digite o título da série:");
            string titulo = Console.ReadLine();

            Console.WriteLine($"Digite o ano de início da série:");
            if(!int.TryParse(Console.ReadLine(),out int ano))
            {
                Console.WriteLine($"Erro na entrada de ano de início.");
                return;
            }

            Console.WriteLine($"Digite a descrição da série:");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(),(Genero)opGenero,titulo,descricao,ano);

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();

            if( lista.Count == 0 )
            {
                Console.WriteLine($"Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine($"#ID {serie.Id}: {serie.Titulo}");
            }
            
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine(  $"{Environment.NewLine}Informe a opção desejada: " +
                                $"{Environment.NewLine}1 - Listar Séries;"+
                                $"{Environment.NewLine}2 - Inserir Nova Série;" +
                                $"{Environment.NewLine}3 - Atualizar Série;" +
                                $"{Environment.NewLine}4 - Excluir Série;" +
                                $"{Environment.NewLine}5 - Visualizar Série;{Environment.NewLine}" +
                                $"{Environment.NewLine}C - Limpar tela;" +
                                $"{Environment.NewLine}X - Sair.{Environment.NewLine}");
            return Console.ReadLine().ToUpper();
        }
    }
}
