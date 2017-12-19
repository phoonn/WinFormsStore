using Store.Factories.Interfaces;
using DataModel.Entities;
using Interfaces.Logic;
using Unity;

namespace Store.Factories
{
    public class ProviderLogicFactory : IProviderLogicFactory
    {
        private readonly IUnityContainer container;

        public ProviderLogicFactory(IUnityContainer container)
        {
            this.container = container;
        }
        public IProviderLogic CreateNew()
        {
            return container.Resolve<IProviderLogic>();
        }
    }
}
