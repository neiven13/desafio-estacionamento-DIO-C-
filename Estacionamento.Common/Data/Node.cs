using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Common.Models;

namespace Estacionamento.Common.Data
{
    public class Node
    {
        public Node Proximo { get; set; }
        public Veiculo Veiculo { get; set; }

        public Node (Veiculo veiculo)
        {
            Veiculo = veiculo;
            Proximo = null;
        }
    }
}