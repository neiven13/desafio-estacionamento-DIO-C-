using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Common.Data;

namespace Estacionamento.Common.Models
{
    public class Estabelecimento
    {
        public List List;
        public decimal PrecoInicial { get; set; }
        public decimal PrecoHora { get; set; }

        public Estabelecimento(decimal precoInicial, decimal precoHora)
        {
            List = new List();
            PrecoInicial = precoInicial;
            PrecoHora = precoHora;
        }

        
        
    }
}