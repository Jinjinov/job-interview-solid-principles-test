using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    class HybridVehicle : Vehicle, IElectricUser, IGasUser
    {
        public int BatteryPercent { get; set; } = RandomPercent();

        public int GasPercent { get; set; } = RandomPercent();

        public bool NeedsRecharge => BatteryPercent <= 10 && GasPercent <= 50;

        public bool NeedsRefill => GasPercent <= 10 && BatteryPercent <= 50;
    }
}
