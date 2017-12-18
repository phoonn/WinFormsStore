using DataModel.Entities;
using System;
using System.Windows.Forms;

namespace Store.Users
{
    public partial class CreateUser : Form
    {
        private User UserToCreate;
        public CreateUser(User UserToCreate)
        {
            this.UserToCreate = UserToCreate;
            InitializeComponent();
            this.Icon = Properties.Resources.StoreIcon;
            textBox_username.Text = this.UserToCreate.Username;
            textBox_password.Text = this.UserToCreate.Password;
            if (this.UserToCreate.IsMaster)
            {
                checkBox_admin.CheckState = CheckState.Checked;
            }
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text.Trim()==String.Empty)
            {
                MessageBox.Show("Enter a Username","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (textBox_password.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Enter a Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (textBox_Alias.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Enter an Alias", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                UserToCreate.Username = textBox_username.Text.Trim();
                UserToCreate.Password = textBox_password.Text.Trim();
                UserToCreate.Alias = textBox_Alias.Text.Trim();
                if (checkBox_admin.CheckState == CheckState.Checked)
                {
                    UserToCreate.IsMaster = true;
                }
                else
                    UserToCreate.IsMaster = false;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
