using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    interface IGasUser
    {
        int GasPercent { get; set; }

        bool NeedsRefill();
    }
}
