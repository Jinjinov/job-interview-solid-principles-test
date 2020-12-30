using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    interface ITicketPayer
    {
        VehicleType TicketType { get; }

        float GetMoney(float amount);
    }
}
