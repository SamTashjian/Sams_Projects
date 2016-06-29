using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFData;
using SGFModels;

namespace SGFBLL
{
   public class OrderOperation
    {
       private readonly IProductRepo _productRepo;
       private IOrderRepo _orderRepo;
       private readonly IStateTaxInfoRepo _stateTaxInfoRepo;

       public OrderOperation()
        {

            //TODO: Call Factory to create repos
           // _productRepo = productRepo;
           //_orderRepo = orderRepo;
           //_stateTaxInfoRepo = stateTaxInfoRepo;
           var orderRepo = OrderRepoFactory.CreateOrderRepo();
           var productRepo = OrderRepoFactory.CreateProductRepo();
           var stateTaxInfo = OrderRepoFactory.CreateStateTaxInfoRepo();
        }
        public Response DisplayOrder(DateTime orderDate)
        {
            var repo = OrderRepoFactory.CreateOrderRepo();

            var responses = new Response();

            var orders = repo.GetOrdersByDate(orderDate);

            if (orders == null )
            {
                responses.Success = false;
                responses.Message = "There are no orders for that date.";
            }
            else
            {
                responses.Success = true;
                responses.OrderDetails = orders;
            }

            return responses;
        }
    }
}
