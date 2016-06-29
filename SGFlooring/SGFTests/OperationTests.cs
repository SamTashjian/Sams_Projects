using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGFBLL;
using SGFData;

namespace SGFTests
{
    [TestFixture]
    class OperationTests
    {
        [Test]
        public void ShouldBeAbleToAddOrder()
        {
            IProductRepo productRepo = OrderRepoFactory.CreateProductRepo();
            IOrderRepo orderRepo = OrderRepoFactory.CreateOrderRepo();
            IStateTaxInfoRepo stateTaxInfoRepo = OrderRepoFactory.CreateStateTaxInfoRepo();
            

        }
    }
}
