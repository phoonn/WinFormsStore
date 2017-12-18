using DataAccess.Repositories;
using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Store.ProductForms
{
    public partial class DeleteProvider : Form
    {
        private BindingSource providerBS = new BindingSource();
        private List<Provider> providerlist;
        public DeleteProvider()
        {
            InitializeComponent();
            RefreshAll();
        }

        private void RefreshAll()
        {
            using (StoreDbContext context =new StoreDbContext())
            {
                ProviderRepository providerrepo = new ProviderRepository(context);
                providerlist = providerrepo.GetAll();
                providerBS.DataSource = from p in providerlist
                                       select new { p.Id,p.ProviderName };
            }
            datagrid_provider.DataSource = providerBS;
            datagrid_provider.MultiSelect = false;
            if (providerBS.Count > 1)
            {
                datagrid_provider.Columns[1].HeaderText = "Доставчик";
                datagrid_provider.Columns["Id"].Visible = false;
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (providerBS.Current==null)
            {
                return;
            }
            int index = datagrid_provider.CurrentRow.Index;
            Provider item = providerlist[index];
            if (MessageBox.Show("Do you want to delete this provider ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (StoreDbContext context=new StoreDbContext())
                {
                    ProviderRepository providerrepo = new ProviderRepository(context);
                    providerrepo.Delete(item);
                    providerBS.Remove(item);
                    datagrid_provider.Refresh();
                }
            }
        }
    }
}
