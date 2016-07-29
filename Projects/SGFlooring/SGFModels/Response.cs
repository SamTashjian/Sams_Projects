using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFModels
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        //generic so that I can just specify either order info, product info, or state info
        public List<T> Data { get; set; }
    }
    
}
