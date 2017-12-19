using Store.Factories.Interfaces;
using DataModel.Entities;
using Interfaces.Logic;
using Unity;

namespace Store.Factories
{
    public class ProductLogicFactory : IProductLogicFactory
    {
        private readonly IUnityContainer container;

        public ProductLogicFactory(IUnityContainer container)
        {
            this.container = container;
        }
        public IProductLogic CreateNew()
        {
            return container.Resolve<IProductLogic>();
        }
    }
}
