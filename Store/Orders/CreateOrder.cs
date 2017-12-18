using DataModel.Entities;
using ErrorAndValidation;
using System;
using System.Windows.Forms;

namespace Store.Orders
{
    public partial class CreateOrder : Form
    {
        private Order order;
        public CreateOrder(Order order,AutoCompleteStringCollection[] autocomplete)
        {
            
            this.order = order;
            InitializeComponent();
            this.Icon = Store.Properties.Resources.StoreIcon;
            textbox_Firstname.Text = order.FirstName;
            textbox_Firstname.AutoCompleteCustomSource = autocomplete[0];
            textbox_Secondname.Text = order.LastName;
            textbox_Secondname.AutoCompleteCustomSource = autocomplete[1];
            textbox_Number.Text = order.PhoneNumber;
            textbox_Number.AutoCompleteCustomSource = autocomplete[2];
            textBox_Email.Text = order.Email;
            textBox_Email.AutoCompleteCustomSource = autocomplete[3];
            textBox_Product.Text = order.TypeOfProduct;
            textBox_Product.AutoCompleteCustomSource = autocomplete[4];
            textBox_Izpulnil.Text = order.IzpulnilPoruchka;
            textBox_Izpulnil.AutoCompleteCustomSource = autocomplete[5];
            textBox_serialNum.Text = order.SerialNum;
            textBox_komplktovka.Text = order.Komplektovka;
            textBox_neizpravnost.Text = order.Neizpravnost;
            textBox_zabelejki.Text = order.Zabelejki;
            textBox_workDone.Text = order.WorkDone;
            if (string.IsNullOrEmpty(order.OrderStatus))
            {
                comboBox_Status.SelectedIndex = 0;
            }
            else
            {
                comboBox_Status.SelectedItem = (object)order.OrderStatus;
            }
        }

        public void Save()
        {
            if (String.IsNullOrEmpty(textbox_Firstname.Text.Trim()))
            {
                MessageBox.Show("FirstName is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (String.IsNullOrEmpty(textbox_Secondname.Text.Trim()))
            {
                MessageBox.Show("SecondName is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (String.IsNullOrEmpty(textbox_Number.Text.Trim()))
            {
                MessageBox.Show("Phone Number is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!RegexUtilities.IsValidEmail(textBox_Email.Text))
            {
                MessageBox.Show("Email is Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (String.IsNullOrEmpty(textBox_Product.Text.Trim()))
            {
                MessageBox.Show("Type of product is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBox_Status.SelectedIndex==-1|| comboBox_Status.SelectedItem==null)
            {
                MessageBox.Show("Status is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textBox_neizpravnost.Text.Trim()==string.Empty)
            {
                MessageBox.Show("Попълни полето за неизправност!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            order.FirstName = textbox_Firstname.Text.Trim();
            order.LastName = textbox_Secondname.Text.Trim();
            order.PhoneNumber = textbox_Number.Text.Trim();
            order.Email = textBox_Email.Text.Trim();
            order.TypeOfProduct = textBox_Product.Text.Trim();
            order.OrderStatus = comboBox_Status.SelectedItem.ToString();
            order.SerialNum = textBox_serialNum.Text;
            order.IzpulnilPoruchka = textBox_Izpulnil.Text.Trim();
            order.Komplektovka = textBox_komplktovka.Text;
            order.Neizpravnost = textBox_neizpravnost.Text;
            order.Zabelejki = textBox_zabelejki.Text;
            order.WorkDone = textBox_workDone.Text;
            if (order.DateOfOrder==DateTime.MinValue)
            {
                order.DateOfOrder = DateTime.Now;
            }
            
            this.DialogResult = DialogResult.OK;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        
        private void textbox_Number_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Status.SelectedIndex==0)
            {
                textBox_Izpulnil.Enabled = false;
                textBox_workDone.Enabled = false;
            }
            else
            {
                textBox_Izpulnil.Enabled = true;
                textBox_workDone.Enabled = true;
            }
        }
    }
}
