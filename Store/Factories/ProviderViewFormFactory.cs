using Store.Factories.Interfaces;
using Store.ProductForms;
using System.Windows.Forms;
using Unity;

namespace Store.Factories
{
    public class ProviderViewFormFactory : IFormFactory
    {
        private readonly IUnityContainer container;

        public ProviderViewFormFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public Form CreateNew()
        {
            return container.Resolve<DeleteProvider>();
        }
    }
}
