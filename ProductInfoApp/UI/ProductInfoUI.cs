using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductInfoApp.Model;
using ProductInfoApp.BLL;

namespace ProductInfoApp
{
    public partial class ProductInfoUI : Form
    {
        public ProductInfoUI()
        {
            InitializeComponent();
        }

        private ProductManager manager = new ProductManager();


        private void saveButton_Click(object sender, EventArgs e)
        {

            Product product = new Product();

            product.productCode = productCodeTextBox.Text;
            product.description = descriptionTextBox.Text;
            product.quantity = int.Parse(quantityTextBox.Text);


            string mess = manager.Save(product);

            MessageBox.Show(mess);

        }

        private List<Product> productslist = new List<Product>(); 
        private void showButton_Click(object sender, EventArgs e)
        {
            productslist.Clear();
            productslist = manager.GetAllData();

            
            displayListView.Items.Clear();
            foreach (Product prod in productslist)
            {
              ListViewItem item = new ListViewItem(prod.productId.ToString());

                item.SubItems.Add(prod.productCode);
                item.SubItems.Add(prod.description);
                item.SubItems.Add(prod.quantity.ToString());
                displayListView.Items.Add(item);

            }



        }
    }
}
