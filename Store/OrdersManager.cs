using Store.Orders;
using Store.Users;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using ErrorAndValidation;
using Unity;
using Interfaces.Logic;
using DataModel.Entities;
using Store.Factories.Interfaces;
using Unity.Attributes;
using Store.ProductForms;

namespace Store
{
    public partial class OrdersManager : Form
    {
        
        private BindingSource ordersBS = new BindingSource();
        private IOrderLogic<Order> orderlogic;
        private IUserLogic<User> userlogic;
        private User currentUser;
        private List<Order> allorders;
        private AutoCompleteStringCollection[] autocomplete = new AutoCompleteStringCollection[6];
        private string DefaultName = "Име";
        private string DefaultFName = "Фамилия";
        private string LoggedLabel = "Logged User : ";
        private string DefaultId = "Номер на поръчка";
        private int InCompleteCount=0;
        private bool SortByDate = true;
        private Thread orderthread;
        private readonly IOrderLogicFactory orderlogicfactory;
        private readonly IUserLogicFactory userlogicfactory;
        [Dependency("productview")]
        public IFormFactory productviewfactory { get;set; }
        [Dependency("manageusers")]
        public IFormFactory manageusersfactory { get; set; }

        public OrdersManager(User currentUser, IOrderLogicFactory orderlogicfactory, IUserLogicFactory userlogicfactory)
        {
            InitializeComponent();
            this.Icon = Store.Properties.Resources.StoreIcon;
            this.currentUser = currentUser;
            this.orderlogicfactory = orderlogicfactory;
            this.userlogicfactory = userlogicfactory;
            if (!currentUser.IsMaster)
            {
                manageusers_strip.Visible = false;
                manageusers_strip.Enabled = false;
                backupstrip.Visible = false;
                backupstrip.Enabled = false;
            }
            loggeduser_label.Text = LoggedLabel + currentUser.Alias;
            textBox_Firstname.Text=DefaultName;
            textBox_Secondname.Text = DefaultFName;
            textBox_Id.Text = DefaultId;
            comboBox_day.SelectedIndex = 0;
            comboBox_month.SelectedIndex = 0;
            comboBox_year.SelectedIndex = 0;
            comboBox_SortBy.SelectedIndex = 1;
            autocomplete[0] = new AutoCompleteStringCollection();
            autocomplete[1] = new AutoCompleteStringCollection();
            autocomplete[2] = new AutoCompleteStringCollection();
            autocomplete[3] = new AutoCompleteStringCollection();
            autocomplete[4] = new AutoCompleteStringCollection();
            autocomplete[5] = new AutoCompleteStringCollection();
            //enable double bufffered
            Type dgvType = datagrid_Orders.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(datagrid_Orders, true, null);
            RefreshItems(true);
        }
        
        private void ViewOrderStart()
        {
            ViewOrder vieworder = new ViewOrder((Order)ordersBS.Current);
            Application.Run(vieworder);
        }

