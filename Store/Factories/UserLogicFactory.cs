using System;
using DataModel.Entities;
using Interfaces.Logic;
using Store.Factories.Interfaces;
using Unity;

namespace Store.Factories
{
    public class UserLogicFactory : IUserLogicFactory
    {
        private readonly IUnityContainer container;

        public UserLogicFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public IUserLogic<User> CreateNew()
        {
            return container.Resolve<IUserLogic<User>>();
        }
    }
}
