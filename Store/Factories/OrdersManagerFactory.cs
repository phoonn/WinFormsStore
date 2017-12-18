using Store.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using DataModel.Entities;
using System.Windows.Forms;
using Unity.Resolution;

namespace Store.Factories
{
    public class OrdersManagerFactory : IOrdersManagerFactory
    {
        private readonly IUnityContainer container;

        public OrdersManagerFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public Form CreateNew(User currentUser)
        {
            return container.Resolve<OrdersManager>(new ParameterOverride("currentUser", currentUser));
        }
    }
}
