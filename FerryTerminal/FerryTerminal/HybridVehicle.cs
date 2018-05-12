using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class HybridVehicle : Vehicle, IElectricUser, IGasUser
    {
        public int BatteryPercent { get; set; }

        public int GasPercent { get; set; }

        public HybridVehicle(VehicleType vehicleType) : base(vehicleType)
        {
            BatteryPercent = RandomPercent();

            GasPercent = RandomPercent();
        }

        public static HybridVehicle GetNewInstance(VehicleType vehicleType)
        {
            return new HybridVehicle(vehicleType);
        }

        public bool NeedsRecharge()
        {
            return BatteryPercent <= 10 && GasPercent <= 50;
        }

        public bool NeedsRefill()
        {
            return GasPercent <= 10 && BatteryPercent <= 50;
        }
    }
}
