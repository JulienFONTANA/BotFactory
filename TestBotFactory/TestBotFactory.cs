using System;
using BotFactory.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotFactory.Factories;
using BotFactory.Common.Tools;
using System.Threading.Tasks;
using BotFactory.Interfaces;

namespace TestBotFactory
{
    [TestClass]
    public class TestBotFactory
    {
        WorkingUnit WU1 = new WorkingUnit("Bob", "R2D2", 3.0, 9.0);
        WorkingUnit WU2 = new WorkingUnit("Paul", "HAL", 4.0, 6.0);
        WorkingUnit WU3 = new WorkingUnit("Pierre", "T-800", 1.5, 3.0);

        HAL hal = new HAL();
        T800 t800 = new T800();
        R2D2 r2d2 = new R2D2();
        WallE wall = new WallE();

        Coordinates park = new Coordinates();
        Coordinates work = new Coordinates(2, 3);

        UnitFactory UF = new UnitFactory(2, 5);

        #region WorkingUnit_Tests
        [TestMethod]
        public void WorkingUnit_Move()
        {
            Coordinates testcoord = new Coordinates(5.0, 3.0);

            Task.Run(async () =>
            {
                await WU1.Move(5.0, 3.0);
            }).GetAwaiter().GetResult();

            if (!WU1.CurrentPos.Equals(testcoord))
                Assert.Fail();
        }

        [TestMethod]
        public void WorkingUnit_WorkBegin()
        {
            WU1.WorkingPos = work;

            Task.Run(async () =>
            {
                await WU1.WorkBegins();
            }).GetAwaiter().GetResult();

            if (!WU1.CurrentPos.Equals(work))
                Assert.Fail();
        }

        [TestMethod]
        public void WorkingUnit_WorkBegin_WorkEnd()
        {
            WU1.WorkingPos = work;

            Task.Run(async () =>
            {
                await WU1.WorkBegins();
                await WU1.WorkEnds();
            }).GetAwaiter().GetResult();

            if (!WU1.CurrentPos.Equals(park))
                Assert.Fail();
        }

        [TestMethod]
        public void WorkingUnit_WorkBeginTwice()
        {
            WU1.WorkingPos = work;

            Task.Run(async () =>
            {
                await WU1.WorkBegins();
                await WU1.WorkBegins();
            }).GetAwaiter().GetResult();

            if (!WU1.CurrentPos.Equals(work))
                Assert.Fail();
        }

        [TestMethod]
        public void WorkingUnit_WorkEnd_Twice()
        {
            WU1.WorkingPos = work;

            Task.Run(async () =>
            {
                await WU1.WorkEnds();
                await WU1.WorkEnds();
            }).GetAwaiter().GetResult();

            if (!WU1.CurrentPos.Equals(park))
                Assert.Fail();
        }
        #endregion

        #region Queue_Tests
        //[TestMethod]
        //public void QueueCreationTest()
        //{
        //    Type model = WU1.Model.GetType();
        //    string name = WU1.Name;
        //    Task<bool> x = UF.AddWorkableUnitToQueue(model, name, park, work);

        //    model = WU2.Model.GetType();
        //    name = WU2.Name;
        //    x = UF.AddWorkableUnitToQueue(model, name, park, work);

        //    model = WU3.Model.GetType();
        //    name = WU3.Name;
        //    x = UF.AddWorkableUnitToQueue(model, name, park, work);
        //}

        //[TestMethod]
        //public void QueueNotEmpty_AddWorkableUnitToQueue()
        //{
        //    Type model = WU1.Model.GetType();
        //    string name = WU1.Name;

        //    Task.Run(async () =>
        //    {
        //        await UF.AddWorkableUnitToQueue(model, name, park, work);
        //    }).GetAwaiter().GetResult();

        //    if (UF.Queue.Count == 0)
        //        Assert.Fail();
        //}

        [TestMethod]
        public void QueueNotEmpty_DirectQueueAdd()
        {
            FactoryQueueElement fqe = new FactoryQueueElement(WU1.Name, WU1.Model.GetType(), park, work);
            UF.Queue.Add(fqe);

            if (UF.Queue.Count == 0)
                Assert.Fail();
        }

        [TestMethod]
        public void QueueElement_ElementTest_Direct_1Elem()
        {
            FactoryQueueElement fqe = new FactoryQueueElement(WU1.Name, WU1.Model.GetType(), park, work);
            UF.Queue.Add(fqe);

            FactoryQueueElement fqe2 = UF.Queue[0] as FactoryQueueElement;
            Assert.AreEqual(fqe, fqe2);
        }

