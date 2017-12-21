using Store.Factories.Interfaces;
using System.Collections.Generic;
using DataModel.Entities;
using Unity;
using System.Windows.Forms;
using Store.ProductForms;
using Unity.Resolution;

namespace Store.Factories
{
    public class SerialNumbersFormFactory : ISerialNumbersFormFactory
    {
        private readonly IUnityContainer container;

        public SerialNumbersFormFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public Form CreateNew(List<SerialNumber> seriallist)
        {
            return container.Resolve<SerialNumbers>(new ParameterOverride("seriallist", seriallist));
        }
    }
}
