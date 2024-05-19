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
        public List Vagas;
        public decimal PrecoInicial { get; set; }
        public decimal PrecoHora { get; set; }

        public Estabelecimento(decimal precoInicial, decimal precoHora)
        {
            Vagas = new List();
            PrecoInicial = precoInicial;
            PrecoHora = precoHora;
        }
        public void ExibirMenu()
        {
            bool exibirMenu = true;
            while (exibirMenu)
            {
                Console.Clear();
                Console.Write("1- Cadastrar veículo \n2- Remover veículo \n3- Listar veículos \n4- Encerrar sessão \nDigite a sua opção: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CadastrarVeiculo();
                        Thread.Sleep(800);
                        break;
                    case "2":
                        RemoverVeiculo();
                        break;
                    case "3":
                        ListarVeiculos();
                        break;
                    case "4":
                        exibirMenu = false;
                        Console.Clear();
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(800);
                        break;
                }
            }
        }
        public void CadastrarVeiculo()
        {
            Console.Clear();
            Console.Write("Nome do portador: ");
            string nome = Console.ReadLine();
            Console.Write("Placa do veículo: ");
            string placa = Console.ReadLine();


            while (true)
            {
                Console.WriteLine("Confirmar cadastro - s (Sim) | n (Voltar ao menu):  ");
                string input = Console.ReadLine();
                if (input.ToLower() == "s")
                {
                    Veiculo veiculo = new Veiculo(placa.ToUpper(), nome.ToUpper());
                    if (Vagas.Add(veiculo))
                    {
                        Console.WriteLine("Veículo cadastrado!");
                    }
                    else
                    {
                        Console.Write("Erro ao cadastrar o veículo, tente novamente!");
                    }
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
        public void ListarVeiculos()
        {
            var veiculos = Vagas.GetVeiculos();
            Console.Clear();
            Console.WriteLine("Lista dos veículos estacionados:");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine($"Placa: {veiculo.Placa} | Nome: {veiculo.NomePortador}");
            }
            Console.Write("Pressione uma tecla para voltar ao menu: ");
            Console.ReadKey();
        }
        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.Write("Placa do veículo: ");
            string placa = Console.ReadLine();
            Console.Write("Nome do retirante: ");
            string nome = Console.ReadLine();
            var veiculos = Vagas.GetVeiculos();
            bool veiculoEncontrado = false;
            foreach (var veiculo in veiculos)
            {

                if (veiculo.Placa == placa.ToUpper() && veiculo.NomePortador == nome.ToUpper())
                {
                    veiculoEncontrado = true;
                    if (Vagas.Remove(veiculo))
                    {
                        decimal precoTotal = CalcularPrecoTotal(veiculo);
                        Console.WriteLine($"O veículo {veiculo.Placa} foi removido. Valor a pagar: R$ {precoTotal:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao remover. Tente novamente.");
                    }
                    break;
                }
                else if (veiculo.Placa == placa.ToUpper() && veiculo.NomePortador != nome.ToUpper())
                {
                    veiculoEncontrado = true;
                    Console.WriteLine("Esse veículo está cadastrado no nome de outra pessoa!");
                    break;
                }
            }
            if (!veiculoEncontrado)
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
            Console.Write("Pressione uma tecla para voltar ao menu: ");
            Console.ReadKey();
        }
        public decimal CalcularPrecoTotal(Veiculo veiculo)
        {
            TimeSpan tempoEstacionado = DateTime.Now - veiculo.HorarioEntrada;
            Console.WriteLine($"Tempo estacionado: {tempoEstacionado.TotalHours:F0}h{(int)tempoEstacionado.TotalMinutes%60} min");
            return ((int)tempoEstacionado.TotalHours * PrecoHora) + PrecoInicial;
        }
    }
}