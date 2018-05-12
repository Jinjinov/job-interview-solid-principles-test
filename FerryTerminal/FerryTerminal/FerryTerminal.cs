using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    enum FerryTerminalLocation
    {
        Slovenia,
        Croatia
    }

    class FerryTerminal
    {
        float _income = 0;

        FerryTerminalLocation _ferryTerminalLocation;

        IDictionary<VehicleType, float> _vehicleTicketPriceDictionary;

        List<Ferry> _ferryList = new List<Ferry>();

        Queue<TerminalEmployee> _terminalEmployeeList = new Queue<TerminalEmployee>();

        public FerryTerminal(FerryTerminalLocation ferryTerminalLocation, IDictionary<VehicleType, float> vehicleTicketPriceDictionary)
        {
            _ferryTerminalLocation = ferryTerminalLocation;

            _vehicleTicketPriceDictionary = vehicleTicketPriceDictionary;

            _terminalEmployeeList.Enqueue(new TerminalEmployee(0, 0.1f));
            _terminalEmployeeList.Enqueue(new TerminalEmployee(1, 0.11f));

            _ferryList.Add(new Ferry(FerryType.Small, 8, new List<VehicleType> { VehicleType.Car, VehicleType.Van }));
            _ferryList.Add(new Ferry(FerryType.Large, 6, new List<VehicleType> { VehicleType.Bus, VehicleType.Truck }));
            _ferryList.Add(new Ferry(FerryType.Eco, 10, new List<VehicleType> { VehicleType.Electric, VehicleType.Hybrid }));
        }

        public void ProcessVehicle(IVehicle vehicle)
        {
            Console.WriteLine("Vehicle location: Arrival");

            if (vehicle is ITicketPayer)
            {
                ChargeTicket(vehicle as ITicketPayer);
            }

            if (vehicle is IGasUser)
            {
                FillUpGas(vehicle as IGasUser);
            }

            if (vehicle is IElectricUser)
            {
                FillUpBattery(vehicle as IElectricUser);
            }

            if (vehicle is ICargoCarrier)
            {
                CustomsInspection(vehicle as ICargoCarrier);
            }

            LoadVehicleOnFerry(vehicle);

            Console.WriteLine();
        }

        private void ChargeTicket(ITicketPayer ticketPayer)
        {
            Console.WriteLine("Charging ticket for " + ticketPayer.GetTicketType());

            float price = _vehicleTicketPriceDictionary[ticketPayer.GetTicketType()];

            float amount = ticketPayer.GetMoney(price);

            TerminalEmployee terminalEmployee = _terminalEmployeeList.Dequeue();
            float salary = amount * terminalEmployee.IncomePercent;
            terminalEmployee.AddMoney(salary);
            amount -= salary;
            _terminalEmployeeList.Enqueue(terminalEmployee);

            _income += amount;

            Console.WriteLine("Terminal income is now " + _income);
        }

        private void FillUpGas(IGasUser gasUser)
        {
            Console.WriteLine("Amount of gas " + gasUser.GasPercent);

            if (gasUser.NeedsRefill())
            {
                gasUser.GasPercent = 100;

                Console.WriteLine("Vehicle location: Gas station");
            }
        }

        private void FillUpBattery(IElectricUser electricUser)
        {
            Console.WriteLine("Amount of battery " + electricUser.BatteryPercent);

            if (electricUser.NeedsRecharge())
            {
                electricUser.BatteryPercent = 100;

                Console.WriteLine("Vehicle location: Battery recharge station");
            }
        }

        private void CustomsInspection(ICargoCarrier cargoCarrier)
        {
            Console.WriteLine("Vehicle location: Customs inspection");

            Console.WriteLine("Cargo doors are open: " + cargoCarrier.CargoDoorOpen);

            cargoCarrier.CargoDoorOpen = true;

            Console.WriteLine("Cargo doors are open: " + cargoCarrier.CargoDoorOpen);

            cargoCarrier.CargoDoorOpen = false;

            Console.WriteLine("Cargo doors are open: " + cargoCarrier.CargoDoorOpen);
        }

        private void LoadVehicleOnFerry(IVehicle vehicle)
        {
            foreach (Ferry ferry in _ferryList)
            {
                if (ferry.AcceptVehicle(vehicle))
                {
                    Console.WriteLine("Vehicle location: " + ferry.FerryType + " ferry");
                    break;
                }
            }
        }
    }
}
