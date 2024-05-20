using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Estacionamento.Common.Data;

namespace Estacionamento.Common.Models
{
    public class Estabelecimento
    {
        public List VeihiclesParked;
        public decimal InitialPrice { get; private set; }
        public decimal HourlyPrice { get; private set; }

        public Estabelecimento(decimal initialValue, decimal hourValue)
        {
            VeihiclesParked = new List();
            InitialPrice = initialValue;
            HourlyPrice = hourValue;
        }

        public void DisplayMenu()
        {
            bool closeMenu = false;
            while (!closeMenu)
            {
                Console.Clear();
                Console.Write("1- Cadastrar veículo \n2- Remover veículo \n3- Listar veículos \n4- Encerrar sessão \nDigite a sua opção: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RegisterVehicle();
                        Thread.Sleep(800);
                        break;
                    case "2":
                        RemoveVehicle();
                        break;
                    case "3":
                        ShowParkedVehicles();
                        break;
                    case "4":
                        closeMenu = true;
                        Console.Clear();
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(200);
                        break;
                }
            }
        }

        public void RegisterVehicle()
        {
            Console.Clear();
            Console.Write("Nome do portador: ");
            string name = Console.ReadLine();
            Console.Write("Placa do veículo: ");
            string plate = Console.ReadLine();


            while (true)
            {
                Console.WriteLine("Confirmar cadastro - s (Sim) | n (Voltar ao menu):  ");
                string input = Console.ReadLine();
                if (input.ToLower() == "s")
                {
                    Veiculo veiculo = new Veiculo(plate.ToUpper(), name.ToUpper());
                    VeihiclesParked.AddLast(veiculo);
                    Console.WriteLine("Veículo cadastrado!");
                    break;
                }
                else if (input.ToLower() == "n")
                {
                    Console.WriteLine("Voltando ao menu...");
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite novamente");
                }
            }

        }

        public void ShowParkedVehicles()
        {
            Console.Clear();
            if (!VeihiclesParked.IsEmpty())
            {
                var vehicles = VeihiclesParked.GetVeiculos();
                Console.WriteLine("Lista dos veículos estacionados:");
                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine($"Placa: {vehicle.LicensePlate} | Nome: {vehicle.OwnerName}");
                }
            }
            else
            {
                Console.WriteLine("Sem veículos estacionados.");
            }
            Console.Write("Pressione uma tecla para voltar ao menu: ");
            Console.ReadKey();
        }

        public void RemoveVehicle()
        {
            Console.Clear();
            Console.Write("Placa do veículo: ");
            string plateToRemove = Console.ReadLine();
            Console.Write("Nome do cliente: ");
            string name = Console.ReadLine();

            Veiculo toRemove = VeihiclesParked.SearchVehicle(plateToRemove.ToUpper(), name.ToUpper());

            if (toRemove != null)
            {
                if (VeihiclesParked.Remove(toRemove))
                {
                    Console.WriteLine($"Veículo '{toRemove.LicensePlate}' removido!\nTotal a pagar: R$ {GetTotalPrice(toRemove)}");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
            Console.Write("Pressione uma tecla para voltar ao menu: ");
            Console.ReadKey();
        }

        public decimal GetTotalPrice(Veiculo veiculo)
        {
            int hoursParked = GetParkedTimeInHours(veiculo.EntryTime);
            return (hoursParked * HourlyPrice) + InitialPrice;
        }

        public int GetParkedTimeInHours(DateTime entryTime)
        {
            TimeSpan parkedTime = DateTime.Now - entryTime;
            return (int)parkedTime.TotalHours;
        }
    }
}