using System;

namespace TreinamentoCSharp
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();

    static void Main(string[] args)
    {
      string OpcaoUsuario = ObterOpcaoUsuario();

      while (OpcaoUsuario.ToUpper() != "X")
      {
        switch (OpcaoUsuario)
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
            throw new ArgumentOutOfRangeException();
        }
        OpcaoUsuario = ObterOpcaoUsuario();
      }
      Console.WriteLine("Obrigado por Utilizar os Serviços de Series !");
      Console.ReadLine();
    }

    private static void VisualizarSerie()
    {
      Console.WriteLine("Digite o ID Da Serie para Visualizar : ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);

      Console.WriteLine(serie);

    }

    private static void ExcluirSerie()
    {
      Console.WriteLine("Digite o ID Da Serie a ser Excluido : ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceSerie);

    }

    private static void AtualizarSerie()
    {
      Console.WriteLine("Digite o ID Da Serie");
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.Write("Digite o Gênero entre as Opções : ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Titulo da Serie : ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano Inicio da Serie : ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Serie : ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(id: indiceSerie,
                                      genero: (Genero)entradaGenero,
                                      titulo: entradaTitulo,
                                      ano: entradaAno,
                                      descricao: entradaDescricao
                                      );
      repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir Nova Serie");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.Write("Digite o Gênero entre as Opções ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Titulo da Serie ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano Inicio da Serie ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Serie ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao
                                  );
      repositorio.Insere(novaSerie);

    }

    private static void ListarSeries()
    {
      Console.WriteLine("Listar Series");

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma Lista foi Encontrada");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        {
          Console.WriteLine("#Indice do Registro {0} - Titulo do Filme -  {1} - Descrição do Filme - {2}, Está Excluido -  {3} ", serie.retornaId(), serie.retornaTitulo(), serie.retornaDescricao(), excluido ? " Sim" : " Não");
        }
      }
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Dio Series a seu dispor !");
      Console.WriteLine("Informe a Opção Desejada: ");
      Console.WriteLine("1 - Listar Series ");
      Console.WriteLine("2 - Inserir Nova Serie");
      Console.WriteLine("3 - Atualizar Nova Serie");
      Console.WriteLine("4 - Excluir Serie");
      Console.WriteLine("5 - Visualizar Serie");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string OpcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return OpcaoUsuario;

    }


  }
}
