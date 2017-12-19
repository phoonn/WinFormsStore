using DataModel.Entities;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> Search(string firstname = default(string), string secondname = default(string), bool? SortByDate = null, int? id = 0, int? Day = 0, int? Month = 0, int? Year = 0);
    }
}
