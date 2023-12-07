using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    internal interface ISkiPoleProduct:IProduct
    {
        string Length { get; }
        string Weight { get; }
    }
}
