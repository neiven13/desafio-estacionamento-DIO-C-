
using Estacionamento.Common.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Clear();
Console.WriteLine("Seja bem-vindo ao sistema!\nPor favor, insira o preço inicial que será cobrado:");

decimal initialValue;
string input;

while (true)
{
    input = Console.ReadLine();
    if (decimal.TryParse(input, out initialValue))
    {
        break;
    }
    Console.WriteLine("Entrada inválida. Insira um valor válido");
}

Console.Clear();
Console.WriteLine("Agora insira o valor que será cobrado por hora:");

decimal hourValue;

while (true)
{
    input = Console.ReadLine();
    if (decimal.TryParse(input, out hourValue))
    {
        break;
    }
    Console.WriteLine("Entrada inválida. Insira um valor válido");
}

Estabelecimento parking = new Estabelecimento(initialValue,hourValue);

parking.DisplayMenu();
Console.WriteLine("Encerrado");
