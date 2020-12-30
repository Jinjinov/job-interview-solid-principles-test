using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class Vehicle : IVehicle, ITicketPayer
    {
        static Random _random = new Random();

        public VehicleType VehicleType { get; set; }

        public VehicleType TicketType => VehicleType;

        float _money = 100;

        public static int RandomPercent()
        {
            return _random.Next(101);
        }

        public float GetMoney(float amount)
        {
            if (_money >= amount)
            {
                _money -= amount;

                Console.WriteLine("Vehicle payed " + amount);

                return amount;
            }

            throw new Exception("Not enough money");
        }
    }
}
