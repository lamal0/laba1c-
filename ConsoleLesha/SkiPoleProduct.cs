using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    internal class SkiPoleProduct: Product, ISkiPoleProduct
    {
        string _length;
        string _weight;
        public string Length { get { return _length; } }
        public string Weight { get { return _weight; } }
        public SkiPoleProduct(string color, string description, DateTime started, DateTime finished, string length, string weight) : base(color, description, started, finished)
        {
            _length = length;
            _weight = weight;
        }
        public override string ToString()
        {
            CheckStatus();
            return $"[Ski pole]\n" +
                   $"Color: {_color}\n" +
                   $"Description: {_description}\n" +
                   $"Size: {_length}\n" +
                   $"Type: {_weight}\n" +
                   $"From: {_started}\n" +
                   $"Due to: {_finished}";
        }
    }
}
