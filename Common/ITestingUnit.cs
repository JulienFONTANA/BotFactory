using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Interfaces
{
    public interface ITestingUnit
    {
        string Name { get; set; }
        double Speed { get; set; }
        bool IsWorking { get; set; }
        double BuildTime { get; set; }
        string Model { get; set; }

        Coordinates CurrentPos { get; set; }
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }

        Task<bool> Move(double x, double y);
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();

        event UnitStatusChanged UnitStatusChanged;
    }
}
