using BotFactory.Common.Tools;
using BotFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Factories
{
    public class FactoryQueueElement : IFactoryQueueElement
    {
        public string Name { get; set; }
        public Type Model { get; set; }
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }

        public FactoryQueueElement(string name, Type model, Coordinates park, Coordinates work)
        {
            Name = name;
            Model = model;
            ParkingPos = park;
            WorkingPos = work;
        }
    }
}
