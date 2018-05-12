using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory.Register(VehicleType.Bus, GasVehicle.GetNewInstance);
            VehicleFactory.Register(VehicleType.Car, GasVehicle.GetNewInstance);
            VehicleFactory.Register(VehicleType.Truck, CargoVehicle.GetNewInstance);
            VehicleFactory.Register(VehicleType.Van, CargoVehicle.GetNewInstance);
            VehicleFactory.Register(VehicleType.Electric, ElectricVehicle.GetNewInstance);
            VehicleFactory.Register(VehicleType.Hybrid, HybridVehicle.GetNewInstance);

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
