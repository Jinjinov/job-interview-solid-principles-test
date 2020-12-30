using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class CargoVehicle : GasVehicle, ICargoCarrier
    {
        public bool CargoDoorOpen { get; set; }
    }
}
