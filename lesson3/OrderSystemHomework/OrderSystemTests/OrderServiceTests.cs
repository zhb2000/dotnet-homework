using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static OrderSystem.RandomOrder;

namespace OrderSystem.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            var service = new OrderService();
            int count = 10;
            for (int i = 1; i <= count; i++)
            {
                service.AddOrder(RandOrder());
            }
            Assert.IsTrue(service.Count() == count);
        }

        [TestMethod()]
        public void ExistsTest()
        {
            var service = new OrderService();
            var order = RandOrder();
            service.AddOrder(order);
            Assert.IsTrue(service.Exists(order));
        }

        [TestMethod()]
        public void ExistsTest1()
        {
            var service = new OrderService();
            var order = RandOrder();
            int id = service.AddOrder(order);
            Assert.IsTrue(service.Exists(id));
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            var service = new OrderService();
            var order = RandOrder();
            int id = service.AddOrder(order);
            service.RemoveOrder(id);
        }

        [TestMethod()]
        public void RemoveOrderTest1()
        {
            var service = new OrderService();
            var order = RandOrder();
            service.AddOrder(order);
            service.RemoveOrder(order);
        }

        [TestMethod()]
        public void GetTest()
        {
            var service = new OrderService();
            var order = RandOrder();
            int id = service.AddOrder(order);
            Assert.IsNotNull(service.Get(id));
            Assert.IsNull(service.Get(12345));
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            var service = new OrderService();
            int count = 10;
            for (int i = 1; i <= count; i++)
            {
                service.AddOrder(RandOrder());
            }
            foreach (var order in service)
            {
                Console.WriteLine(order);
            }
        }

        [TestMethod()]
        public void ExportTest()
        {
            var service = new OrderService();
            int count = 10;
            for (int i = 1; i <= count; i++)
            {
                service.AddOrder(RandOrder());
            }
            service.Export("service.xml");
        }

        [TestMethod()]
        public void ImportTest()
        {
            var service = new OrderService();
            int count = 10;
            for (int i = 1; i <= count; i++)
            {
                service.AddOrder(RandOrder());
            }
            service.Export("service.xml");
            service = OrderService.Import("service.xml");
            Assert.IsTrue(service.Count() == count);
        }
    }
}