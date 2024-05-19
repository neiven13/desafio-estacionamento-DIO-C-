using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Common.Models
{
    public class Veiculo
    {
       public string LicensePlate { get; private set; }
       public string OwnerName { get; private set; }
       public DateTime EntryTime { get; private set; }

       public Veiculo (string plate, string name)
       {
            LicensePlate = plate;
            OwnerName = name;
            EntryTime = DateTime.Now;
       }
    }
}