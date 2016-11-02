using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class HAL : WorkingUnit
    {
        public HAL() : base("Pal", "HAL", 0.5, 7.0)
        {
            WorkingPos = new Coordinates(1.0, 1.0); 
        }
    }
}
