using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Warmups
{
   public class Loops
    {
       public string StringTimes(string str, int n)
       {
           string result = "";

           for (int i = 0; i < n; i++)
           {
               result += str;
           }

           return result;
       }


       public string FrontTimes(string str, int n)
       {
           string result = "";

           for (int i = 0; i < n; i++)
           {
               result += str.Substring(0, 3);
           }

           return result;
       }


    }
}
