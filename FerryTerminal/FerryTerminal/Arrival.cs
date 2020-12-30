using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    class Arrival : ILocation
    {
        float _income = 0;

        readonly IDictionary<VehicleType, float> _vehicleTicketPriceDictionary;

        readonly Queue<TerminalEmployee> _terminalEmployeeQueue;

        public Arrival(IDictionary<VehicleType, float> vehicleTicketPriceDictionary, List<TerminalEmployee> terminalEmployeeList)
        {
            _vehicleTicketPriceDictionary = vehicleTicketPriceDictionary;

            _terminalEmployeeQueue = new Queue<TerminalEmployee>(terminalEmployeeList);
        }

        public void ProcessVehicle(IVehicle vehicle)
        {
            if (vehicle is ITicketPayer ticketPayer)
            {
                ChargeTicket(ticketPayer);
            }
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

            Console.WriteLine("Terminal income is now " + _income);
        }
    }
}
