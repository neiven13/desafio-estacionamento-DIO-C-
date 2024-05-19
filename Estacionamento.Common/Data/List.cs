using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Estacionamento.Common.Models;

namespace Estacionamento.Common.Data
{
    public class List
    {
        public Node Head { get; private set; }
        public Node Last { get; private set; }

        public List()
        {
            Head = null;
            Last = null;
        }

        public void AddLast(Veiculo veiculo)
        {
            if (IsEmpty())
            {
                Node newNode = new Node(veiculo);
                Head = Last = newNode;
                Head.SetNext(Last);
                Last.SetPrevious(Head);
            }
            else
            {
                Node newNode = new Node(veiculo, Last);
                Last.SetNext(newNode);
                Last = newNode;
            }
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public bool Remove(Veiculo veiculo)
        {
            if (Topo == null)
            {
                return false;
            }
            if (Topo.Veiculo == veiculo)
            {
                Topo = Topo.Proximo;
                return true;
            }

            Node atual = Topo;
            Node anterior = null;

            while (Topo.Proximo != null && atual.Veiculo != veiculo)
            {
                anterior = atual;
                atual = atual.Proximo;
            }

            anterior.Proximo = atual.Proximo;
            return true;
        }

        public IEnumerable<Veiculo> GetVeiculos()
        {
            Node atual = Topo;
            while (atual != null)
            {
                yield return atual.Veiculo;
                atual = atual.Proximo;
            }
        }
    }
}