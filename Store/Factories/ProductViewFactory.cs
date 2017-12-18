using Store.Factories.Interfaces;
using Store.ProductForms;
using System.Windows.Forms;
using Unity;

namespace Store.Factories
{
    public class ProductViewFactory : IFormFactory
    {
        private readonly IUnityContainer container;

        public ProductViewFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public Form CreateNew()
        {
            return container.Resolve<ProductView>();
        }
    }
}
