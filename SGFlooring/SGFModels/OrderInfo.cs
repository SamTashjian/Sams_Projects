using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFModels
{
   public class OrderInfo
    {
        public ProductInfo ProductInfo { get; set; }
        public StateTaxInfo StateTaxInfo { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int OrderId { get; set; }
        public decimal Area { get; set; }
        public decimal Tax { get; set; }
        public decimal LaborCost
       {
           get { return Area*ProductInfo.LaborCostPerSquareFoot;}
       }
       public decimal MaterialCost
       {
           get { return Area*ProductInfo.CostPerSquareFoot;}
       }
       public decimal Total
       {
            get { return (MaterialCost + LaborCost)  /* * Tax*/;}
       }

       public OrderInfo()
       {
           ProductInfo = new ProductInfo();
           StateTaxInfo = new StateTaxInfo();
       }
    }

}
