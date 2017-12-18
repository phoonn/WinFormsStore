using System.Collections.Generic;

namespace Interfaces.Logic
{
    public interface IProductLogic<T> : ICrudLogic<T> 
    {
        List<T> GetMapped();

        void Add(T Item, List<string> serialnums);
    }
}
