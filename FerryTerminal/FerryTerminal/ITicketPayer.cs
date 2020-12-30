using System;
using System.Collections.Generic;
using System.Text;

namespace FerryTerminal
{
    interface ITicketPayer
    {
        VehicleType TicketType { get; }

        float GetMoney(float amount);
    }
}
