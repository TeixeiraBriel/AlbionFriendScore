using POC_AlbionFriendScore.Entidades;
using System;
using System.Collections.Generic;
using XpandoLibrary;

namespace POC_AlbionFriendScore
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                loop();
                Console.Clear();
            } while (true);
        }

        static void loop()
        {
            Console.WriteLine("Quem tu quer pesquisar?");
            string nomePesquisar = Console.ReadLine();
            List<ResultadoPesquisaJogador> opcoes = Executor.buscaJogadores(nomePesquisar);

            Console.WriteLine("Qual é voce?");
            for (int i = 0; i < opcoes.Count; i++)
            {
                Console.WriteLine($"{i} - {opcoes[i].Nome}");
            }
            string opcaoEscolhida = Console.ReadLine();

            Console.WriteLine("Voce escolheu: " + $"{opcoes[int.Parse(opcaoEscolhida)].Nome} - {opcoes[int.Parse(opcaoEscolhida)].id}\n");
            dynamic DadosJogador = Executor.buscaDadosJogador(opcoes[int.Parse(opcaoEscolhida)].id);
            imprimeDadosJogador(DadosJogador);

            Console.ReadLine();
        }

        static void imprimeDadosJogador(dynamic DadosJogador, int identacao = 0)
        {
            foreach (var dado in DadosJogador)
            {
                var tipo = dado.Value?.GetType();

                string textoImprimir = "";
                for (int i = 0; i < identacao; i++)
                {
                    textoImprimir += "  ";
                }

                if (tipo != null && tipo.Name == "ExpandoObject")
                {
                    textoImprimir += $"{dado.Key.ToString()}:";
                    Console.WriteLine(textoImprimir);
                    imprimeDadosJogador(dado.Value, identacao + 1);
                }
                else
                {

                    if (tipo == null)
                        textoImprimir += $"{dado.Key.ToString()}: ";
                    else
                        textoImprimir += $"{dado.Key.ToString()}: {dado.Value.ToString()}";

                    Console.WriteLine(textoImprimir);
                }
            }
        }
    }
}
