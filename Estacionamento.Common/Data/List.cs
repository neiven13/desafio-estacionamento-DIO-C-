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
            if (IsEmpty())
            {
                return false;
            }

            Node current = Head;
            while (current != null && !current.Veiculo.Equals(veiculo))
            {
                current = current.NextNode;
            }

            if (current == null)
            {
                return false;
            }

            Node previous = current.PreviousNode;
            Node next = current.NextNode;
            if (previous != null)
            {
                previous.SetNext(next);
            }
            else
            {
                Head = next;
            }

            if (next != null)
            {
                next.SetPrevious(previous);
            }
            else
            {
                Last = previous;
            }
            return true;
        }


        public Veiculo SearchVehicle(string plate, string name)
        {
            if (!IsEmpty())
            {
                Node current = Head;
                while (current != null)
                {
                    if (current.Veiculo.LicensePlate.Equals(plate) && current.Veiculo.OwnerName.Equals(name))
                    {
                        return current.Veiculo;
                    }
                    current = current.NextNode;
                }
            }

            return null;
        }

        public IEnumerable<Veiculo> GetVeiculos()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Veiculo;
                current = current.NextNode;
            }
        }
    }
}