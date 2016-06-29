using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SGFModels;

namespace SGFData
{
    public interface IProductRepo
    {
        List<ProductInfo> GetAllProducts();
    }

    public class ProductRepo : IProductRepo
    {
        private List<ProductInfo> _productInfo;

        public ProductRepo()
        {
            Decode();
        }

        private void Decode()
        {
            _productInfo = new List<ProductInfo>();
            using (StreamReader sr = new StreamReader("ProductInfo.txt"))
            {
                string record = "";
                while ((record = sr.ReadLine()) != null)
                {
                    string[] fields = record.Split(',');
                    ProductInfo temp = new ProductInfo();
                    temp.ProductType = fields[0];
                    temp.CostPerSquareFoot = Convert.ToDecimal(fields[1]);
                    temp.LaborCostPerSquareFoot = Convert.ToDecimal(fields[2]);
                    _productInfo.Add(temp);


                }
            }
        }

        public List<ProductInfo> GetAllProducts()
        {
            return _productInfo;
        }
    }
}