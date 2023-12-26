using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleLesha
{
    internal class SkiBootsProduct : Product
    {
        string _size;
        Type _type;
        public string Size { get { return _size; } private set { _size = value; } }
        public Type Type { get { return _type; } private set { _type = value; } }
        public SkiBootsProduct(string color, string description, DateTime started, DateTime finished, string size, Type type) : base(color, description, started, finished)
        {
            _size = size;
            _type = type;
        }
        public override string ToString()
        {
            CheckStatus();
            return $"[Ski boots]\n" +
                   $"Color: {_color}\n" +
                   $"Description: {_description}\n" +
                   $"Size: {_size}\n" +
                   $"Type: {_type}\n" +
                   $"From: {_started}\n" +
                   $"Due to: {_finished}";
        }
    }
}
