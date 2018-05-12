using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class ElectricVehicle : Vehicle, IElectricUser
    {
        public int BatteryPercent { get; set; }

        public ElectricVehicle(VehicleType vehicleType) : base(vehicleType)
        {
            BatteryPercent = RandomPercent();
        }

        public static ElectricVehicle GetNewInstance(VehicleType vehicleType)
        {
            return new ElectricVehicle(vehicleType);
        }

        public bool NeedsRecharge()
        {
            return BatteryPercent <= 10;
        }
    }
}
