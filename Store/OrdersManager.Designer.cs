namespace Store
{
    partial class OrdersManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.datagrid_Orders = new System.Windows.Forms.DataGridView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeuser_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.manageusers_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.backupstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Firstname = new System.Windows.Forms.TextBox();
            this.textBox_Secondname = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.InCompleteOrdersLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loggeduser_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_SortBy = new System.Windows.Forms.ComboBox();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.comboBox_day = new System.Windows.Forms.ComboBox();
            this.textBox_Id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_Orders)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagrid_Orders
            // 
            this.datagrid_Orders.AllowUserToAddRows = false;
            this.datagrid_Orders.AllowUserToDeleteRows = false;
            this.datagrid_Orders.AllowUserToOrderColumns = true;
            this.datagrid_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_Orders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrid_Orders.Location = new System.Drawing.Point(0, 48);
            this.datagrid_Orders.Name = "datagrid_Orders";
            this.datagrid_Orders.ReadOnly = true;
            this.datagrid_Orders.Size = new System.Drawing.Size(1119, 309);
            this.datagrid_Orders.TabIndex = 1;
            this.datagrid_Orders.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagrid_Orders_CellMouseDoubleClick);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Location = new System.Drawing.Point(0, 24);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1119, 24);
            this.menuStrip2.TabIndex = 6;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createOrderToolStripMenuItem,
            this.editOrderToolStripMenuItem,
            this.deleteOrderToolStripMenuItem,
            this.completeOrderToolStripMenuItem,
            this.changeuser_strip,
            this.manageusers_strip,
            this.backupstrip,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1119, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createOrderToolStripMenuItem
            // 
            this.createOrderToolStripMenuItem.Name = "createOrderToolStripMenuItem";
            this.createOrderToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.createOrderToolStripMenuItem.Text = "Create Order";
            this.createOrderToolStripMenuItem.Click += new System.EventHandler(this.createOrderToolStripMenuItem_Click);
            // 
            // editOrderToolStripMenuItem
            // 
            this.editOrderToolStripMenuItem.Name = "editOrderToolStripMenuItem";
            this.editOrderToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.editOrderToolStripMenuItem.Text = "Edit Order";
            this.editOrderToolStripMenuItem.Click += new System.EventHandler(this.editOrderToolStripMenuItem_Click);
            // 
            // deleteOrderToolStripMenuItem
            // 
            this.deleteOrderToolStripMenuItem.Name = "deleteOrderToolStripMenuItem";
            this.deleteOrderToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.deleteOrderToolStripMenuItem.Text = "Delete Order";
            this.deleteOrderToolStripMenuItem.Click += new System.EventHandler(this.deleteOrderToolStripMenuItem_Click);
            // 
            // completeOrderToolStripMenuItem
            // 
            this.completeOrderToolStripMenuItem.Name = "completeOrderToolStripMenuItem";
            this.completeOrderToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.completeOrderToolStripMenuItem.Text = "Complete Order";
            this.completeOrderToolStripMenuItem.Click += new System.EventHandler(this.completeOrderToolStripMenuItem_Click);
            // 
            // changeuser_strip
            // 
            this.changeuser_strip.Name = "changeuser_strip";
            this.changeuser_strip.Size = new System.Drawing.Size(86, 20);
            this.changeuser_strip.Text = "Change User";
            this.changeuser_strip.Click += new System.EventHandler(this.changeuser_strip_Click);
            // 
            // manageusers_strip
            // 
            this.manageusers_strip.Name = "manageusers_strip";
            this.manageusers_strip.Size = new System.Drawing.Size(93, 20);
            this.manageusers_strip.Text = "Manage Users";
            this.manageusers_strip.Click += new System.EventHandler(this.manageusers_strip_Click);
            // 
            // backupstrip
            // 
            this.backupstrip.Name = "backupstrip";
            this.backupstrip.Size = new System.Drawing.Size(58, 20);
            this.backupstrip.Text = "Backup";
            this.backupstrip.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.productsToolStripMenuItem.Text = "Products";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // textBox_Firstname
            // 
            this.textBox_Firstname.Location = new System.Drawing.Point(116, 27);
            this.textBox_Firstname.Name = "textBox_Firstname";
            this.textBox_Firstname.Size = new System.Drawing.Size(100, 20);
            this.textBox_Firstname.TabIndex = 8;
            this.textBox_Firstname.Enter += new System.EventHandler(this.textBox_Firstname_Enter);
            this.textBox_Firstname.Leave += new System.EventHandler(this.textBox_Firstname_Leave);
            this.textBox_Firstname.MouseEnter += new System.EventHandler(this.textBox_Firstname_MouseEnter);
            this.textBox_Firstname.MouseLeave += new System.EventHandler(this.textBox_Firstname_MouseLeave);
            // 
            // textBox_Secondname
            // 
            this.textBox_Secondname.Location = new System.Drawing.Point(222, 27);
            this.textBox_Secondname.Name = "textBox_Secondname";
            this.textBox_Secondname.Size = new System.Drawing.Size(100, 20);
            this.textBox_Secondname.TabIndex = 9;
            this.textBox_Secondname.Enter += new System.EventHandler(this.textBox_Secondname_Enter);
            this.textBox_Secondname.Leave += new System.EventHandler(this.textBox_Secondname_Leave);
            this.textBox_Secondname.MouseEnter += new System.EventHandler(this.textBox_Secondname_MouseEnter);
            this.textBox_Secondname.MouseLeave += new System.EventHandler(this.textBox_Secondname_MouseLeave);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(506, 25);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 13;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(588, 25);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(75, 23);
            this.button_reset.TabIndex = 14;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InCompleteOrdersLabel,
            this.loggeduser_label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1119, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // InCompleteOrdersLabel
            // 
            this.InCompleteOrdersLabel.Name = "InCompleteOrdersLabel";
            this.InCompleteOrdersLabel.Size = new System.Drawing.Size(139, 17);
            this.InCompleteOrdersLabel.Text = "Неизпълнени поръчки :";
            // 
            // loggeduser_label
            // 
            this.loggeduser_label.Name = "loggeduser_label";
            this.loggeduser_label.Size = new System.Drawing.Size(79, 17);
            this.loggeduser_label.Text = "Logged User :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(670, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sort By :";
            // 
            // comboBox_SortBy
            // 
            this.comboBox_SortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SortBy.FormattingEnabled = true;
            this.comboBox_SortBy.Items.AddRange(new object[] {
            "Not Sorted",
            "Date"});
            this.comboBox_SortBy.Location = new System.Drawing.Point(723, 26);
            this.comboBox_SortBy.Name = "comboBox_SortBy";
            this.comboBox_SortBy.Size = new System.Drawing.Size(121, 21);
            this.comboBox_SortBy.TabIndex = 15;
            this.comboBox_SortBy.SelectedIndexChanged += new System.EventHandler(this.comboBox_SortBy_SelectedIndexChanged);
            // 
            // comboBox_month
            // 
            this.comboBox_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Items.AddRange(new object[] {
            "MM",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_month.Location = new System.Drawing.Point(328, 26);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(48, 21);
            this.comboBox_month.TabIndex = 10;
            // 
            // comboBox_year
            // 
            this.comboBox_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_year.FormattingEnabled = true;
            this.comboBox_year.Items.AddRange(new object[] {
            "YYYY",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"});
            this.comboBox_year.Location = new System.Drawing.Point(436, 26);
            this.comboBox_year.Name = "comboBox_year";
            this.comboBox_year.Size = new System.Drawing.Size(59, 21);
            this.comboBox_year.TabIndex = 12;
            // 
            // comboBox_day
            // 
            this.comboBox_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_day.FormattingEnabled = true;
            this.comboBox_day.Items.AddRange(new object[] {
            "DD",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_day.Location = new System.Drawing.Point(382, 26);
            this.comboBox_day.Name = "comboBox_day";
            this.comboBox_day.Size = new System.Drawing.Size(48, 21);
            this.comboBox_day.TabIndex = 11;
            // 
            // textBox_Id
            // 
            this.textBox_Id.Location = new System.Drawing.Point(12, 27);
            this.textBox_Id.Name = "textBox_Id";
            this.textBox_Id.Size = new System.Drawing.Size(100, 20);
            this.textBox_Id.TabIndex = 7;
            this.textBox_Id.Enter += new System.EventHandler(this.textBox_Id_Enter);
            this.textBox_Id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Id_KeyDown);
            this.textBox_Id.Leave += new System.EventHandler(this.textBox_Id_Leave);
            // 
            // OrdersManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 379);
            this.Controls.Add(this.textBox_Id);
            this.Controls.Add(this.comboBox_day);
            this.Controls.Add(this.comboBox_year);
            this.Controls.Add(this.comboBox_month);
            this.Controls.Add(this.comboBox_SortBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_Secondname);
            this.Controls.Add(this.textBox_Firstname);
            this.Controls.Add(this.datagrid_Orders);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OrdersManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrdersManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_Orders)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView datagrid_Orders;

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteOrderToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_Firstname;
        private System.Windows.Forms.TextBox textBox_Secondname;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem completeOrderToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel InCompleteOrdersLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_SortBy;
        private System.Windows.Forms.ComboBox comboBox_month;
        private System.Windows.Forms.ComboBox comboBox_year;
        private System.Windows.Forms.ComboBox comboBox_day;
        private System.Windows.Forms.ToolStripMenuItem manageusers_strip;
        private System.Windows.Forms.ToolStripMenuItem changeuser_strip;
        private System.Windows.Forms.ToolStripStatusLabel loggeduser_label;
        private System.Windows.Forms.TextBox textBox_Id;
        private System.Windows.Forms.ToolStripMenuItem backupstrip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
    }
}

