using DataModel.Entities;
using System.Collections.Generic;

namespace Interfaces.Logic
{
    public interface IProductLogic : ICrudLogic<Product>
    {
        List<Product> GetMapped();

        void Add(Product Item, List<string> serialnums);

        void ModifySerialNumbers(Product Item, List<SerialNumber> serialnumbers);
    }
}
