using System;
using System.Collections.Generic;
using System.Drawing;
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

    internal class HelmetProduct: Product
    {
        Size _size;
        public Size Size { get { return _size; } private set { _size = value; } }
        public HelmetProduct(string color, string description, DateTime started, DateTime finished, Size size) : base(color, description, started, finished)
        {
            _size = size;
        }
        public override string ToString()
        {
            CheckStatus();
            return $"[Ski pole]\n" +
                   $"Color: {_color}\n" +
                   $"Description: {_description}\n" +
                   $"Type: {_size}\n" +
                   $"From: {_started}\n" +
                   $"Due to: {_finished}";
        }
    }
}
