using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Common.Models;

namespace Estacionamento.Common.Data
{
    public class Node
    {
        public Node NextNode { get; private set; }
        public Node PreviousNode { get; private set; }
        public Veiculo Veiculo { get; private set; }

        public Node (Veiculo veiculo)
        {
            Veiculo = veiculo;
            NextNode = null;
            PreviousNode = null;
        }

        public Node(Veiculo veiculo, Node next, Node previous)
        {
            Veiculo = veiculo;
            NextNode = next;
            PreviousNode = previous;
        }

        public void SetNext(Node next)
        {
            NextNode = next;
        }
        public void SetPrevious (Node previous)
        {
            PreviousNode = previous;
        }
    }
}