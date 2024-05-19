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
        public Node Topo { get; set; }

        public List()
        {
            this.Topo = null;
        }

        public bool Add(Veiculo veiculo)
        {
            Node novoNode = new Node(veiculo);
            if (Topo == null)
            {
                Topo = novoNode;
            }
            else
            {
                Node atual = Topo;
                while (atual.Proximo != null)
                {
                    atual = atual.Proximo;
                }
                atual.Proximo = novoNode;
            }
            return true;
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