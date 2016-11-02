using BotFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class BuildableUnit
    {
        public string Model { get; set; }
        public double BuildTime { get; set; }

        public BuildableUnit(string model = "Nameless", double buildTime = 5.0)
        {
            Model = model;
            BuildTime = buildTime;
        }
    }
}
