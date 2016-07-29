using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBsnk.Data
{
    public static class AccountRepositoryFactory
    {
        public static AccountRepository CreateAccountRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            AccountRepository repo;
            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new InMemoryRepository();
                    break;
                case "PROD":
                    repo = new FileRepository();
                    break;
                default:
                    throw new Exception("I don't know that mode!");
            }

            return repo;
        }
    }
}
