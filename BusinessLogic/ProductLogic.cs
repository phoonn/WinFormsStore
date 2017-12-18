using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessLogic
{
    public class ProductLogic : IProductLogic<Product>
    {
        private IUnitOfWork Unit;
        private IProductRepository<Product> ProductRepo;
        private IProviderRepository<Provider> ProviderRepo;
        private IProductTypeRepository<ProductType> ProductTypeRepo;
        private ISerialNumberRepository<SerialNumber> SerianNumberRepo;

        public ProductLogic(IUnitOfWork Unit, IProductRepository<Product> ProductRepo, IProviderRepository<Provider> ProviderRepo, IProductTypeRepository<ProductType> ProductTypeRepo, ISerialNumberRepository<SerialNumber> SerianNumberRepo)
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
