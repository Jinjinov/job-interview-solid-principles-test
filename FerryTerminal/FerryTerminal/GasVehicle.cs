using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class GasVehicle : Vehicle, IGasUser
    {
        public int GasPercent { get; set; }

        public GasVehicle(VehicleType vehicleType) : base(vehicleType)
        {
            GasPercent = RandomPercent();
        }

        public static GasVehicle GetNewInstance(VehicleType vehicleType)
        {
            return new GasVehicle(vehicleType);
        }

        public bool NeedsRefill()
        {
            return GasPercent <= 10;
        }
    }
}
