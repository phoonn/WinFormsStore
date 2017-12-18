using System;
using System.Windows.Forms;
using DataModel.Entities;

namespace Store.Orders
{
    public partial class CompleteOrder : Form
    {
        private Order order;
        public CompleteOrder(Order order,AutoCompleteStringCollection autocomplete)
        {
            InitializeComponent();
            this.Icon = Store.Properties.Resources.StoreIcon;
            this.order = order;
            this.textBox_CompleteOrder.AutoCompleteCustomSource = autocomplete;
            textBox_workDone.Text = order.WorkDone;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            order.IzpulnilPoruchka = textBox_CompleteOrder.Text.Trim();
            order.WorkDone = textBox_workDone.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
