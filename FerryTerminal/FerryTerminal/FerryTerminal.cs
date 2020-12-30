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

        readonly FerryTerminalLocation _ferryTerminalLocation;

        readonly IDictionary<VehicleType, float> _vehicleTicketPriceDictionary;

        readonly List<Ferry> _ferryList;

        readonly Queue<TerminalEmployee> _terminalEmployeeQueue = new Queue<TerminalEmployee>();

        public FerryTerminal(FerryTerminalLocation ferryTerminalLocation, IDictionary<VehicleType, float> vehicleTicketPriceDictionary)
        {
            _ferryTerminalLocation = ferryTerminalLocation;

            _vehicleTicketPriceDictionary = vehicleTicketPriceDictionary;

            _terminalEmployeeQueue.Enqueue(new TerminalEmployee(0, 0.1f));
            _terminalEmployeeQueue.Enqueue(new TerminalEmployee(1, 0.11f));

            _ferryList = new List<Ferry>
            {
                new Ferry(FerryType.Small, 8, new List<VehicleType> { VehicleType.Car, VehicleType.Van }),
                new Ferry(FerryType.Large, 6, new List<VehicleType> { VehicleType.Bus, VehicleType.Truck }),
                new Ferry(FerryType.Eco, 10, new List<VehicleType> { VehicleType.Electric, VehicleType.Hybrid })
            };
        }

        public void ProcessVehicle(IVehicle vehicle)
        {
            Console.WriteLine("Vehicle location: Arrival");

            if (vehicle is ITicketPayer ticketPayer)
            {
                ChargeTicket(ticketPayer);
            }

            if (vehicle is IGasUser gasUser)
            {
                FillUpGas(gasUser);
            }

            if (vehicle is IElectricUser electricUser)
            {
                FillUpBattery(electricUser);
            }

            if (vehicle is ICargoCarrier cargoCarrier)
            {
                CustomsInspection(cargoCarrier);
            }

            LoadVehicleOnFerry(vehicle);

            Console.WriteLine();
        }

        private void ChargeTicket(ITicketPayer ticketPayer)
        {
            Console.WriteLine("Charging ticket for " + ticketPayer.TicketType);

            float price = _vehicleTicketPriceDictionary[ticketPayer.TicketType];

            float amount = ticketPayer.GetMoney(price);

            TerminalEmployee terminalEmployee = _terminalEmployeeQueue.Dequeue();
            float salary = amount * terminalEmployee.IncomePercent;
            terminalEmployee.AddMoney(salary);
            amount -= salary;
            _terminalEmployeeQueue.Enqueue(terminalEmployee);

            _income += amount;

            Console.WriteLine(_ferryTerminalLocation + " terminal income is now " + _income);
        }

        private void FillUpGas(IGasUser gasUser)
        {
            Console.WriteLine("Amount of gas " + gasUser.GasPercent);

            if (gasUser.NeedsRefill)
            {
                gasUser.GasPercent = 100;

                Console.WriteLine("Vehicle location: Gas station");
            }
        }

        private void FillUpBattery(IElectricUser electricUser)
        {
            Console.WriteLine("Amount of battery " + electricUser.BatteryPercent);

            if (electricUser.NeedsRecharge)
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
            Ferry ferry = _ferryList.Where(f => f.AcceptVehicle(vehicle)).First();

            Console.WriteLine("Vehicle location: " + ferry.FerryType + " ferry");
        }
    }
}
