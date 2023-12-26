using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    public enum Status
    {
        ReadyToShip,
        Developing,
        NotStarted
    }
    public interface IProduct
    {
        DateTime Started { get; }
        DateTime Finished { get; }
        string Description { get; }
        string Color { get; }
        Status Status { get; }
    }
}
