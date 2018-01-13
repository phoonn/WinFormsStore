using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessLogic
{
    public class ProductLogic : BaseCrudLogic<Product,IProductRepository>, IProductLogic
    {
        private IProviderRepository ProviderRepo;
        private IProductTypeRepository ProductTypeRepo;
        private ISerialNumberRepository SerianNumberRepo;

        public ProductLogic(IProductRepository ProductRepo, IUnitOfWork Unit, IProviderRepository ProviderRepo, IProductTypeRepository ProductTypeRepo, ISerialNumberRepository SerianNumberRepo):base(ProductRepo,Unit)
        { 
            this.ProviderRepo = ProviderRepo;
            this.ProductTypeRepo = ProductTypeRepo;
            this.SerianNumberRepo = SerianNumberRepo;
        }

        public List<Product> GetMapped()
        {
            List<Product> products = Repo.GetAll();
            foreach (var item in products)
            {
                item.ProviderName = item.Provider.ProviderName;
                item.ProductTypeName = item.ProductType.Type;
            }
            return products;
        }

        public void Add(Product Item, List<SerialNumber> serialnums)
        {
            Item.ProductType = ProductTypeRepo.FindByName(Item.ProductTypeName);
            if (Item.ProductType==null)
            {
                Item.ProductType = new ProductType();
                Item.ProductType.Type = Item.ProductTypeName;
            }
            Item.Provider = ProviderRepo.FindByName(Item.ProviderName);
            Item.SerialNumbers = new Collection<SerialNumber>();
            Item.SerialNumbers = serialnums;
            Repo.Save(Item);
            Unit.SaveChanges();
        }

        public void Update(Product Item, List<SerialNumber> serialnumbers)
        {
            Item.ProductType = ProductTypeRepo.FindByName(Item.ProductTypeName);
            if (Item.ProductType == null)
            {
                Item.ProductType = new ProductType();
                Item.ProductType.Type = Item.ProductTypeName;
            }
            Item.Provider = ProviderRepo.FindByName(Item.ProviderName);

            ModifySerialNumbers(Item, serialnumbers);

            Item.SerialNumbers = serialnumbers;
            Repo.Update(Item);
            Unit.SaveChanges();
        }

        public void EditSerialNumbers(Product Item, List<SerialNumber> serialnumbers)
        {
            ModifySerialNumbers(Item, serialnumbers);
            Item.Quantity = serialnumbers.Count;
            Repo.Update(Item);
            Unit.SaveChanges();
        }

        public void FillLists(List<Provider> providers, List<ProductType> types)
        {
            providers = ProviderRepo.Get().ToList();
            types = ProductTypeRepo.Get().ToList();
        }
        
        private void ModifySerialNumbers(Product Item, List<SerialNumber> serialnumbers)
        {
            foreach (var number in serialnumbers)
            {
                if (number.Id != 0)
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
        }
    }
}
