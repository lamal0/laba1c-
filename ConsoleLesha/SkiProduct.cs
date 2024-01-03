using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleLesha
{
    public class SkiProduct : Product
    {
        string _length;
        string _width;
        public string Length { get { return _length; } private set { _length = value; } }
        public string Width { get { return _width; } private set { _width = value; } }
        public SkiProduct( string color, string description, DateTime started, DateTime finished, string length, string width) : base(color, description, started, finished)
        {
            _length = length;
            _width = width;
        }
        public override string ToString()
        {
            CheckStatus();
            return $"Ski\n" +
                   $"Color: {_color}\n" +
                   $"Description: {_description}\n" +
                   $"Subject: {_length}\n" +
                   $"Resource: {_width}\n" +
                   $"From: {_started}\n" +
                   $"Due to: {_finished}";
        }
    }
}
