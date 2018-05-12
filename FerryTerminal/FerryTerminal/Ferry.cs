using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    enum FerryType
    {
        Small,
        Large,
        Eco
    }

    class Ferry
    {
        public FerryType FerryType { get; private set; }

        int _capacity;

        IList<VehicleType> _acceptedVehicleTypeList;

        List<IVehicle> _vehicleList = new List<IVehicle>();

        public Ferry(FerryType ferryType, int capacity, IList<VehicleType> acceptedVehicleTypeList)
        {
            FerryType = ferryType;

            _capacity = capacity;

            _acceptedVehicleTypeList = acceptedVehicleTypeList;
        }

        public bool AcceptVehicle(IVehicle vehicle)
        {
            if (_acceptedVehicleTypeList.Contains(vehicle.VehicleType))
            {
                _vehicleList.Add(vehicle);

                if (_vehicleList.Count == _capacity)
                {
                    // sail away and come back

                    _vehicleList.Clear();
                }

                return true;
            }

            return false;
        }
    }
}
