using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class R2D2 : WorkingUnit
    {
        public R2D2() : base("Beep", "R2D2", 1.5, 5.5)
        {
            WorkingPos = new Coordinates(2.0, 2.0);
        }
    }
}
