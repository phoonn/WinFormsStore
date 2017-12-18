using DataModel.Entities;
using Interfaces.Repositories;
using System.Data.Entity;
using System.Linq;
using System;

namespace DataAccess.Repositories
{
    public class ProviderRepository :BaseRepository<Provider> , IProviderRepository<Provider>
    {
        public Provider GetByName(string typename)
        {
            IQueryable<Provider> query = Items;
            query = query.Where(i => i.ProviderName == typename);
            return query.FirstOrDefault();
        }

        public Provider FindByName(string name)
        {
            return Items.FirstOrDefault(p => p.ProviderName == name);
        }

        public ProviderRepository(IUnitOfWork unit, DbContext context) : base(unit, context)
        { }


        public ProviderRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
