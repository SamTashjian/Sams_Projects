using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFModels
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<OrderInfo> OrderDetails { get; set; }
        public ProductInfo ProductDetails { get; set; }
        public StateTaxInfo StateTaxDetails { get; set; }
    }
}
