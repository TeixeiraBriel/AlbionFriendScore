using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_AlbionFriendScore
{
    public class DadosJogador
    {
        private ColetaFama coleta = new ColetaFama();


        public string Nome { get; set; }
        public string Guilda { get; set; }
        public string Alianca { get; set; }
        public string KillFama { get; set; }
        public string DeathFama { get; set; }
        public string Kd { get; set; }
        public string ProduzirFama { get; set; }
        public ColetaFama Coleta
        {
            get { return coleta ; }
            set { coleta = value; }
        }
        public string PveFama { get; set; }
    }

    public class ColetaFama
    {
        public string ColetaTotal { get; set; }
        public string Fibra { get; set; }
        public string Pele { get; set; }
        public string Minerio { get; set; }
        public string Pedra { get; set; }
        public string Madeira { get; set; }
    }

}
