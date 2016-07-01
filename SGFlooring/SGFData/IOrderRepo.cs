using System;
using System.Collections.Generic;
using SGFModels;

namespace SGFData
{
    public interface IOrderRepo
    {
        List<OrderInfo> GetOrdersByDate(DateTime orderdate);
        OrderInfo CreateOrder(OrderInfo order);
    }
}