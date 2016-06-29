using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFModels
{
   public class OrderInfo
    {
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int OrderId { get; set; }
        public int Area { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal MaterialCost { get; set; }
    }
}
