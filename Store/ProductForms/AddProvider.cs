using DataModel.Entities;
using System;
using System.Windows.Forms;

namespace Store.ProductForms
{
    public partial class AddProvider : Form
    {
        Provider provider;
        public AddProvider(Provider provider)
        {
            InitializeComponent();
            this.provider = provider;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_providername.Text))
            {
                MessageBox.Show("Provider Name is Empty");
                return;
            }
            provider.ProviderName = textBox_providername.Text;
            this.DialogResult=DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
