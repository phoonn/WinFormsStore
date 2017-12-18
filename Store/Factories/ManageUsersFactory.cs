using System.Windows.Forms;
using Store.Factories.Interfaces;
using Unity;
using Store.Users;

namespace Store.Factories
{
    public class ManageUsersFactory : IFormFactory
    {
        private readonly IUnityContainer container;

        public ManageUsersFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public Form CreateNew()
        {
            return container.Resolve<ManageUsers>();
        }
    }
}
