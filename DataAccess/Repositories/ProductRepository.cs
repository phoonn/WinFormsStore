using DataModel.Entities;
using Interfaces.Repositories;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product> , IProductRepository<Product>
    {
        public ProductRepository(IUnitOfWork unit, DbContext context) : base(unit, context)
        {

        }

        public ProductRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
