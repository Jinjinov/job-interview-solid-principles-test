using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    class CustomsInspection : ILocation
    {
        public void ProcessVehicle(IVehicle vehicle)
        {
            if (vehicle is ICargoCarrier cargoCarrier)
            {
                Inspection(cargoCarrier);
            }
        }

        private void Inspection(ICargoCarrier cargoCarrier)
        {
            Console.WriteLine("Vehicle location: Customs inspection");

            Console.WriteLine("Cargo doors are open: " + cargoCarrier.CargoDoorOpen);

            cargoCarrier.CargoDoorOpen = true;

            Console.WriteLine("Cargo doors are open: " + cargoCarrier.CargoDoorOpen);

            cargoCarrier.CargoDoorOpen = false;

            Console.WriteLine("Cargo doors are open: " + cargoCarrier.CargoDoorOpen);
        }
    }
}
