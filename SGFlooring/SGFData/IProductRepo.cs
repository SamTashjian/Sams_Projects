using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SGFModels;

namespace SGFData
{
    public interface IProductRepo
    {
        List<ProductInfo> GetAllProducts();
        ProductInfo GetProductByProductType(string productSearched);
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
            using (StreamReader sr = new StreamReader("TextFilesRefs\\ProductInfo.txt"))
            {
                string[] records = sr.ReadToEnd().Split('\n');
                for(int i = 1; i < records.Length; i++)
                {
                    string record = records[i];
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

        public ProductInfo GetProductByProductType(string productSearched)
        {
            var product = _productInfo.Where(p => p.ProductType == productSearched).FirstOrDefault();

            return product;
        }
    }
}