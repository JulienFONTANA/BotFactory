using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class T800 : WorkingUnit
    {
        public T800() : base("Arnold", "T800", 3.0, 10.0)
        {
            WorkingPos = new Coordinates(3.0, 3.5);
        }
    }
}
