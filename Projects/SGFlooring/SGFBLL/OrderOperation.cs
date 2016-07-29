using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFData;
using SGFModels;

namespace SGFBLL
{
   public class OrderOperation
    {
        //fairly sure this is not needed
        private readonly IProductRepo _productRepo;
        private static IOrderRepo _orderRepo = OrderRepoFactory.CreateOrderRepo();
        private readonly IStateTaxInfoRepo _stateTaxInfoRepo;

        public OrderOperation()
        {
           var orderRepo = OrderRepoFactory.CreateOrderRepo();
           var productRepo = OrderRepoFactory.CreateProductRepo();
           var stateTaxInfo = OrderRepoFactory.CreateStateTaxInfoRepo();
        }
        public Response<OrderInfo> DisplayOrder(DateTime orderDate)
        {
            var repo = OrderRepoFactory.CreateOrderRepo();

            var responses = new Response<OrderInfo>();

            var orders = repo.GetOrdersByDate(orderDate);

            if (orders == null )
            {
                responses.Success = false;
                responses.Message = "There are no orders for that date.";
            }
            else
            {
                responses.Success = true;
                responses.Data = orders;
            }

            return responses;
        }

       public Response<OrderInfo> CreateNewOrder(OrderInfo order)
       {
                   
            
           
           var response = new Response<OrderInfo>();
           response.Data = new List<OrderInfo>() {_orderRepo.CreateOrder(order)};
           response.Success = true;
           return  response;
       }

       public ProductInfo ShowProductInfo(string productType)
       {
           var repo = OrderRepoFactory.CreateProductRepo();
           var prodInfo = repo.GetProductByProductType(productType);

           return prodInfo;
       }

       public StateTaxInfo ShowStateInfo(string stateName)
       {
           var repo = OrderRepoFactory.CreateStateTaxInfoRepo();
           var stateInfo = repo.GetStateTaxInfoByStateName(stateName);

           return stateInfo;
       }

       public int CreateNewOrderNumber()
       {
            
           var repo = new OrderRepo();
            return repo.CreateNextOrderNumber();

        }

        

       public Response<OrderInfo> RemoveSpecificOrder(OrderInfo orders)
       {
           var response = new Response<OrderInfo>();

           try
           {
               
               
               _orderRepo.RemoveOrder(orders);

               response.Success = true;
               //response.Message = $"You have successfully removed order {orderId} on {date}";
               
           }

           catch (Exception ex)
           {
               ErrorLog.LogErrors(ex.Message);
               response.Success = false;
               response.Message = ex.Message;
           }

           return response;
       }

       public List<OrderInfo> GetAllOrders(DateTime date)
       {
           return _orderRepo.GetOrdersByDate(date);
       }

       public void RiteToFile(OrderInfo orders )
       {
            
           var repo = new OrderRepo();
           repo.EditOrder(orders);
            
       }
        
    }
}
