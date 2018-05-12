using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal
{
    interface ICargoCarrier
    {
        bool CargoDoorOpen { get; set; }
    }
}
