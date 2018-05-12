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

        public VehicleType VehicleType { get; private set; }

        float _money = 100;

        public Vehicle(VehicleType vehicleType)
        {
            VehicleType = vehicleType;
        }

        public static int RandomPercent()
        {
            return _random.Next(101);
        }

        public VehicleType GetTicketType()
        {
            return VehicleType;
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
