using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Length { get; set; }

        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            if (begin.Equals(end))
            {
                Vector zero_vector = new Vector(begin.X, begin.Y, 0);
                return zero_vector;
            }
            Vector v = new Vector((end.X - begin.X), // X
                                  (end.Y - begin.Y), // Y
                                  (Math.Sqrt(Math.Pow((end.X - begin.X), 2) + Math.Pow((end.Y - begin.Y), 2)))); // Length
            return v;
        }

        public Vector(double x = 0.0, double y = 0.0, double len = 0.0)
        {
            X = x;
            Y = y;
            Length = len;
        }
    }
}
