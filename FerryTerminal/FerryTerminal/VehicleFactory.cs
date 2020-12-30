using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class VehicleFactory
    {
        static readonly Random _random = new Random();

        static readonly Dictionary<VehicleType, Func<VehicleType, IVehicle>> _vehicleFactoryMethodDict = new Dictionary<VehicleType, Func<VehicleType, IVehicle>>();

        public static void Register<T>(VehicleType vehicleType) where T : IVehicle, new()
        {
            _vehicleFactoryMethodDict[vehicleType] = (type) => new T() { VehicleType = type };
        }

        public static IVehicle RandomVehicle()
        {
            VehicleType vehicleType = _vehicleFactoryMethodDict.ElementAt(_random.Next(_vehicleFactoryMethodDict.Count)).Key;

            return _vehicleFactoryMethodDict[vehicleType](vehicleType);
        }
    }
}
