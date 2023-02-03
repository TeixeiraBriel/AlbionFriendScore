using Newtonsoft.Json;
using POC_AlbionFriendScore.Entidades;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_AlbionFriendScore
{
    public static class Executor
    {
        public static List<ResultadoPesquisaJogador> buscaJogadores (string nomeJogador)
        {
            var client = new RestClient($"https://gameinfo.albiononline.com/api/gameinfo/search?q={nomeJogador}");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            dynamic jogadores = (JsonConvert.DeserializeObject<ExpandoObject>(response.Content) as dynamic).players;

            List<ResultadoPesquisaJogador> opcoes = new List<ResultadoPesquisaJogador>();
            foreach (var jogador in jogadores)
            {
                opcoes.Add(new ResultadoPesquisaJogador
                {
                    id = jogador.Id,
                    Nome = jogador.Name
                });
            }

            return opcoes;
        }

        public static dynamic buscaDadosJogador(string idJogador)
        {
            var client = new RestClient($"https://gameinfo.albiononline.com/api/gameinfo/players/{idJogador}");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            dynamic jogador = (JsonConvert.DeserializeObject<ExpandoObject>(response.Content) as dynamic);

            return jogador;
        }
    }
}
