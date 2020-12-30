using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    enum VehicleType
    {
        Bus,
        Car,
        Truck,
        Van,
        Electric,
        Hybrid,
    }

    interface IVehicle
    {
        VehicleType VehicleType { get; set; }
    }
}
