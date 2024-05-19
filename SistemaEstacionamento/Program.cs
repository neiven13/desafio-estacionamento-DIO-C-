
using Estacionamento.Common.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Clear();
Console.WriteLine("Seja bem-vindo ao sistema!\nPor favor, insira o preço inicial que será cobrado:");

decimal precoInicial;
string input;

while (true)
{
    input = Console.ReadLine();
    if (decimal.TryParse(input, out precoInicial))
    {
        break;
    }
    Console.WriteLine("Entrada inválida. Insira um valor válido");
}

Console.Clear();
Console.WriteLine("Agora insira o valor que será cobrado por hora:");

decimal precoHora;

while (true)
{
    input = Console.ReadLine();
    if (decimal.TryParse(input, out precoHora))
    {
        break;
    }
    Console.WriteLine("Entrada inválida. Insira um valor válido");
}

Estabelecimento estacionamento = new Estabelecimento(precoInicial,precoHora);

estacionamento.ExibirMenu();
Console.WriteLine("Encerrado");
