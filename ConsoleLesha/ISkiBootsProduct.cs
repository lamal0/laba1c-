using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    public enum Type
    {
        Senior,
        Junior,
        Middle
    }
    internal interface ISkiBootsProduct:IProduct
    {
        string Size { get; }
        Type Type { get; }
    }
}
