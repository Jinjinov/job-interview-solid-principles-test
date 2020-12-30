using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    class GasStation : ILocation
    {
        public void ProcessVehicle(IVehicle vehicle)
        {
            if (vehicle is IGasUser gasUser)
            {
                FillUpGas(gasUser);
            }
        }

        private void FillUpGas(IGasUser gasUser)
        {
            Console.WriteLine("Amount of gas " + gasUser.GasPercent);

            if (gasUser.NeedsRefill)
            {
                gasUser.GasPercent = 100;

                Console.WriteLine("Vehicle location: Gas station");
            }
        }
    }
}
