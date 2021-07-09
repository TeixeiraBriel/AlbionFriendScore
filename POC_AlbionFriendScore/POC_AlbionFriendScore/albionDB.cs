using HtmlAgilityPack;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_AlbionFriendScore
{
    public class albionDB
    {
        public infoPlayer buscarIdJogador(string nome)
        {
            var client = new RestClient("https://www.albiononline2d.com/proxy/api/gameinfo/search?q=" + nome);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            infoPlayer infoBase = JsonConvert.DeserializeObject<infoPlayer>(response.Content);

            return infoBase;
        }


        public DadosJogador buscarDadosJogador(string nome)
        {
            string idJogador = buscarIdJogador(nome).players[0].Id;

            var client = new RestClient("https://www.albiononline2d.com/en/scoreboard/players/" + idJogador);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(response.Content);
            var tagP = doc.DocumentNode.SelectNodes("//p");
            var tagH5 = doc.DocumentNode.SelectNodes("//h5");

            DadosJogador jogador = new DadosJogador();
            jogador.Nome = tagH5[0].InnerText;
            jogador.Guilda = tagP[1].InnerText.Split(':')[1];
            jogador.Alianca = tagP[2].InnerText.Split(':')[1];
            jogador.KillFama = tagP[3].InnerText.Split(':')[1];
            jogador.DeathFama = tagP[4].InnerText.Split(':')[1];
            jogador.Kd = tagP[5].InnerText.Split(':')[1];
            jogador.ProduzirFama = tagP[6].InnerText.Split(':')[1];
            jogador.Coleta.ColetaTotal = tagP[7].InnerText.Split(':')[1];
            jogador.Coleta.Fibra = tagP[8].InnerText.Split(';')[0].Split(':')[1].Replace("&nbsp", "");
            jogador.Coleta.Pele = tagP[8].InnerText.Split(';')[1].Split(':')[1].Replace("&nbsp", "");
            jogador.Coleta.Minerio = tagP[8].InnerText.Split(';')[2].Split(':')[1].Replace("&nbsp", "");
            jogador.Coleta.Pedra = tagP[8].InnerText.Split(';')[3].Split(':')[1].Replace("&nbsp", "");
            jogador.Coleta.Madeira = tagP[8].InnerText.Split(';')[4].Split(':')[1];
            jogador.PveFama = tagP[9].InnerText.Split(':')[1];

            return jogador;
        }
    }
}
