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

        public static void Register(VehicleType vehicleType, Func<VehicleType, IVehicle> newInstanceFunc)
        {
            _vehicleFactoryMethodList.Add(vehicleType, newInstanceFunc);
        }

        public static IVehicle RandomVehicle()
        {
            VehicleType vehicleType = (VehicleType)_random.Next((int)VehicleType.Count);

            return _vehicleFactoryMethodList[vehicleType](vehicleType);
        }
    }
}
