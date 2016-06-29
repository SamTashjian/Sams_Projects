using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using SGFModels;

namespace SGFData
{
    public class InMemoryRepo: IOrderRepo, IProductRepo, IStateTaxInfoRepo
    {
        private static List<OrderInfo> orderList;
        private static List<ProductInfo> productList;
        private static List<StateTaxInfo> stateTaxList;

        static InMemoryRepo()
        {
            orderList = new List<OrderInfo>();
            
            productList = new List<ProductInfo>();

            stateTaxList = new List<StateTaxInfo>();
        }

        public List<OrderInfo> GetOrdersByDate(DateTime orderdate)
        {
            return null;
        }

        public List<ProductInfo> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<StateTaxInfo> GetAllStateTaxInfos()
        {
            throw new NotImplementedException();
        }
    }
}
