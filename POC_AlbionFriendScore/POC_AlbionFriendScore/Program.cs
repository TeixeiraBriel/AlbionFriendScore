using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_AlbionFriendScore
{
    class Program
    {
        static void Main(string[] args)
        {
            string pesquisa = "";
            List<string> lista_nomes = new List<string>();
            bool validaPesquisa = false;
            albionDB db = new albionDB();
            /*
            Console.WriteLine("Digite os nomes que quer pesquisar, quando for terminar digite 'Pesquisar'");

            do
            {
                pesquisa = Console.ReadLine();
                validaPesquisa = pesquisa.ToLower() != "pesquisar";
                if (validaPesquisa)
                {
                    lista_nomes.Add(pesquisa);
                }
            } while (validaPesquisa);
            */
            List<DadosJogador> Jogadores = new List<DadosJogador>();
            string[] nomes = {
                "Gtzinho",
                "BaKirino",
                "Zyros01",
                "Lewrock",
                "TakatoMatsuki"
            };
            Console.WriteLine("------CARREGANDO-------");
            foreach (var nome in nomes)
            {
                DadosJogador Jogador = db.buscarDadosJogador(nome);
                Jogadores.Add(Jogador);
                Console.Write(".");
            }
            Console.Clear();

            Console.WriteLine("Dados coleta ou geral?");
            pesquisa = Console.ReadLine();

            do
            {
                Console.Clear();

                if (pesquisa.ToLower() == "geral")
                {
                    Console.WriteLine("------DADOS GERAL-------");
                    foreach (var Jogador in Jogadores)
                    {
                        Console.WriteLine("-------------");
                        Console.Write($"Nome:{Jogador.Nome}\n PVE Fama:{Jogador.PveFama}\n Coletar:{Jogador.Coleta.ColetaTotal}\n Produzir:{Jogador.ProduzirFama}\n Fama por Morte:{Jogador.KillFama}\n Kd:{Jogador.Kd}\n ");
                    }
                }
                else if (pesquisa.ToLower() == "coleta")
                {
                    Console.WriteLine("------DADOS COLETA-------");
                    foreach (var Jogador in Jogadores)
                    {
                        Console.WriteLine("-------------");
                        Console.Write($"Nome:{Jogador.Nome}\n Total:{Jogador.Coleta.ColetaTotal}\n Fibra:{Jogador.Coleta.Fibra}\n Minerio:{Jogador.Coleta.Minerio}\n Madeira:{Jogador.Coleta.Madeira}\n Pelego:{Jogador.Coleta.Pele}\n Pedra:{Jogador.Coleta.Pedra}\n ");
                    }
                }
                else if (pesquisa.ToLower() == "exit")
                {

                }
                else
                {
                    Console.WriteLine("Comando desconhecido!");
                }

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Dados coleta ou geral? Digite exit para sair.");
                pesquisa = Console.ReadLine();
            } while (pesquisa.ToLower() != "exit");
            //Console.ReadKey();
        }
    }
}
