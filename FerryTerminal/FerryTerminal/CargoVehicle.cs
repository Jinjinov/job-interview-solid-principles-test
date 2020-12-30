using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    class CargoVehicle : GasVehicle, ICargoCarrier
    {
        public bool CargoDoorOpen { get; set; }
    }
}
