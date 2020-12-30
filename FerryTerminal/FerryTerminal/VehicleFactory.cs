using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class VehicleFactory
    {
        static Random _random = new Random();

        static Dictionary<VehicleType, Func<VehicleType, IVehicle>> _vehicleFactoryMethodList = new Dictionary<VehicleType, Func<VehicleType, IVehicle>>();

        public static void Register<T>(VehicleType vehicleType) where T : IVehicle, new()
        {
            _vehicleFactoryMethodList.Add(vehicleType, (type) => new T() { VehicleType = type });
        }

        public static IVehicle RandomVehicle()
        {
            VehicleType vehicleType = (VehicleType)_random.Next((int)VehicleType.Count);

            return _vehicleFactoryMethodList[vehicleType](vehicleType);
        }
    }
}
