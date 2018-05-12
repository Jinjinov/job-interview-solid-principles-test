using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    interface IElectricUser
    {
        int BatteryPercent { get; set; }

        bool NeedsRecharge();
    }
}
