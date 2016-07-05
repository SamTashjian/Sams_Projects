using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SGFData
{
    public class ErrorLog
    {
        public static string LogErrors(string message)
        {
            
            using (StreamWriter sw = new StreamWriter("TextFilesRefs\\ErrorsLogged.txt", true))
            {
                sw.WriteLine(message + DateTime.Now);
            }

            return message;
        }
    }
}
