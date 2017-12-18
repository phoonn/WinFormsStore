using DataModel.Entities;
using Interfaces.Logic;

namespace Store.Factories.Interfaces
{
    public interface IProductTypeLogicFactory
    {
        IProductTypeLogic<ProductType> CreateNew();
    }
}
