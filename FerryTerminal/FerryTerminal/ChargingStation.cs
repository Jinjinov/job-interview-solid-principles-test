using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    class ChargingStation : ILocation
    {
        public void ProcessVehicle(IVehicle vehicle)
        {
            if (vehicle is IElectricUser electricUser)
            {
                FillUpBattery(electricUser);
            }
        }

        private void FillUpBattery(IElectricUser electricUser)
        {
            Console.WriteLine("Amount of battery " + electricUser.BatteryPercent);

            if (electricUser.NeedsRecharge)
            {
                electricUser.BatteryPercent = 100;

                Console.WriteLine("Vehicle location: Battery recharge station");
            }
        }
    }
}
