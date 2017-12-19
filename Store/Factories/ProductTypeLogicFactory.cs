using Store.Factories.Interfaces;
using DataModel.Entities;
using Interfaces.Logic;
using Unity;

namespace Store.Factories
{
    public class ProductTypeLogicFactory : IProductTypeLogicFactory
    {
        private readonly IUnityContainer container;

        public ProductTypeLogicFactory(IUnityContainer container)
        {
            this.container = container;
        }
        public IProductTypeLogic CreateNew()
        {
            return container.Resolve<IProductTypeLogic>();
        }
    }
}
