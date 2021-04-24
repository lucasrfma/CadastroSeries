using System;
using System.Collections.Generic;

namespace DIO.Series
{
class Program
{
    // static SerieRepositorio repositorio = new SerieRepositorio();
    static RepositorioEmArquivo<Serie> repositorio = new RepositorioEmArquivo<Serie>("Series.txt");
    static void Main(string[] args)
    {
        Serie serie = new Serie();
        Console.WriteLine($"Bem Vindo - Dio Séries e Filmes");
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
                    Visualizar();
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

    private static void Visualizar()
    {
        try
        {
            InquerirID(out int id);
            Console.WriteLine(repositorio.Listar()[id]);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    // Mudanças:
    // adição de verificação antes da exclusão da série
    private static void ExcluirSerie()
    {
        try
        {
            InquerirID(out int id);
            Console.WriteLine("--Confirmação--" + Environment.NewLine +
                              "Excluindo:" + Environment.NewLine +
                              repositorio.Listar()[id] + Environment.NewLine +
                              "Confirma exclusão? (s/N)" + Environment.NewLine);
            if( Console.ReadLine().ToLower().Equals("s") )
            {
                repositorio.Exclui(id);
                Console.WriteLine($"Série excluída.");
            }else
            {
                Console.WriteLine($"Exclusão cancelada.");
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    // Adição de verificação de input correto de ID da série a atualizar
    // Uso de métodos intermediários de leitura de dados em vez de repetição de código
    private static void AtualizarSerie()
    {
        try
        {
            InquerirID(out int id);
            InquerirDados(out Genero genero, out string titulo, out int ano, out string descricao);
            Serie serieAtualizada = new Serie(id,genero,titulo,descricao,ano);
            repositorio.Atualiza(id,serieAtualizada);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    private static void InquerirID(out int id)
    {
        Console.WriteLine($"Digite o ID da série");
        if(!int.TryParse(Console.ReadLine(),out id) || id < 0 || id >= repositorio.ProximoId() )
        {
            throw new FormatException("Erro na entrada de ID");
        }
    }
    // Mudanças
    // 1 - Adição de verificação de erros no input
    // 2 - Simplificação do código de impressão dos gêneros.
    // 3 - Transferência da maior parte do código para um novo método
    //     intermediário, que é reutilizado no método AtualizarSerie()
    private static void InserirSerie()
    {
        Console.WriteLine($"Inserir nova série");
        try
        {
            InquerirDados(out Genero genero, out string titulo, out int ano, out string descricao);
            Serie novaSerie = new Serie(repositorio.ProximoId(),genero,titulo,descricao,ano);
            repositorio.Insere(novaSerie);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    private static void InquerirDados(out Genero genero, out string titulo, out int ano, out string descricao)
    {
        int generos = 0;
        foreach (Genero item in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine($"{(int)item} - {item}");
            ++generos;
        }

        Console.WriteLine($"Digite o gênero entre as opções acima: ");
        if(!int.TryParse(Console.ReadLine(),out int opGenero) || opGenero < 1 || opGenero > generos)
        {
            throw new FormatException("Erro na entrada de gênero.");
        }
        genero = (Genero) opGenero;

        Console.WriteLine($"Digite o título da série:");
        titulo = Console.ReadLine();

        Console.WriteLine($"Digite o ano de início da série:");
        if(!int.TryParse(Console.ReadLine(),out ano))
        {
            throw new FormatException("Erro na entrada de ano de início.");
        }

        Console.WriteLine($"Digite a descrição da série:");
        descricao = Console.ReadLine();
    }
    // Mudanças
    // Só imprime série não excluídas
    // Modo de verificaçào se há ou não série à listar modificada
    // para ficar condizente com essa mudança
    private static void ListarSeries()
    {
        // bool algumaSerie = false;

        try
        {
            foreach (var serie in repositorio.Listar())
            {
                if(!serie.Excluida)
                {
                    // algumaSerie = true;
                    Console.WriteLine($"ID {serie.Id}: {serie.Titulo}");
                }
            }
        }
        catch(Exception){
            Console.WriteLine($"Arquivo não encontrado.");
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
