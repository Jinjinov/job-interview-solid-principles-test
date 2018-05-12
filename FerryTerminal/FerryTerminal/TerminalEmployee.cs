using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    class TerminalEmployee
    {
        int _id;

        float _money;

        public float IncomePercent { get; private set; }

        public TerminalEmployee(int id, float incomePercent)
        {
            _id = id;

            IncomePercent = incomePercent;
        }

        public void AddMoney(float amount)
        {
            _money += amount;

            Console.WriteLine("Employee " + _id + " received " + amount + ", total is " + _money);
        }
    }
}
