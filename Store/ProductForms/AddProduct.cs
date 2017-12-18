using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

namespace Store.ProductForms

{
    public partial class AddProduct : Form
    {
        private Product product;
        private List<ProductType> producttypelist;
        private List<string> seriallist = new List<string>();
        private List<Provider> providerlist;
        private string defaultcombobox = "---";
        
        public AddProduct(Product product,List<ProductType>producttypelist,List<string> seriallist,List<Provider> providerlist)
        {
            this.product = product;
            this.producttypelist = producttypelist;
            this.seriallist = seriallist;
            this.providerlist = providerlist;
            InitializeComponent();
            comboBox_providers.Items.Add(defaultcombobox);
            foreach (var item in providerlist)
            {
                comboBox_providers.Items.Add(item.ProviderName);
            }
            AutoCompleteStringCollection typeauto = new AutoCompleteStringCollection();
            foreach (var item in producttypelist)
            {
                typeauto.Add(item.Type);
            }
            textBox_type.AutoCompleteCustomSource = typeauto;
            comboBox_providers.SelectedIndex = 0;
            if (product.Id != 0)
            {
                textBox_name.Text = product.ProductName;
                textBox_number.Text = product.Number;
                textBox_type.Text = producttypelist.Where(i => i.Id == product.ProductTypeId).First().Type;
                textBox_quantity.Text = product.Quantity.ToString();
                textBox_paidprice.Text = product.PricePaid.ToString();
                textBox_price.Text = product.PriceWithoutVat.ToString();
                textBox_fullprice.Text = product.Price.ToString();
                this.Text = "Редактиране на продукт";
                comboBox_providers.SelectedItem =providerlist.Where(i=>i.Id==product.ProviderId).First().ProviderName;
            }
        }

        private void button_done_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_name.Text)|| String.IsNullOrEmpty(textBox_number.Text) ||
                String.IsNullOrEmpty(textBox_paidprice.Text)|| String.IsNullOrEmpty(textBox_quantity.Text)
                || String.IsNullOrEmpty(textBox_type.Text)|| comboBox_providers.SelectedIndex==0)
            {
                MessageBox.Show("Some of the textboxes are empty","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                int quantity = 0;
                double pricepaid = 0, pricewithoutvat = 0,fullprice=0;
                Double.TryParse(textBox_paidprice.Text, out pricepaid);
                Double.TryParse(textBox_price.Text, out pricewithoutvat);
                Double.TryParse(textBox_fullprice.Text, out fullprice);
                int.TryParse(textBox_quantity.Text, out quantity);
                product.Number = textBox_number.Text;
                product.ProductName = textBox_name.Text;
                product.Price = fullprice;
                product.PriceWithoutVat = pricewithoutvat;
                product.PricePaid = pricepaid;
                product.Quantity = quantity;
                product.ProductTypeName = textBox_type.Text;
                product.ProviderName = comboBox_providers.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            int count = 0;
            int.TryParse(textBox_quantity.Text, out count);
            if (count==0)
            {
                MessageBox.Show("Quantity is 0","Set Quantity",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (count<seriallist.Count)
            {
                seriallist.RemoveRange(count, seriallist.Count-1);
            }
            SerialNumbers serialnumsform = new SerialNumbers(seriallist, count);
            if (serialnumsform.ShowDialog()==DialogResult.OK)
            {
                textBox_quantity.Text = seriallist.Count.ToString();
            }
        }

        private void textBox_quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }

        private void textBox_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }

        private void textBox_fullprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }

        private void textBox_price_KeyUp(object sender, KeyEventArgs e)
        {
            float price = 0;
            float.TryParse(textBox_price.Text, out price);
            price = price * 1.2f;
            textBox_fullprice.Text = price.ToString();
        }
    }
}
