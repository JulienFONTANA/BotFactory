using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class StatusChangedEventArgs : EventArgs
    {
        public string NewStatus;

        public StatusChangedEventArgs(string ns)
        {
            NewStatus = ns;
        }
    }
}
