using System;
using System.Collections.Generic;
using SGFModels;

namespace SGFData
{
    public interface IOrderRepo
    {
        List<OrderInfo> GetOrdersByDate(DateTime orderdate);
      OrderInfo GetOneSpecificOrder(DateTime orderdate, int orderId);
        OrderInfo CreateOrder(OrderInfo order);
       void RemoveOrder(OrderInfo orderInfo);
        void EditOrder(OrderInfo orders);
    }
}