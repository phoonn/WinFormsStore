using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        private IUnitOfWork Unit;
        private IProductRepository ProductRepo;
        private IProviderRepository ProviderRepo;
        private IProductTypeRepository ProductTypeRepo;
        private ISerialNumberRepository SerianNumberRepo;

        public ProductLogic(IUnitOfWork Unit, IProductRepository ProductRepo, IProviderRepository ProviderRepo, IProductTypeRepository ProductTypeRepo, ISerialNumberRepository SerianNumberRepo)
        {                                                                                                                         
            this.Unit = Unit;
            this.ProductRepo = ProductRepo;
            this.ProviderRepo = ProviderRepo;
            this.ProductTypeRepo = ProductTypeRepo;
            this.SerianNumberRepo = SerianNumberRepo;
        }

        public List<Product> GetMapped()
        {
            List<Product> products = ProductRepo.GetAll();
            foreach (var item in products)
            {
                item.ProviderName = item.Provider.ProviderName;
                item.ProductTypeName = item.ProductType.Type;
            }
            return products;
        }

        public void Add(Product Item, List<string> serialnums)
        {
            Item.ProductType = ProductTypeRepo.FindByName(Item.ProductTypeName);
            if (Item.ProductType==null)
            {
                Item.ProductType = new ProductType();
                Item.ProductType.Type = Item.ProductTypeName;
            }
            Item.Provider = ProviderRepo.FindByName(Item.ProviderName);
            Item.SerialNumbers = new Collection<SerialNumber>();
            foreach (var item in serialnums)
            {
                SerialNumber num = new SerialNumber();
                num.SerialNum = item;
                Item.SerialNumbers.Add(num);
            }
            ProductRepo.Save(Item);
            Unit.SaveChanges();
        }

        public void ModifySerialNumbers(Product Item, List<SerialNumber> serialnumbers)
        {
            foreach (var number in serialnumbers)
            {
                if (number.Id!=0)
                {
                    if (number.Modified)
                    {
                        SerianNumberRepo.Update(number);
                    }
                }
                else
                {
                    number.ProductId = Item.Id;
                    SerianNumberRepo.Save(number);
                }
            }
            if (serialnumbers.Count>Item.Quantity)
            {
                Item.Quantity = serialnumbers.Count;
                ProductRepo.Update(Item);
            }
            Unit.SaveChanges();
        }

        public void Add(Product Item)
        {
            ProductRepo.Save(Item);
            Unit.SaveChanges();
        }

        public void Delete(Product Item)
        {
            ProductRepo.Delete(Item);
            Unit.SaveChanges();
        }

        public void Edit(Product Item)
        {
            ProductRepo.Update(Item);
            Unit.SaveChanges();
        }

        public List<Product> Get()
        {
            return ProductRepo.GetAll();
        }

        public void FillLists(List<Provider> providers, List<ProductType> types)
        {
            providers = ProviderRepo.Get().ToList();
            types = ProductTypeRepo.Get().ToList();
        }

        public Product GetById(int id)
        {
            return ProductRepo.GetById(id);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Unit.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
