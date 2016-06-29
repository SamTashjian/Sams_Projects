using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SGFData
{
    public static class OrderRepoFactory
    {
        public static IOrderRepo CreateOrderRepo()
      
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            IOrderRepo repository;
            switch (mode.ToUpper())
            {
                case "TEST":
                    repository = new InMemoryRepo();
                    break;

                case "PROD":
                    repository = new OrderRepo();
                    break;

                default:
                    throw  new Exception("Not a model");
            }
            return repository;
        }
     

        public static IProductRepo CreateProductRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            IProductRepo repository;
            switch (mode.ToUpper())
            {
                case "TEST":
                    repository = new InMemoryRepo();
                    break;

                case "PROD":
                    repository = new ProductRepo();
                    break;

                default:
                    throw new Exception("Not a model");
            }
            return repository;
        }

        public static IStateTaxInfoRepo CreateStateTaxInfoRepo()
        {

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            IStateTaxInfoRepo repository;

            switch (mode.ToUpper())
            {
                case "TEST":
                    repository = new InMemoryRepo();
                    break;

                case "PROD":
                    repository = new StateTaxInfoRepo();
                    break;

                default:
                    throw new Exception("Not a model");
            }
            return repository;
        }
    }
}
