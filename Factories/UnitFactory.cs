using BotFactory.Common.Tools;
using BotFactory.Interfaces;
using BotFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotFactory.Factories
{
    public class UnitFactory : IUnitFactory
    {
        private readonly int _queueCapacity;
        private readonly int _storageCapacity;
        public int QueueFreeSlots { get; set; }
        public int StorageFreeSlots { get; set; }
        public bool FactoryIsBuildingFlag { get; set; }
        public TimeSpan QueueTime { get; set; }
        public List<IFactoryQueueElement> Queue { get; set; }
        public List<ITestingUnit> Storage { get; set; }
        public event FactoryProgress FactoryProgress;

        public int QueueCapacity { get { return _queueCapacity; } }
        public int StorageCapacity { get { return _storageCapacity; } }


        public bool AddWorkableUnitToQueue(Type model, string name, Coordinates park, Coordinates work)
        {
            StorageFreeSlots = StorageCapacity - Storage.Count;   // Storage slots left
            QueueFreeSlots = QueueCapacity - Queue.Count;         // Queue slots left
            int freeSlotsLeft = StorageFreeSlots - Queue.Count;   // Slots that can still be taken

            if ((StorageFreeSlots <= 0) || (QueueFreeSlots <= 0) || (freeSlotsLeft <= 0))
            {
                FactoryProgress(this, new StatusChangedEventArgs("ERROR : No more free slots."));
                return false;
            }
            else
            {
                Queue.Add(new FactoryQueueElement(name, model, park, work));
                FactoryProgress(Queue.First(), new StatusChangedEventArgs("New robot was added to Queue."));

                tryBuild();

                return true;
            }
        }

        public void tryBuild()
        {
            if (FactoryIsBuildingFlag || (StorageFreeSlots <= 0) || (QueueFreeSlots <= 0))
            {
                return;
            }

            Task.Run(async () =>
            {
                FactoryIsBuildingFlag = true;
                while (Queue.Count != 0)
                {
                    bool builded = await BuildWorkableUnit();
                }
                FactoryProgress(this, new StatusChangedEventArgs("Robot creation completed."));
                FactoryIsBuildingFlag = false;
            });
        }


        public async Task<bool> BuildWorkableUnit()
        {
            if (Queue.Count == 0)
            {
                FactoryProgress(this, new StatusChangedEventArgs("ERROR : Queue is empty."));
                return false;
            }

            WorkingUnit unitToBeAdded = Activator.CreateInstance(Queue.First().Model) as WorkingUnit;
            unitToBeAdded.Name = Queue.First().Name;
            //unitToBeAdded.ParkingPos = Queue.First().ParkingPos;
            //unitToBeAdded.WorkingPos = Queue.First().WorkingPos;
            Queue.Remove(Queue.First());

            QueueTime = TimeSpan.FromSeconds(unitToBeAdded.BuildTime);
            await Task.Delay(QueueTime);

            FactoryProgress(unitToBeAdded, new StatusChangedEventArgs("New robot was created and was added to Storage. It is ready to be tested."));
            Storage.Add(unitToBeAdded);

            return true;
        }

        public UnitFactory(int queueCap, int storageCap)
        {
            _queueCapacity = QueueFreeSlots = queueCap;
            _storageCapacity = StorageFreeSlots = storageCap;

            Queue = new List<IFactoryQueueElement>();
            Storage = new List<ITestingUnit>();

            FactoryIsBuildingFlag = false;
        }
    }
}
