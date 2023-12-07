using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    internal interface ISkiProduct : IProduct//study
    {
        string Length { get; }
        string Width { get; }
    }
}
