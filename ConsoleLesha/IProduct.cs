using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    enum Status
    {
        ReadyToShip,
        Developing,
        NotStarted
    }
    internal interface IProduct
    {
        DateTime Started { get; }
        DateTime Finished { get; }
        string Description { get; }
        string Color { get; }
        Status Status { get; }
    }
}
