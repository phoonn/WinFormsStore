using ErrorAndValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class ManageConnections : Form
    {
        private string defaultconnection = @"Server=localhost\SQLEXPRESS;Database=StoreDB;Trusted_Connection=yes;";
        private string xmlpath = Directory.GetCurrentDirectory() + "\\Store.exe.config";
        private string currentconnection = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        public ManageConnections()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.StoreIcon;
        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            try
            {
                string newip = textBox_Ip.Text;
                string newconnection = null;
                if (String.IsNullOrEmpty(textBox_port.Text.Trim()))
                {
                    newconnection = @"Server=" + newip + @"\SQLEXPRESS;Database=StoreDB;Trusted_Connection=yes;";
                }
                else
                {
                    newconnection = @"Server=" + newip + @"\SQLEXPRESS,"+textBox_port.Text +";Database=StoreDB;Trusted_Connection=yes;";
                }
                
                string oldfile = File.ReadAllText(xmlpath);
                string newfile = oldfile.Replace(currentconnection, newconnection);
                File.WriteAllText(xmlpath, newfile, Encoding.UTF8);
                currentconnection = newconnection;
                MessageBox.Show("Connection changed","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex);
                MessageBox.Show("Couldnt change connection string", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_default_Click(object sender, EventArgs e)
        {
            try
            {
                string oldfile = File.ReadAllText(xmlpath);
                string newfile = oldfile.Replace(currentconnection, defaultconnection);
                File.WriteAllText(xmlpath, newfile, Encoding.UTF8);
                currentconnection = defaultconnection;
                MessageBox.Show("Connection changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex);
                MessageBox.Show("Couldnt change connection string", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Leave empty if not needed", textBox_port);
        }

        private void textBox_port_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox_port);
        }
    }
}
