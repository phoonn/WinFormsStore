using DataModel.Entities;
using ErrorAndValidation;
using Interfaces.Logic;
using System;
using System.Windows.Forms;

namespace Store.Users
{
    public partial class ManageUsers : Form
    {
        private IUserLogic<User> logic;
        private BindingSource userBs = new BindingSource();

        public ManageUsers(IUserLogic<User> logic)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.StoreIcon;
            this.logic = logic;
            RefreshUsers();
        }
        public void RefreshUsers()
        {
            userBs.DataSource = logic.Get();
            userdatagrid.DataSource = userBs;
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User userToCreate = new User();
            CreateUser createform = new CreateUser(userToCreate);
            if (createform.ShowDialog()== DialogResult.OK)
            {
                try
                {
                    logic.Add(userToCreate);
                    RefreshUsers();
                }
                catch (Exception ex)
                {
                    ErrorLogger.Log(ex);
                    MessageBox.Show("Couldn't create User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userBs.Current==null)
            {
                return;
            }
            User userToCreate = (User)userBs.Current;
            CreateUser createform = new CreateUser(userToCreate);
            if (createform.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    logic.Edit(userToCreate);
                    RefreshUsers();
                }
                catch (Exception ex)
                {
                    ErrorLogger.Log(ex);
                    MessageBox.Show("Couldn't edit User","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userBs.Current == null)
            {
                return;
            }
            User usertodelete = (User)userBs.Current;

            if (MessageBox.Show("Do you want to delete this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                logic.Delete(usertodelete);
                RefreshUsers();
            }
        }
    }
}
