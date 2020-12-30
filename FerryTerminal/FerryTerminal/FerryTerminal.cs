using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FerryTerminal
{
    enum FerryTerminalLocation
    {
        Slovenia,
        Croatia
    }

    class FerryTerminal
    {
        readonly FerryTerminalLocation _ferryTerminalLocation;

        readonly List<Ferry> _ferryList;

        readonly List<ILocation> _locationList;

        public FerryTerminal(FerryTerminalLocation ferryTerminalLocation, List<Ferry> ferryList, List<ILocation> locationList)
        {
            _ferryTerminalLocation = ferryTerminalLocation;

            _ferryList = ferryList;

            _locationList = locationList;
        }

        public void ProcessVehicle(IVehicle vehicle)
        {
            Console.WriteLine("Vehicle location: Arrival at " + _ferryTerminalLocation + " ferry terminal");

            foreach (ILocation location in _locationList)
            {
                location.ProcessVehicle(vehicle);
            }

            LoadVehicleOnFerry(vehicle);

            Console.WriteLine();
        }

        private void LoadVehicleOnFerry(IVehicle vehicle)
        {
            Ferry ferry = _ferryList.Where(f => f.AcceptVehicle(vehicle)).First();

            Console.WriteLine("Vehicle location: " + ferry.FerryType + " ferry");
        }
    }
}
