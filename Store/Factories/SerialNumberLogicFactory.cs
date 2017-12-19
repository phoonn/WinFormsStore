using Store.Factories.Interfaces;
using DataModel.Entities;
using Interfaces.Logic;
using Unity;

namespace Store.Factories
{
    public class SerialNumberLogicFactory : ISerialNumberLogicFactory
    {
        private readonly IUnityContainer container;

        public SerialNumberLogicFactory(IUnityContainer container)
        {
            this.container = container;
        }
        public ISerialNumberLogic CreateNew()
        {
            return container.Resolve<ISerialNumberLogic>();
        }
    }
}