        private void LogError(Exception ex)
        {
            ErrorLogger.Log(ex);
            MessageBox.Show("An Error occured, check log file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Save(Order item)
        {
            try
            {
                using (orderlogic = orderlogicfactory.CreateNew())
                {
                    orderlogic.Add(item);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        private void Edit(Order item)
        {
            try
            {
                using (orderlogic = orderlogicfactory.CreateNew())
                {
                    orderlogic.Edit(item);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        private void FillAutoComplete(Order item)
        {
            autocomplete[0].Add(item.FirstName);
            autocomplete[1].Add(item.LastName);
            autocomplete[2].Add(item.PhoneNumber);
            autocomplete[3].Add(item.Email);
            autocomplete[4].Add(item.TypeOfProduct);
            autocomplete[5].Add(item.PrielPoruchka);
            autocomplete[5].Add(item.IzpulnilPoruchka);
        }
        private void CheckForIncomplete(Order item)
        {
            if (item.OrderStatus == "Приета" || item.OrderStatus == "В процес на изпълнение")
            {
                InCompleteCount++;
            }
        }
        private void RefreshItems(bool? firstinitialize =false)
        {
            InCompleteCount = 0;
            try
            {
                using (orderlogic = orderlogicfactory.CreateNew())
                {
                    if (SortByDate)
                    {
                        allorders = orderlogic.GetOrders(null, o => o.OrderBy(i => i.DateOfOrder), String.Empty, 0);
                    }
                    else allorders = orderlogic.Get();
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
            ordersBS.DataSource = allorders;
            foreach (var item in allorders)
            {
                CheckForIncomplete(item);
                if (firstinitialize == true)
                {
                    FillAutoComplete(item);
                }
            }
            InCompleteOrdersLabel.Text = "Неизпълнени поръчки : " + InCompleteCount.ToString();
            datagrid_Orders.DataSource = ordersBS;
            datagrid_Orders.MultiSelect = false;
            datagrid_Orders.Columns["Id"].DisplayIndex = 0;
            //datagrid_Orders.Refresh();
            GC.Collect();

        }

        private void RefreshItems(List<Order> orders)
        {
            InCompleteCount = 0;
            foreach (var item in orders)
            {
                CheckForIncomplete(item);
            }
            InCompleteOrdersLabel.Text = "Неизпълнени поръчки : " + InCompleteCount.ToString();
            ordersBS.DataSource = orders;
            datagrid_Orders.DataSource = ordersBS;
            datagrid_Orders.Refresh();
            datagrid_Orders.MultiSelect = false;
            GC.Collect();
        }

        private void Search()
        {
            string firstname = textBox_Firstname.Text.Trim();
            string secondname = textBox_Secondname.Text.Trim();
            int Id = 0;
            int Day = 0;
            int Month = 0;
            int Year = 0;
            if (textBox_Id.Text != DefaultId)
            {
                if (int.TryParse(textBox_Id.Text,out Id))
                {
                    
                }
            }
            if (textBox_Firstname.Text == DefaultName)
            {
                firstname = String.Empty;
            }
            if (textBox_Secondname.Text == DefaultFName)
            {
                secondname = String.Empty;
            }
            if (comboBox_day.SelectedIndex != 0)
            {
                Day = int.Parse(comboBox_day.Text);
            }
            if (comboBox_month.SelectedIndex != 0)
            {
                Month = int.Parse(comboBox_month.Text);
            }
            if (comboBox_year.SelectedIndex != 0)
            {
                Year = int.Parse(comboBox_year.Text);
            }
            try
            {
                using (orderlogic = orderlogicfactory.CreateNew())
                {
                    RefreshItems(orderlogic.GetOrders(firstname,secondname,SortByDate,Id,Day,Month,Year));
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        private void datagrid_Orders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ordersBS.Current == null)
            {
                return;
            }
            Order vieworder = (Order)ordersBS.Current;
            orderthread = new Thread(new ThreadStart(ViewOrderStart));
            orderthread.SetApartmentState(ApartmentState.STA);
            orderthread.IsBackground = true;
            orderthread.Start();
        }
        //Create Order
        private void createOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order item = new Order();
            CreateOrder frmCreateOrder = new CreateOrder(item, autocomplete);

            if (frmCreateOrder.ShowDialog() == DialogResult.OK)
            {
                item.PrielPoruchka = currentUser.Alias;
                Save(item);  
                if (SortByDate == true)
                {
                    ordersBS.Insert(0, item);
                }
                else
                {
                    ordersBS.Add(item);
                }
                CheckForIncomplete(item);
                InCompleteOrdersLabel.Text = "Неизпълнени поръчки : " + InCompleteCount.ToString();
                FillAutoComplete(item);
            }
        }

        private void editOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordersBS.Current == null)
            {
                return;
            }
            Order item = (Order)ordersBS.Current;
            bool isCompleted = true;
            if (item.OrderStatus != "Завършена")
            {
                isCompleted = false;
            }

            CreateOrder frmCreateOrder = new CreateOrder(item, autocomplete);

            if (frmCreateOrder.ShowDialog() == DialogResult.OK)
            {
                Edit(item);
                datagrid_Orders.Refresh();
                FillAutoComplete(item);
                if (isCompleted==false)
                {
                    InCompleteCount--;
                    CheckForIncomplete(item);
                }
                else if (isCompleted)
                {
                    CheckForIncomplete(item);
                }
                InCompleteOrdersLabel.Text = "Неизпълнени поръчки : " + InCompleteCount.ToString();
            }
        }

        private void deleteOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordersBS.Current == null)
            {
                return;
            }
            Order item = (Order)ordersBS.Current;

            if (MessageBox.Show("Do you want to delete this Order ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (orderlogic = orderlogicfactory.CreateNew())
                    {
                        orderlogic.Delete(item);
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    MessageBox.Show("An Error occured, check log file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ordersBS.Remove(item);
                if (item.OrderStatus == "Приета" || item.OrderStatus == "В процес на изпълнение")
                {
                    InCompleteCount--;
                    InCompleteOrdersLabel.Text = "Неизпълнени поръчки : " + InCompleteCount.ToString();
                }
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            RefreshItems();
            textBox_Firstname.Text = DefaultName;
            textBox_Secondname.Text = DefaultFName;
            textBox_Id.Text = DefaultId;
            comboBox_day.SelectedIndex = 0;
            comboBox_month.SelectedIndex = 0;
            comboBox_year.SelectedIndex = 0;
        }
        private void textBox_Firstname_MouseLeave(object sender, EventArgs e)
        {
            this.toolTip1.Hide(textBox_Firstname);
        }

        private void textBox_Firstname_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.Show(DefaultName, textBox_Firstname);
        }

        private void textBox_Secondname_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.Show(DefaultFName, textBox_Secondname);
        }

        private void textBox_Secondname_MouseLeave(object sender, EventArgs e)
        {
            this.toolTip1.Hide(textBox_Secondname);
        }
        private void textBox_Id_Enter(object sender, EventArgs e)
        {
            if (textBox_Id.Text == DefaultId)
            {
                textBox_Id.Text = String.Empty;
            }
        }
        private void textBox_Id_Leave(object sender, EventArgs e)
        {
            if (textBox_Id.Text.Trim() == String.Empty)
            {
                textBox_Id.Text = DefaultId;
            }
        }
        private void textBox_Firstname_Enter(object sender, EventArgs e)
        {
            if (textBox_Firstname.Text == DefaultName)
            {
                textBox_Firstname.Text = String.Empty;
            }
        }

        private void textBox_Firstname_Leave(object sender, EventArgs e)
        {
            if (textBox_Firstname.Text.Trim()==String.Empty)
            {
                textBox_Firstname.Text = DefaultName;
            }
        }

        private void textBox_Secondname_Enter(object sender, EventArgs e)
        {
            if (textBox_Secondname.Text==DefaultFName)
            {
                textBox_Secondname.Text = String.Empty;
            }
        }

        private void textBox_Secondname_Leave(object sender, EventArgs e)
        {
            if (textBox_Secondname.Text.Trim()==String.Empty)
            {
                textBox_Secondname.Text = DefaultFName;
            }
        }

        private void completeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordersBS.Current==null)
            {

            }
            else if (((Order)ordersBS.Current).OrderStatus == "Завършена")
            {
                return;
            }
            else
            {
                Order OrderToComplete = (Order)ordersBS.Current;
                OrderToComplete.OrderStatus = "Завършена";
                if (string.IsNullOrEmpty(OrderToComplete.IzpulnilPoruchka))
                {
                    CompleteOrder formComplete = new CompleteOrder(OrderToComplete,autocomplete[5]);
                    if (formComplete.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                Save(OrderToComplete);
                datagrid_Orders.Refresh();
                InCompleteCount--;
                InCompleteOrdersLabel.Text = "Неизпълнени поръчки : " + InCompleteCount.ToString();
            }
        }

        private void comboBox_SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_SortBy.SelectedIndex ==1)
            {
                if (SortByDate == true)
                {
                    return;
                }
                else
                {
                    SortByDate = true;
                    Search();
                }
            }
            else if (comboBox_SortBy.SelectedIndex==0)
            {
                if (SortByDate == false)
                {
                    return;
                }
                else
                {
                    SortByDate = false;
                    Search();
                }
            }
        }

        private void manageusers_strip_Click(object sender, EventArgs e)
        {
            Form manageusersform = manageusersfactory.CreateNew();
            manageusersform.Show();
        }

        private void changeuser_strip_Click(object sender, EventArgs e)
        {
            User usertologin = new User();
            ChangeUser userform = new ChangeUser(usertologin);
            if (userform.ShowDialog()==DialogResult.OK)
            {
                
                using (userlogic = userlogicfactory.CreateNew())
                {
                    usertologin = userlogic.Login(usertologin.Username, usertologin.Password);
                }
                if (usertologin.Id!=0)
                {
                    currentUser = usertologin;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Invalid Username or password", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (currentUser.IsMaster)
                {
                    manageusers_strip.Visible = true;
                    manageusers_strip.Enabled = true;
                    backupstrip.Visible = true;
                    backupstrip.Enabled = true;
                }
                else
                {
                    manageusers_strip.Visible = false;
                    manageusers_strip.Enabled = false;
                    backupstrip.Visible = false;
                    backupstrip.Enabled = false;
                }
                loggeduser_label.Text = LoggedLabel + currentUser.Alias;
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormBackup backupform = new FormBackup();
            backupform.ShowDialog();
        }

        private void textBox_Id_KeyDown(object sender, KeyEventArgs e)
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

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderthread = new Thread(new ThreadStart(ViewProductsStart));
            orderthread.SetApartmentState(ApartmentState.STA);
            orderthread.IsBackground = true;
            orderthread.Start();
        }
        private void ViewProductsStart()
        {
            Form productviewform = productviewfactory.CreateNew();
            Application.Run(productviewform);
        }
    }
}
