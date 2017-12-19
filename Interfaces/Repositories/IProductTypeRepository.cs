using DataModel.Entities;

namespace Interfaces.Repositories
{
    public interface IProductTypeRepository : IRepository<ProductType> 
    {
        ProductType FindByName(string name);
    }
}
