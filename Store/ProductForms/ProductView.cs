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
        private IProductLogic<Product> productlogic;
        private IProviderLogic<Provider> providerlogic { get; set; }
        private IProductTypeLogic<ProductType> producttypelogic { get; set; }
        private ISerialNumberLogic<SerialNumber> serialnumberlogic { get; set; }
        private readonly IProductLogicFactory productfactory;
        private readonly IProviderLogicFactory providerfactory;
        private readonly IProductTypeLogicFactory producttypefactory;
        private readonly ISerialNumberLogicFactory serialnumberfactory;

        public ProductView(IProductLogicFactory productfactory, IProviderLogicFactory providerfactory, IProductTypeLogicFactory producttypefactory, ISerialNumberLogicFactory serialnumberfactory)
        {
            InitializeComponent();
            this.productfactory = productfactory;
            this.providerfactory = providerfactory;
            this.producttypefactory = producttypefactory;
            this.serialnumberfactory = serialnumberfactory;
            RefreshAll(true);
        }

        private void Save(Product product,List<string>seriallist)
        {
            //try
            //{
            //using (StoreDbContext context = new StoreDbContext())
            //{
            //    ProductRepository productrepo = new ProductRepository(context);
            //    SerialNumberRepository serialrepo = new SerialNumberRepository(context);
            //    ProductTypeRepository producttyperepo = new ProductTypeRepository(context);
            //    ProductType producttype = producttyperepo.GetByName(product.ProductName);
            //    ProviderRepository providerrepo = new ProviderRepository(context);
            //    Provider provider = providerrepo.GetByName(product.ProviderName);
            //    if (producttype == null)
            //    {
            //        producttype = new ProductType();
            //        producttype.Type = product.ProductTypeName;
            //        //producttyperepo.Save(producttype);
            //        //producttypelist.Add(producttype);
            //        //context.SaveChanges();
            //    }
            //    product.ProviderId = provider.Id;
            //    product.Provider = provider;
            //    //product.ProductTypeId = producttype.Id;
            //    product.ProductType = producttype;
            //    productrepo.Save(product);
            //    context.SaveChanges();
            //    if (product.Id != 0 && product.SerialNumbers != null && product.SerialNumbers.Count > 0)
            //    {
            //        foreach (var item in product.SerialNumbers.ToList())
            //        {
            //            serialrepo.Delete(item);
            //        }
            //        product.SerialNumbers.Clear();
            //    }
            //    foreach (var item in seriallist)
            //    {
            //        if (!String.IsNullOrEmpty(item))
            //        {
            //            SerialNumber serialnum = new SerialNumber();
            //            serialnum.SerialNum = item;
            //            serialnum.ProductId = product.Id;
            //            serialrepo.Save(serialnum);
            //            context.SaveChanges();
            //            product.SerialNumbers.Add(serialnum);
            //        }
            //    }
            //    context.SaveChanges();
            //}
            //}
            //catch (Exception ex)
            //{
            //    ErrorLogger.Log(ex);
            //    MessageBox.Show("An Error occured, check log file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            using (productlogic = productfactory.CreateNew())
            {
                productlogic.Add(product,seriallist);
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
            List<string> serialist = new List<string>();
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
            List<string> serialist = new List<string>();
            using (StoreDbContext context = new StoreDbContext())
            {
                ProductRepository productrepo = new ProductRepository(context);
                product = productrepo.GetById(product.Id);
                foreach (var item in product.SerialNumbers.ToList())
                {
                    serialist.Add(item.SerialNum);
                }
            }
            AddProduct addproductform = new AddProduct(product, producttypelist,serialist,providerlist);
            if (addproductform.ShowDialog()==DialogResult.OK)
            {
                Save(product,serialist);
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
            List<string> seriallist; 
            using (productlogic = productfactory.CreateNew())
            {
                product = productlogic.GetById(product.Id);
                seriallist = product.SerialNumbers.Select(s => s.SerialNum).ToList();
            }
            SerialNumbers serialnums = new SerialNumbers(seriallist, product.Quantity);
            if (serialnums.ShowDialog()==DialogResult.OK)
            {
                using (StoreDbContext context = new StoreDbContext())
                {
                    ProductRepository productrepo = new ProductRepository(context);
                    SerialNumberRepository serialrepo = new SerialNumberRepository(context);
                    if (product.Id != 0 && product.SerialNumbers.Count != 0)
                    {
                        foreach (var item in product.SerialNumbers.ToList())
                        {
                            serialrepo.Delete(item);
                        }
                        product.SerialNumbers.Clear();
                    }
                    foreach (var item in seriallist)
                    {
                        if (!String.IsNullOrEmpty(item))
                        {
                            SerialNumber serialnum = new SerialNumber();
                            serialnum.SerialNum = item;
                            serialnum.ProductId = product.Id;
                            serialrepo.Save(serialnum);
                            product.SerialNumbers.Add(serialnum);
                        }
                    }
                    product.Quantity = product.SerialNumbers.Count;
                    productrepo.Update(product);
                    context.SaveChanges();
                    RefreshAll();
                }
            }
        }
    }
}
