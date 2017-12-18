namespace Store.ProductForms
{
    partial class ProductView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AddProduct_tool = new System.Windows.Forms.ToolStripMenuItem();
            this.EditProduct_tool = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProviderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addprovider_tool = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteprovider_tool = new System.Windows.Forms.ToolStripMenuItem();
            this.datagrid_Product = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_Product)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddProduct_tool,
            this.EditProduct_tool,
            this.deleteProductToolStripMenuItem,
            this.addProviderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AddProduct_tool
            // 
            this.AddProduct_tool.Name = "AddProduct_tool";
            this.AddProduct_tool.Size = new System.Drawing.Size(86, 20);
            this.AddProduct_tool.Text = "Add Product";
            this.AddProduct_tool.Click += new System.EventHandler(this.AddProduct_tool_Click);
            // 
            // EditProduct_tool
            // 
            this.EditProduct_tool.Name = "EditProduct_tool";
            this.EditProduct_tool.Size = new System.Drawing.Size(84, 20);
            this.EditProduct_tool.Text = "Edit Product";
            this.EditProduct_tool.Click += new System.EventHandler(this.EditProduct_tool_Click);
            // 
            // deleteProductToolStripMenuItem
            // 
            this.deleteProductToolStripMenuItem.Name = "deleteProductToolStripMenuItem";
            this.deleteProductToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.deleteProductToolStripMenuItem.Text = "Delete Product";
            this.deleteProductToolStripMenuItem.Click += new System.EventHandler(this.deleteProductToolStripMenuItem_Click);
            // 
            // addProviderToolStripMenuItem
            // 
            this.addProviderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addprovider_tool,
            this.deleteprovider_tool});
            this.addProviderToolStripMenuItem.Name = "addProviderToolStripMenuItem";
            this.addProviderToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.addProviderToolStripMenuItem.Text = "Provider";
            // 
            // addprovider_tool
            // 
            this.addprovider_tool.Name = "addprovider_tool";
            this.addprovider_tool.Size = new System.Drawing.Size(107, 22);
            this.addprovider_tool.Text = "Add";
            this.addprovider_tool.Click += new System.EventHandler(this.addprovider_tool_Click);
            // 
            // deleteprovider_tool
            // 
            this.deleteprovider_tool.Name = "deleteprovider_tool";
            this.deleteprovider_tool.Size = new System.Drawing.Size(107, 22);
            this.deleteprovider_tool.Text = "Delete";
            this.deleteprovider_tool.Click += new System.EventHandler(this.deleteprovider_tool_Click);
            // 
            // datagrid_Product
            // 
            this.datagrid_Product.AllowUserToAddRows = false;
            this.datagrid_Product.AllowUserToDeleteRows = false;
            this.datagrid_Product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrid_Product.Location = new System.Drawing.Point(0, 24);
            this.datagrid_Product.MultiSelect = false;
            this.datagrid_Product.Name = "datagrid_Product";
            this.datagrid_Product.ReadOnly = true;
            this.datagrid_Product.Size = new System.Drawing.Size(860, 333);
            this.datagrid_Product.TabIndex = 1;
            this.datagrid_Product.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagrid_Product_CellMouseDoubleClick);
            // 
            // ProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 357);
            this.Controls.Add(this.datagrid_Product);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProductView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductView";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_Product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddProduct_tool;
        private System.Windows.Forms.DataGridView datagrid_Product;
        private System.Windows.Forms.ToolStripMenuItem EditProduct_tool;
        private System.Windows.Forms.ToolStripMenuItem deleteProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProviderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addprovider_tool;
        private System.Windows.Forms.ToolStripMenuItem deleteprovider_tool;
    }
}