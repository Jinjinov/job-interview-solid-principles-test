﻿using System;
using System.Collections.Generic;
using System.Text;

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

        readonly int _capacity;

        readonly IList<VehicleType> _acceptedVehicleTypeList;

        readonly List<IVehicle> _vehicleList = new List<IVehicle>();

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
