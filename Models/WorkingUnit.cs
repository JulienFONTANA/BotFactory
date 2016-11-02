using BotFactory.Common.Tools;
using BotFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class WorkingUnit : BaseUnit, ITestingUnit
    {
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
        public bool IsWorking { get; set; }

        public virtual async Task<bool> WorkBegins()
        {
            if (IsWorking)
            {
                OnStatusChanged(this, new StatusChangedEventArgs("Already working!"));
                return true;
            }

            IsWorking = true;
            var result = await Move(WorkingPos.X, WorkingPos.Y);
            OnStatusChanged(this, new StatusChangedEventArgs("My work begin!"));
            return result;
        }

        public virtual async Task<bool> WorkEnds()
        {
            if (!IsWorking)
            {
                OnStatusChanged(this, new StatusChangedEventArgs("I'm not working..."));
                return true;
            }

            IsWorking = false;
            var result = await Move(ParkingPos.X, ParkingPos.Y);
            OnStatusChanged(this, new StatusChangedEventArgs("My work finally ends!"));
            return result;
        }

        public WorkingUnit(string uName = "Nameless", string uModel = "Nameless", double uSpeed = 5.0, double BTime = 5.0) : base(uName, uModel, uSpeed, BTime)
        {
            ParkingPos = new Coordinates();
            WorkingPos = new Coordinates();
            IsWorking = false;
        }
    }
}
