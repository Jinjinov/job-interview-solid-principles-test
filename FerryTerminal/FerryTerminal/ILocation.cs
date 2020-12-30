using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    interface ILocation
    {
        void ProcessVehicle(IVehicle vehicle);
    }
}
