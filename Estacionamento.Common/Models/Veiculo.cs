using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Common.Models
{
    public class Veiculo
    {
       public string Placa { get; set; }
       public string NomePortador { get; set; }
       public DateTime HorarioEntrada { get; set; }

       public Veiculo (string placa, string nomePortador)
       {
            Placa = placa;
            NomePortador = nomePortador;
            HorarioEntrada = DateTime.Now;
       }
    }
}