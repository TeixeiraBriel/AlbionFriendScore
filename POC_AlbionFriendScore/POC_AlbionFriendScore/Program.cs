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

            foreach (var nome in lista_nomes)
            {
                DadosJogador Jogador = db.buscarDadosJogador(nome);
                Console.WriteLine("-------------");
                Console.WriteLine($"Nome:{Jogador.Nome} Fama por Morte:{Jogador.KillFama} Kd:{Jogador.Kd} Produzir:{Jogador.ProduzirFama} Coletar:{Jogador.Coleta.ColetaTotal}");
            }
            Console.ReadKey();
        }
    }
}
