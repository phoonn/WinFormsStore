using DataModel.Entities;
using ErrorAndValidation;
using System;
using System.Windows.Forms;

namespace Store.Orders
{
    public partial class ViewOrder : Form
    {
        private Order order;
        public ViewOrder(Order order)
        {
            this.order = order;
            InitializeComponent();
            this.Icon = Store.Properties.Resources.StoreIcon;
            textbox_Firstname.Text = order.FirstName;
            textbox_Secondname.Text = order.LastName;
            textbox_Number.Text = order.PhoneNumber;
            textBox_Email.Text = order.Email;
            textBox_Product.Text = order.TypeOfProduct;
            textBox_status.Text = order.OrderStatus;
            textBox_Date.Text = order.DateOfOrder.ToString() ;
            textBox_Izpulnil.Text = order.IzpulnilPoruchka;
            textBox_Priel.Text = order.PrielPoruchka;
            textBox_serialNum.Text = order.SerialNum;
            textBox_komplktovka.Text = order.Komplektovka;
            textBox_neizpravnost.Text = order.Neizpravnost;
            textBox_zabelejki.Text = order.Zabelejki;
            textBox_workDone.Text = order.WorkDone;
        }


        private void button_report_Click(object sender, EventArgs e)
        {
            try
            {
                ReportViewerForm reportviewer = new ReportViewerForm(order);
                reportviewer.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex);
                MessageBox.Show("Couldn't load report, check Log file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GC.Collect();
        }

        private void ViewOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            Application.ExitThread();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
