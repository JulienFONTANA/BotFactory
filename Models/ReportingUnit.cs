using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit
    {
        public event UnitStatusChanged UnitStatusChanged;
        
        public virtual void OnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            UnitStatusChanged(sender, e);
        }

        public ReportingUnit(string model = "Nameless", double built_time = 5) : base(model, built_time)
        {
            Model = model;
            BuildTime = built_time;
        }
    }
}
