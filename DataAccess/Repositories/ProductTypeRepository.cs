using DataModel.Entities;
using Interfaces.Repositories;
using System.Data.Entity;
using System.Linq;
using System;

namespace DataAccess.Repositories
{
    public class ProductTypeRepository : BaseRepository<ProductType> , IProductTypeRepository
    {
        public ProductType GetByName(string typename)
        {
            IQueryable<ProductType> query = Items;
            query = query.Where(i => i.Type == typename);
            return query.FirstOrDefault();
        }

        public ProductType FindByName(string name)
        {
            return Items.FirstOrDefault(p => p.Type == name);
        }

        public ProductTypeRepository(IUnitOfWork unit, DbContext context) : base(unit, context)
        { }


        public ProductTypeRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
