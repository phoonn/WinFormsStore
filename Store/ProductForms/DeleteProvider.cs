using DataModel.Entities;
using Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Store.ProductForms
{
    public partial class DeleteProvider : Form
    {
        private BindingSource providerBS = new BindingSource();
        private readonly IProviderLogic providerlogic;
        public DeleteProvider(IProviderLogic providerlogic)
        {
            this.providerlogic = providerlogic;
            InitializeComponent();
            RefreshAll();
        }

        private void RefreshAll()
        {
            providerBS.DataSource = providerlogic.Get();
            datagrid_provider.DataSource = providerBS;
            datagrid_provider.MultiSelect = false;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (providerBS.Current==null)
            {
                return;
            }
            Provider item = (Provider)providerBS.Current;
            if (MessageBox.Show("Do you want to delete this provider ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                providerlogic.Delete(item);
                providerBS.Remove(item);
                datagrid_provider.Refresh();
            }
        }
    }
}
