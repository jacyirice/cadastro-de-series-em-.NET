using System;

namespace JacyWatch
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario(0);

            while (opcaoUsuario != "X")
            {
                string opcaoUsuarioHome = "";
                while (opcaoUsuarioHome != "X")
                {

                    dynamic repositorio;
                    switch (opcaoUsuario)
                    {
                        case "1":
                            repositorio = filmeRepositorio;
                            opcaoUsuarioHome = ObterOpcaoUsuario(1);
                            break;
                        case "2":
                            repositorio = serieRepositorio;
                            opcaoUsuarioHome = ObterOpcaoUsuario(2);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    switch (opcaoUsuarioHome)
                    {
                        case "1":
                            Listar(repositorio);
                            break;
                        case "2":
                            Inserir(repositorio);
                            break;
                        case "3":
                            Atualizar(repositorio);
                            break;
                        case "4":
                            Excluir(repositorio);
                            break;
                        case "5":
                            Visualizar(repositorio);
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        case "X":
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                opcaoUsuario = ObterOpcaoUsuario(0);
            }
        }

        private static void ObterDadosBase(ref int entradaGenero,
                                            ref string entradaTitulo,
                                            ref int entradaAno,
                                            ref string entradaDescricao)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título: ");
            entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início: ");
            entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição: ");
            entradaDescricao = Console.ReadLine();

        }

        private static void Listar(FilmeRepositorio repositorio)
        {
            Console.WriteLine("Listar filmes");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filmes cadastrado.");
                return;
            }

            foreach (var item in lista)
            {
                var excluido = item.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", item.retornaId(), item.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        private static void Listar(SerieRepositorio repositorio)
        {
            Console.WriteLine("Listar series");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }

            foreach (var item in lista)
            {
                var excluido = item.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", item.retornaId(), item.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void Inserir(FilmeRepositorio repositorio)
        {
            Console.WriteLine("Inserir novo filme");
            int entradaGenero = 0, entradaAno = 0;
            string entradaTitulo = "", entradaDescricao = "";
            ObterDadosBase(ref entradaGenero,
                            ref entradaTitulo,
                            ref entradaAno,
                            ref entradaDescricao);
            Console.Write("Digite a duração do filme: ");
            float duracao = float.Parse(Console.ReadLine());
            Filme novo = new Filme(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        duracao: duracao);
            repositorio.Insere(novo);
        }
        private static void Inserir(SerieRepositorio repositorio)
        {
            Console.WriteLine("Inserir nova serie");
            int entradaGenero = 0, entradaAno = 0;
            string entradaTitulo = "", entradaDescricao = "";
            ObterDadosBase(ref entradaGenero,
                            ref entradaTitulo,
                            ref entradaAno,
                            ref entradaDescricao);
            Serie novo = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novo);
        }

        private static void Atualizar(FilmeRepositorio repositorio)
        {
            Console.Write("Digite o id do filme: ");
            int indice = int.Parse(Console.ReadLine());

            int entradaGenero = 0, entradaAno = 0;
            string entradaTitulo = "", entradaDescricao = "";
            ObterDadosBase(ref entradaGenero,
                            ref entradaTitulo,
                            ref entradaAno,
                            ref entradaDescricao);
            Console.Write("Digite a duração do filme: ");
            float duracao = float.Parse(Console.ReadLine());
            Filme atualizacao = new Filme(id: indice,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        duracao: duracao);

            repositorio.Atualiza(indice, atualizacao);
        }
        private static void Atualizar(SerieRepositorio repositorio)
        {
            Console.Write("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());

            int entradaGenero = 0, entradaAno = 0;
            string entradaTitulo = "", entradaDescricao = "";
            ObterDadosBase(ref entradaGenero,
                            ref entradaTitulo,
                            ref entradaAno,
                            ref entradaDescricao);
            Serie atualizacao = new Serie(id: indice,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indice, atualizacao);
        }

        private static void Excluir(FilmeRepositorio repositorio)
        {
            Console.Write("Digite o id do filme: ");
            int indice = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorio.RetornaPorId(indice));

            Console.WriteLine("Deseja realmente excluir esse filme? s/N");
            if (Console.ReadLine().ToLower().Equals("s"))
            {
                repositorio.Exclui(indice);
            }
            else
            {
                Console.WriteLine("Operação cancelada!");
            }
        }
        private static void Excluir(SerieRepositorio repositorio)
        {
            Console.Write("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorio.RetornaPorId(indice));

            Console.WriteLine("Deseja realmente excluir essa serie? s/N");
            if (Console.ReadLine().ToLower().Equals("s"))
            {
                repositorio.Exclui(indice);
            }
            else
            {
                Console.WriteLine("Operação cancelada!");
            }
        }
        
        private static void Visualizar(FilmeRepositorio repositorio)
        {
            Console.Write("Digite o id do filme: ");
            int indice = int.Parse(Console.ReadLine());

            var item = repositorio.RetornaPorId(indice);

            Console.WriteLine(item);
        }
        private static void Visualizar(SerieRepositorio repositorio)
        {
            Console.Write("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());

            var item = repositorio.RetornaPorId(indice);

            Console.WriteLine(item);
        }
        
        private static string ObterOpcaoUsuario(sbyte menu)
        {
            switch (menu)
            {
                case 0:
                    ImprimeMenuHome();
                    break;
                case 1:
                    ImprimeMenuFilmes();
                    break;
                case 2:
                    ImprimeMenuSeries();
                    break;
            }
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void ImprimeMenuSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Jacy Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar");
            Console.WriteLine();
        }
        private static void ImprimeMenuFilmes()
        {
            Console.WriteLine();
            Console.WriteLine("Jacy Filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar");
            Console.WriteLine();
        }
        private static void ImprimeMenuHome()
        {
            Console.WriteLine();
            Console.WriteLine("JacyWatch a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Filmes");
            Console.WriteLine("2- Series");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
        }

    }
}
