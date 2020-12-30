using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class ElectricVehicle : Vehicle, IElectricUser
    {
        public int BatteryPercent { get; set; } = RandomPercent();

        public bool NeedsRecharge => BatteryPercent <= 10;
    }
}
