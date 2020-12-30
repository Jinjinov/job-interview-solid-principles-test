using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    interface IElectricUser
    {
        int BatteryPercent { get; set; }

        bool NeedsRecharge { get; }
    }
}
