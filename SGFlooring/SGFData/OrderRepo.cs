using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFModels;

namespace SGFData
{
    public class OrderRepo : IOrderRepo
    {
        public static List<OrderInfo> OrderInfoList { get; set; }

        static OrderRepo()
        {
            OrderInfoList = new List<OrderInfo>();
        }

        public List<OrderInfo> GetOrdersByDate(DateTime orderdate)
        {
            return OrderInfoList.Where(o => o.OrderDate == orderdate).ToList();
        }


    }
}
