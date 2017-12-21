using Interfaces.Logic;
using DataAccess.Repositories;
using ErrorAndValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataModel.Entities;
using Store.Factories.Interfaces;

namespace Store.ProductForms
{
    public partial class ProductView : Form
    {
        private BindingSource productBS = new BindingSource();
        private List<ProductType> producttypelist;
        private List<Provider> providerlist;
        private IProductLogic productlogic;
        private IProviderLogic providerlogic { get; set; }
        private IProductTypeLogic producttypelogic { get; set; }
        private ISerialNumberLogic serialnumberlogic { get; set; }

        private readonly IProductLogicFactory productfactory;
        private readonly IProviderLogicFactory providerfactory;
        private readonly IProductTypeLogicFactory producttypefactory;
        private readonly ISerialNumberLogicFactory serialnumberfactory;

        private readonly ISerialNumbersFormFactory serialnumberformfactory;

        public ProductView(IProductLogicFactory productfactory, IProviderLogicFactory providerfactory, IProductTypeLogicFactory producttypefactory, ISerialNumberLogicFactory serialnumberfactory, ISerialNumbersFormFactory serialnumberformfactory)
        {
            InitializeComponent();
            this.productfactory = productfactory;
            this.providerfactory = providerfactory;
            this.producttypefactory = producttypefactory;
            this.serialnumberfactory = serialnumberfactory;
            this.serialnumberformfactory = serialnumberformfactory;
            RefreshAll(true);
        }

        private void Save(Product product, List<SerialNumber> seriallist)
        {
            using (productlogic = productfactory.CreateNew())
            {
                productlogic.Add(product,seriallist);
            }
            RefreshAll();
        }

        private void Update(Product product, List<SerialNumber> serialist)
        {
            using (productlogic = productfactory.CreateNew())
            {
                productlogic.Update(product, serialist);
            }
            RefreshAll();
        }
        public void RefreshAll(bool? init = false)
        {
            //try
            //{
            using (productlogic = productfactory.CreateNew())
            {
                if (init==true)
                {
                    using (providerlogic = providerfactory.CreateNew())
                    {
                        providerlist = providerlogic.Get();
                    }
                    using (producttypelogic = producttypefactory.CreateNew())
                    {
                        producttypelist = producttypelogic.Get();
                    }
                }
                productBS.DataSource = productlogic.GetMapped();
            }
            //}
            //catch (Exception ex)
            //{
            //    ErrorLogger.Log(ex);
            //    MessageBox.Show("An Error occured, check log file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            datagrid_Product.DataSource = productBS;
            datagrid_Product.MultiSelect = false;

        }

        private void AddProduct_tool_Click(object sender, EventArgs e)
        {
            Product product=new Product();
            List<SerialNumber> serialist = null;
            AddProduct addproductform = new AddProduct(product,producttypelist,serialist,providerlist);
            if (addproductform.ShowDialog()==DialogResult.OK)
            {
                Save(product,serialist);
            }
        }

        private void EditProduct_tool_Click(object sender, EventArgs e)
        {
            if (productBS.Current == null)
            {
                return;
            }
            Product product = (Product)productBS.Current;
            List<SerialNumber> seriallist = new List<SerialNumber>();
            using (productlogic = productfactory.CreateNew())
            {
                product = productlogic.GetById(product.Id);
                seriallist = product.SerialNumbers.ToList();
            }
            AddProduct addproductform = new AddProduct(product, producttypelist,seriallist,providerlist);
            if (addproductform.ShowDialog()==DialogResult.OK)
            {
                Update(product, seriallist);
            }


        }

        private void deleteProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productBS.Current == null)
            {
                return;
            }
            Product product = (Product)productBS.Current;
            if (MessageBox.Show("Do you want to delete this product ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (productlogic = productfactory.CreateNew())
                    {
                        productlogic.Delete(product);
                    }
                }
                catch (Exception ex)
                {
                    ErrorLogger.Log(ex);
                    MessageBox.Show("An Error occured, check log file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                productBS.Remove(productBS.Current);
            }
        }

        private void addprovider_tool_Click(object sender, EventArgs e)
        {
            Provider provider = new Provider();
            AddProvider addprovider = new AddProvider(provider);
            if (addprovider.ShowDialog()==DialogResult.OK)
            {
                //try
                //{
                    using(providerlogic = providerfactory.CreateNew())
                    {
                        providerlogic.Add(provider);
                        
                    }
                //}
                //catch (Exception ex)
                //{
                //    ErrorLogger.Log(ex);
                //    MessageBox.Show("An Error occured, check log file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }
        }

        private void deleteprovider_tool_Click(object sender, EventArgs e)
        {
            DeleteProvider deleteprov = new DeleteProvider();
            deleteprov.Show();
        }

        private void datagrid_Product_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (productBS.Current == null)
            {
                return;
            }
            Product product = (Product)productBS.Current;
            List<SerialNumber> seriallist;
            using (productlogic = productfactory.CreateNew())
            {
                product = productlogic.GetById(product.Id);
                seriallist = product.SerialNumbers.ToList();
                if (seriallist == null)
                {
                    seriallist = new List<SerialNumber>(product.Quantity);
                }
                Form serialnums = serialnumberformfactory.CreateNew(seriallist);
                if (serialnums.ShowDialog()==DialogResult.OK)
                {
                    productlogic.ModifySerialNumbers(product, seriallist);
                }
                else if (seriallist.Count!=product.Quantity)
                {
                    product.Quantity = seriallist.Count;
                    productlogic.Edit(product);
                }
            }
            RefreshAll();
        }
    }
}
