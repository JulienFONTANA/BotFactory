using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }

        public bool Equals(Coordinates obj)
        {
            if ((this.X == obj.X) && (this.Y == obj.Y))
                return true;
            return false;
        }

        public Coordinates(double x = 0.0, double y = 0.0)
        {
            X = x;
            Y = y;
        }
    }
}
