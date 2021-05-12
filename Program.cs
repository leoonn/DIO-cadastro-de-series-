using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaousuario = ObterOpcaoUsuario();

            while (opcaousuario.ToUpper() != "X")
            {
                switch (opcaousuario)
                {
                    case "1":
                        InserirSerie();
                        break;
                    case "2":
                        ListarSerie();
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
                opcaousuario = ObterOpcaoUsuario();
            }


        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar serie");

            Console.WriteLine("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir serie");

            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar serie");
            int indeceserie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string  entradaTitulo = (Console.ReadLine());

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite a descrição da serie: ");
            string  entradaDescricao = (Console.ReadLine());

            Serie atualizaserie = new Serie(id: indeceserie, 
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

            repositorio.Atualizar(indeceserie, atualizaserie);
            
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserie Séries");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string  entradaTitulo = (Console.ReadLine());

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite a descrição da serie: ");
            string  entradaDescricao = (Console.ReadLine());

            Serie novaserie = new Serie(id: repositorio.ProximoId(), 
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

            repositorio.Insere(novaserie);

        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar series");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaID(), serie.RetornaTitulo(), (excluido ? "excluido" : ""));

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();

            Console.WriteLine("LeonFlix a seu dipor!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Inserir séries");
            Console.WriteLine("2- Listar séries");
            Console.WriteLine("3- Atualizar séries");
            Console.WriteLine("4- Excluir séries");
            Console.WriteLine("5- Visualizar séries");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;
        }

    }
}
