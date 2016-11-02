using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class WallE : WorkingUnit
    {
        public WallE() : base("Wallace", "WallE", 2.0, 4.0)
        {
            WorkingPos = new Coordinates(5.0, 5.0);
        }
    }
}
