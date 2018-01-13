using DataModel.Entities;
using System.Collections.Generic;

namespace Interfaces.Logic
{
    public interface IProductLogic : ICrudLogic<Product>
    {
        List<Product> GetMapped();

        void Add(Product Item, List<SerialNumber> serialnums);

        void Update(Product Item, List<SerialNumber> serialnums);

        void EditSerialNumbers(Product Item, List<SerialNumber> serialnum);
    }
}
