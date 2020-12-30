using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    class ElectricVehicle : Vehicle, IElectricUser
    {
        public int BatteryPercent { get; set; } = RandomPercent();

        public bool NeedsRecharge => BatteryPercent <= 10;
    }
}
