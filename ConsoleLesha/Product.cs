using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    public class Product
    {
        protected int _id;
        protected string _color;
        protected string _description;
        protected DateTime _started;
        protected DateTime _finished;
        protected Status _status;
        protected int _userId;
        protected User _user;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get { return _id; } private set { _id = value; } }

        public int UserId { get { return _userId; } private set { _userId = value; } }
        public User User { get { return _user; } private set { _user = value; } }

        [Required]
        public string Color { get { return _color; } private set { _color = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public DateTime Started { get { return _started; } private set { _started = value; } }
        public DateTime Finished { get { return _finished; } private set { _finished = value; } }
        public Status Status { get { return _status; } private set { _status = value; } }
/*
        [Column("Discriminator")]
        public string Discriminator { get; set; }*/

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
