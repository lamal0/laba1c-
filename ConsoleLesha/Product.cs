using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    internal class Product : IProduct
    {
        protected string _color;
        protected string _description;
        protected DateTime _started;
        protected DateTime _finished;
        protected Status _status;
        public string Color { get { return _color; } }
        public string Description { get { return _description; } }
        public DateTime Started { get { return _started; } }
        public DateTime Finished { get { return _finished; } }
        public Status Status { get { return _status; } }
        public Product( string color, string description, DateTime started, DateTime finished)
        {
            _color = color;
            _description = description;
            _started = started;
            _finished = finished;
            _status = Status.NotStarted;
        }
        public override string ToString()
        {
            CheckStatus();
            return $"no name\n" +
                   $"Description: {_description}\n" +
                   $"From: {_started}\n" +
                   $"Due to: {_finished}";
        }
        protected Status CheckStatus()
        {
            if (DateTime.Now < _started)
            {
                _status = Status.NotStarted;
                return Status.NotStarted;
            }
            else if (DateTime.Now > _finished)
            {
                _status = Status.ReadyToShip;
                return Status.ReadyToShip;
            }
            _status = Status.Developing;
            return Status.Developing;
        }
    }
}
