using System;
using static System.Console;
using System.Collections.Generic;

using dio_bootcamp_localiza_mrv_app_console_dotnet_cadastro_series.Classes;
using dio_bootcamp_localiza_mrv_app_console_dotnet_cadastro_series.Enuns;

namespace dio_bootcamp_localiza_mrv_app_console_dotnet_cadastro_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
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

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série que deseja visualizar ");
            int idSerie = int.Parse(Console.ReadLine());

            var serieVisualizar = repositorio.RetornaPorId(idSerie);

            Console.WriteLine(serieVisualizar);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série que deseja excluir ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(idSerie);
        }

        private static void AtualizarSerie()
        {
            bool ehValorNumerico = true;
            char[] valorNumericoChar;
            string entradaGenero = "";
            string entradaAno = "";
            int cont = 0;

            Console.Write("Digite o id da série que deseja atualizar ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            do
            {
                ehValorNumerico = true;
                cont = 0;

                Console.Write("Escolha o gênero acima! ");
                entradaGenero = Console.ReadLine();

                valorNumericoChar = entradaGenero.ToCharArray();

                // Verifica se é numero.
                while(ehValorNumerico && valorNumericoChar.Length > cont)
                {
                    if(!char.IsDigit(valorNumericoChar[cont++]))
                    {
                        ehValorNumerico = false;
                    }
                }

                // Verifica se existe opção de gênero
                if(ehValorNumerico)
                {
                    cont = Enum.GetValues(typeof(Genero)).Length;

                    if(int.Parse(entradaGenero) <= 0 || int.Parse(entradaGenero) > cont)
                    {
                        ehValorNumerico = false;
                    }
                }

            }while(!ehValorNumerico);

            Console.Write("Digite o nome da série ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite a descrição da série ");
            string entradaDescricao = Console.ReadLine();
            
            do
            {
                ehValorNumerico = true;
                cont = 0;

                Console.Write("Digite o ano de lançamento ");
                entradaAno = Console.ReadLine();

                valorNumericoChar = entradaAno.ToCharArray();

                while(ehValorNumerico && valorNumericoChar.Length > cont)
                {
                    if(!char.IsDigit(valorNumericoChar[cont++]))
                    {
                        ehValorNumerico = false;
                    }
                }
            }while(!ehValorNumerico);

            Serie atualizaSerie = new Serie(
                id: idSerie,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: int.Parse(entradaAno),
                genero: (Genero)int.Parse(entradaGenero)
            );

            repositorio.Atualiza(idSerie, atualizaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série assistida por Luiz Chequini");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido() ? "- Excluido" : "";

                Console.WriteLine($"#ID: {serie.retornoId()} - {serie.retornoTitulo()} {excluido}" );
            }
        }

        private static void InserirSerie()
        {
            bool ehValorNumerico = true;
            char[] valorNumericoChar;
            string entradaGenero = "";
            string entradaAno = "";
            int cont = 0;

            Console.WriteLine("Inserir Série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            do
            {
                ehValorNumerico = true;
                cont = 0;

                Console.Write("Escolha o gênero acima! ");
                entradaGenero = Console.ReadLine();

                valorNumericoChar = entradaGenero.ToCharArray();

                // Verifica se é numero.
                while(ehValorNumerico && valorNumericoChar.Length > cont)
                {
                    if(!char.IsDigit(valorNumericoChar[cont++]))
                    {
                        ehValorNumerico = false;
                    }
                }

                // Verifica se existe opção de gênero
                if(ehValorNumerico)
                {
                    cont = Enum.GetValues(typeof(Genero)).Length;

                    if(int.Parse(entradaGenero) <= 0 || int.Parse(entradaGenero) > cont)
                    {
                        ehValorNumerico = false;
                    }
                }

            }while(!ehValorNumerico);

            Console.Write("Digite o nome da série ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite a descrição da série ");
            string entradaDescricao = Console.ReadLine();
            
            do
            {
                ehValorNumerico = true;
                cont = 0;

                Console.Write("Digite o ano de lançamento ");
                entradaAno = Console.ReadLine();

                valorNumericoChar = entradaAno.ToCharArray();

                while(ehValorNumerico && valorNumericoChar.Length > cont)
                {
                    if(!char.IsDigit(valorNumericoChar[cont++]))
                    {
                        ehValorNumerico = false;
                    }
                }
            }while(!ehValorNumerico);

            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: int.Parse(entradaAno),
                genero: (Genero)int.Parse(entradaGenero)
            );

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Séries assistidas - Luiz Chequini");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.Clear();
            return opcaoUsuario;

        }
        
    }
}

