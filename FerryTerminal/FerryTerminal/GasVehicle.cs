using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class GasVehicle : Vehicle, IGasUser
    {
        public int GasPercent { get; set; } = RandomPercent();

        public bool NeedsRefill => GasPercent <= 10;
    }
}
