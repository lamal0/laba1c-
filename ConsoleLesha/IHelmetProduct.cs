using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{

    enum Size
    {
        s,
        m,
        l
    }

    internal interface IHelmetProduct:IProduct
    {
        Size Size { get; }
    }
}
