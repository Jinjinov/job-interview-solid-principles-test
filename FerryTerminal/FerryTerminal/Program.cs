using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class Program
    {
        static void Main(string[] _)
        {
            VehicleFactory.Register<GasVehicle>(VehicleType.Bus);
            VehicleFactory.Register<GasVehicle>(VehicleType.Car);
            VehicleFactory.Register<CargoVehicle>(VehicleType.Truck);
            VehicleFactory.Register<CargoVehicle>(VehicleType.Van);
            VehicleFactory.Register<ElectricVehicle>(VehicleType.Electric);
            VehicleFactory.Register<HybridVehicle>(VehicleType.Hybrid);

            List<FerryTerminal> ferryTerminalList = new List<FerryTerminal>
            {
                new FerryTerminal(FerryTerminalLocation.Croatia, new Dictionary<VehicleType, float>
                {
                    { VehicleType.Electric, 1 },
                    { VehicleType.Hybrid, 2 },
                    { VehicleType.Car, 3 },
                    { VehicleType.Van, 4 },
                    { VehicleType.Bus, 5 },
                    { VehicleType.Truck, 6 }
                })
            };

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                foreach (FerryTerminal ferryTerminal in ferryTerminalList)
                {
                    ferryTerminal.ProcessVehicle(VehicleFactory.RandomVehicle());
                }
            }
        }
    }
}
