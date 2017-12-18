namespace Store.ProductForms
{
    partial class DeleteProvider
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
            this.datagrid_provider = new System.Windows.Forms.DataGridView();
            this.button_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_provider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // datagrid_provider
            // 
            this.datagrid_provider.AllowUserToAddRows = false;
            this.datagrid_provider.AllowUserToDeleteRows = false;
            this.datagrid_provider.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_provider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrid_provider.Location = new System.Drawing.Point(0, 24);
            this.datagrid_provider.MultiSelect = false;
            this.datagrid_provider.Name = "datagrid_provider";
            this.datagrid_provider.ReadOnly = true;
            this.datagrid_provider.Size = new System.Drawing.Size(667, 271);
            this.datagrid_provider.TabIndex = 1;
            this.datagrid_provider.VirtualMode = true;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(12, 1);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // DeleteProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 295);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.datagrid_provider);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DeleteProvider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeleteProvider";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_provider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView datagrid_provider;
        private System.Windows.Forms.Button button_delete;
    }
}