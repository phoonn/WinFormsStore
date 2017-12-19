using System;
using System.Windows.Forms;
using DataModel.Entities;
using Interfaces.Logic;

namespace Store
{
    public partial class ChangeUser : Form
    {
        private IUserLogic logic;
        private User usertologin;


        public ChangeUser(User usertologin)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.StoreIcon;
            this.usertologin = usertologin;
        }

        

        private void button_login_Click(object sender, EventArgs e)
        {
            usertologin.Username = textBox_Username.Text.Trim();
            usertologin.Password = textBox_Password.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
