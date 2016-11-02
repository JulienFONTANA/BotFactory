using BotFactory.Common.Tools;
using BotFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Models;

namespace BotFactory.Models
{
    public abstract class BaseUnit : ReportingUnit
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public Coordinates CurrentPos { get; set; }

        public async Task<bool> Move(double x, double y)
        {
            OnStatusChanged(this, new StatusChangedEventArgs("I am moving."));

            Coordinates tmp_coord = new Coordinates(x, y);
            Vector tmp_vector = Vector.FromCoordinates(CurrentPos, tmp_coord);

            double delay = tmp_vector.Length * Speed;
            await Task.Delay((int)delay * 100);

            CurrentPos = tmp_coord;

            return true;
        }

        public BaseUnit(string uName = "Nameless", string uModel = "Nameless", double bTime = 5.0, double uSpeed= 5.0) : base(uModel, bTime)
        {
            Name = uName;
            Speed = uSpeed;
            CurrentPos = new Coordinates();
        }
    }
}
