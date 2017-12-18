using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;

namespace BusinessLogic
{
    public class ProductTypeLogic : BaseCrudLogic<ProductType>, IProductTypeLogic<ProductType>
    {
        public ProductTypeLogic(IRepository<ProductType> Repo, IUnitOfWork Unit) : base(Repo, Unit)
        {
        }
    }
}
