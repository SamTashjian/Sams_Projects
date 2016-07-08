using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGFBLL;
using SGFData;
using SGFModels;

namespace SGFTests
{
    [TestFixture]
   public class OperationTests
    {
        [Test]
        public void GetAllOrdersByDateTest()
        {
            List <OrderInfo> numberOfOrders = OrderRepoFactory.CreateOrderRepo().GetOrdersByDate(Convert.ToDateTime("01/01/2016"));

            Assert.AreEqual(numberOfOrders.Count, 2);
        }

        [Test]
        public void CreateNewOrderId()
        {
            int expected = 3;

            InMemoryRepo repo = new InMemoryRepo();

            int result = repo.CreateNextOrderNumber(Convert.ToDateTime("01/01/2016"));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RemoveOrder()
        {
            int expected = 1;

            InMemoryRepo repo = new InMemoryRepo();
            var order = repo.GetOneSpecificOrder(DateTime.Parse("01/01/2016"), 1);
             repo.RemoveOrder(order);
            var result = repo.GetOrdersByDate(Convert.ToDateTime("01/01/2016"));

            Assert.AreEqual(expected, result.Count);
        }

    }
}
