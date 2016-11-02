using BotFactory.Common.Tools;
using BotFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Factories
{
    public interface IUnitFactory
    {
        int QueueCapacity { get; }
        int StorageCapacity { get; }
        int QueueFreeSlots { get; set; }
        int StorageFreeSlots { get; set; }
        bool FactoryIsBuildingFlag { get; set; }
        TimeSpan QueueTime { get; set; }

        event FactoryProgress FactoryProgress;

        List<IFactoryQueueElement> Queue { get; set; }
        List<ITestingUnit> Storage { get; set; }

        bool AddWorkableUnitToQueue(Type model, string name, Coordinates park, Coordinates work);
        void tryBuild();
        Task<bool> BuildWorkableUnit();
    }
}
