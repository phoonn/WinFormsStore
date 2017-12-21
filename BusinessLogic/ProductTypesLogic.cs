using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;

namespace BusinessLogic
{
    public class ProductTypeLogic : BaseCrudLogic<ProductType, IProductTypeRepository>, IProductTypeLogic
    {
        public ProductTypeLogic(IProductTypeRepository Repo, IUnitOfWork Unit) : base(Repo, Unit)
        {
        }
    }
}
