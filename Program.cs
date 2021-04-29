using System;

namespace dio.series
{
    class Program
    {
        // instancia um novo repositorio
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X") {
                switch (opcaoUsuario) {
                    case "1":
                    listarSeries();
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
               opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nosso serviços");
            Console.WriteLine();
        }

        private static void listarSeries() {
            Console.WriteLine("Listar Series");
            var lista = repositorio.lista();
            if (lista.Count == 0) {
                Console.WriteLine("Nenhuma Serie Cadastrada");
                return;
            }
            foreach (var serie in lista) {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }
        private static void InserirSerie() {
            Console.WriteLine("Inserir nova Serie");
            foreach (int i in Enum.GetValues(typeof(Genero))) {
                Console.WriteLine("{0}-{1}", Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o Titulo da Serie");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o Ano de Inicio da Serie");
            int entradaAno = int.Parse(Console.ReadLine());  
            Console.Write("Digite a Descrição da Serie");
            string entradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);                                                  
        }
        private static void AtualizarSerie() {
            Console.Write("digite o id da Serie");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero))) {
                Console.WriteLine("{0}-{1}", Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o Titulo da Serie");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o Ano de Inicio da Serie");
            int entradaAno = int.Parse(Console.ReadLine());  
            Console.Write("Digite a Descrição da Serie");
            string entradaDescricao = Console.ReadLine();
            Serie updateSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, updateSerie);                                                  
        }
        private static void ExcluirSerie() {
            Console.Write("Digite o id da Serie ");
            int idSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(idSerie);

        }
        private static void VisualizarSerie() {
            Console.Write("Digite o id da Serie ");
            int idSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(idSerie);
            Console.WriteLine(serie); 
        }
        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu disposição");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
