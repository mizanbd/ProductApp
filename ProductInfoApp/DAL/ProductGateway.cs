using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using ProductInfoApp.Model;

namespace ProductInfoApp.DAL
{
    class ProductGateway
    {
       string  connection = ConfigurationManager.ConnectionStrings["ConnectionProductDB"].ConnectionString;


        

        public int Save(Product product)
        {

            SqlConnection con = new SqlConnection(connection);

            string quarry = " INSERT INTO t_productInfo VALUES ('" + product.productCode + "','" + product.description +
                            "'," + product.quantity + ") ";


            SqlCommand  command = new SqlCommand(quarry,con);

            con.Open();

            int mess = command.ExecuteNonQuery();

            return mess;


        }

        List<Product >  productlis = new List<Product>();
        public List<Product> GetAllData()
        {
            SqlConnection con = new SqlConnection(connection);

            string quarry = "SELECT * FROM t_productInfo";

            SqlCommand command = new SqlCommand(quarry, con);
            con.Open();

            SqlDataReader aReader = command.ExecuteReader();
          

            while (aReader.Read())
            {
               
                
                   Product product = new Product();
                

                product.productId = int.Parse(aReader["Id"].ToString());

                product.productCode = aReader["Product_Code"].ToString();
                product.description = aReader["Description"].ToString();
                product.quantity = int.Parse(aReader["Quantity"].ToString());
                
                productlis.Add(product);

            }

            aReader.Close();
            con.Close();
            return productlis;


        }

        public Product isExistProduct(string productCode)
        {
            SqlConnection con = new SqlConnection(connection);

            string quarry = "SELECT * FROM t_productInfo WHERE Product_Code = '"+productCode+"'";

            SqlCommand command = new SqlCommand(quarry, con);
            con.Open();

            SqlDataReader aReader = command.ExecuteReader();

            Product product = null;

            while (aReader.Read())
            {
                if (product == null)
                {
                    product = new Product();
                }
  
                product.productId = int.Parse(aReader["Id"].ToString());

                product.productCode = aReader["Product_Code"].ToString();
                product.description = aReader["Description"].ToString();
                product.quantity = int.Parse(aReader["Quantity"].ToString());

              

            }

            aReader.Close();
            con.Close();
            return product;

        }

        public int AddQuantity(int Quantity)
        {
            SqlConnection con = new SqlConnection(connection);

            string quarry = "SELECT SUM(Quantity) as quantity FROM t_productInfo";

            SqlCommand command = new SqlCommand(quarry, con);
            con.Open();

            SqlDataReader aReader = command.ExecuteReader();

          

            while (aReader.Read())
            {
                Quantity = int.Parse(aReader["quantity"].ToString());

            }


            aReader.Close();
            con.Close();
            return Quantity;

        }
    }
}
