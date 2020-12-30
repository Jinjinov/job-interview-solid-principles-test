using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    class GasVehicle : Vehicle, IGasUser
    {
        public int GasPercent { get; set; } = RandomPercent();

        public bool NeedsRefill => GasPercent <= 10;
    }
}
