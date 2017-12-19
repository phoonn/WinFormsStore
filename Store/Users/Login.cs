using System;
using System.Threading;
using System.Windows.Forms;
using ErrorAndValidation;
using Unity;
using Unity.Resolution;
using Interfaces.Logic;
using DataModel.Entities;
using Store.Factories.Interfaces;

namespace Store
{
    public partial class Login : Form
    {
        private User currentUser;
        private readonly IUserLogic logic;
        private readonly IOrdersManagerFactory factory;
        public Login(IOrdersManagerFactory factory, IUserLogic logic)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.StoreIcon;
            this.factory = factory;
            this.logic = logic;
        }

        private void StartMainThread()
        {
            Form MainForm = factory.CreateNew(currentUser);
            Application.Run(MainForm);
        }

        private void ThreadCreate()
        {
            Thread MainThread = new Thread(new ThreadStart(StartMainThread));
            MainThread.SetApartmentState(ApartmentState.STA);
            MainThread.IsBackground = false;
            MainThread.Start();
            logic.Dispose();
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string Username = textBox_Username.Text.Trim();
            string Password = textBox_Password.Text.Trim();
            try
            {
                currentUser = logic.Login(Username, Password);
                if (currentUser != null)
                {
                    ThreadCreate();
                }
                else
                    MessageBox.Show("Invalid Username or password", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex);
                MessageBox.Show("Failed to establish connection with database, error written to log file.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageConnections managecon = new ManageConnections();
            if (managecon.ShowDialog()==DialogResult.OK)
            {
                Application.Restart();
            }
        }
    }
}
