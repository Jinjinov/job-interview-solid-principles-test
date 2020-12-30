using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    interface IGasUser
    {
        int GasPercent { get; set; }

        bool NeedsRefill { get; }
    }
}
