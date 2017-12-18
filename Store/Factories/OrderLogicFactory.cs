using DataModel.Entities;
using Interfaces.Logic;
using Store.Factories.Interfaces;
using Unity;

namespace Store.Factories
{
    public class OrderLogicFactory : IOrderLogicFactory
    {
        private readonly IUnityContainer container;

        public OrderLogicFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public IOrderLogic<Order> CreateNew()
        {
            return container.Resolve<IOrderLogic<Order>>();
        }
    }
}