        [TestMethod]
        public void QueueElement_ElementTest_Direct_2Elem()
        {
            FactoryQueueElement fqe = new FactoryQueueElement(WU1.Name, WU1.Model.GetType(), park, work);
            UF.Queue.Add(fqe);

            fqe.Name = WU2.Name;
            fqe.Model = WU2.Model.GetType();
            UF.Queue.Add(fqe);

            FactoryQueueElement fqe2 = UF.Queue[1] as FactoryQueueElement;
            Assert.AreEqual(fqe, fqe2);
        }

        //[TestMethod]
        //public void QueueElement_ElementTest_AddWorkableUnitToQueue()
        //{
        //    Type model = WU1.Model.GetType();
        //    string name = WU1.Name;

        //    Type model2 = WU2.Model.GetType();
        //    string name2 = WU2.Name;

        //    Task.Run(async () =>
        //    {
        //        await UF.AddWorkableUnitToQueue(model, name, park, work);
        //        await UF.AddWorkableUnitToQueue(model2, name2, park, work);
        //    }).GetAwaiter().GetResult();

        //    FactoryQueueElement fqe1 = UF.Queue[0] as FactoryQueueElement;
        //    FactoryQueueElement fqe2 = UF.Queue[1] as FactoryQueueElement;
        //    Assert.AreEqual(fqe1.Model, fqe2.Model);
        //}
        #endregion

        #region StorageBuild_Tests
        //[TestMethod]
        //public void StorageTest_DirectAdd()
        //{
        //    Type model = hal.GetType();
        //    string name = hal.Name;

        //    Task.Run(async () =>
        //    {
        //        await UF.AddWorkableUnitToQueue(model, name, park, work);
        //    }).GetAwaiter().GetResult();

        //    object unit = Activator.CreateInstance(UF.Queue[0].Model);
        //    ITestingUnit itu = unit as ITestingUnit;
        //    UF.Storage.Add(itu);

        //    if (UF.Storage.Count == 0)
        //        Assert.Fail();
        //}

        //[TestMethod]
        //public void StorageTest_ComplexAdd()
        //{
        //    Type model1 = hal.GetType();
        //    Type model2 = r2d2.GetType();
        //    Type model3 = t800.GetType();
        //    Type model4 = wall.GetType();
        //    string name1 = hal.Name;
        //    string name2 = r2d2.Name;
        //    string name3 = t800.Name;
        //    string name4 = wall.Name;

        //    Task.Run(async () =>
        //    {
        //        await UF.AddWorkableUnitToQueue(model1, name1, park, work);
        //        await UF.AddWorkableUnitToQueue(model2, name2, park, work);
        //        await UF.AddWorkableUnitToQueue(model3, name3, park, work);
        //        await UF.AddWorkableUnitToQueue(model4, name4, park, work);
        //    }).GetAwaiter().GetResult();

        //    foreach (var item in UF.Queue)
        //    {
        //        object unit = Activator.CreateInstance(item.Model);
        //        ITestingUnit itu = unit as ITestingUnit;
        //        UF.Storage.Add(itu);
        //    }

        //    if (UF.Storage.Count == 0)
        //        Assert.Fail();
        //}

        //[TestMethod]
        //public void StorageTest_SimpleBuildTest()
        //{
        //    Type model1 = hal.GetType();
        //    Type model2 = r2d2.GetType();
        //    Type model3 = t800.GetType();
        //    Type model4 = wall.GetType();
        //    string name1 = hal.Name;
        //    string name2 = r2d2.Name;
        //    string name3 = t800.Name;
        //    string name4 = wall.Name;

        //    Task.Run(async () =>
        //    {
        //        await UF.AddWorkableUnitToQueue(model1, name1, park, work);
        //        await UF.AddWorkableUnitToQueue(model2, name2, park, work);
        //        await UF.AddWorkableUnitToQueue(model3, name3, park, work);
        //        await UF.AddWorkableUnitToQueue(model4, name4, park, work);
        //        await UF.BuildWorkableUnit();
        //        await UF.BuildWorkableUnit();
        //        await UF.BuildWorkableUnit();
        //        await UF.BuildWorkableUnit();
        //    }).GetAwaiter().GetResult();

        //    if (UF.Storage.Count == 0)
        //        Assert.Fail();
        //}
        #endregion
    }
}
