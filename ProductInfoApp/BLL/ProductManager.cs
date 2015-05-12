using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInfoApp.Model;
using ProductInfoApp.DAL;

namespace ProductInfoApp.BLL
{
    class ProductManager
    {
        ProductGateway gateway = new ProductGateway();
        public string Save(Product product)
        {
            if (product.productCode.Count() > 3)
            {
                bool isExistproduct = isExistProduct(product.productCode);

                if (isExistproduct)
                {
                    int mess= gateway.AddQuantity(product.quantity);

                    if (mess > 0)
                    {
                        return "Product Quantity update successfully.";
                    }
                    else
                    {
                        return " Product Quantity not updated.";
                    }
                    
                }
                else
                {

                    int mess = gateway.Save(product);

                    if (mess > 0)
                    {
                        return "Data Save Successfully";
                    }
                    else
                    {
                        return "Data not saved";
                    }

                }

            }
            else
            {
                return "Enter More Then 3 Character.";
            }

            


            
        }

        private bool isExistProduct(string productCode)
        {

           Product product  = gateway.isExistProduct(productCode);

            if (product != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<Product> GetAllData()
        {
            return gateway.GetAllData();
        }
    }
}
