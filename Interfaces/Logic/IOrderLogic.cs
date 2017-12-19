using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Interfaces.Logic
{
    public interface IOrderLogic : ICrudLogic<Order>
    {
        List<Order> GetOrders(Expression<Func<Order, bool>> filter = null,
            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
            string includeProperties = "", int take = 0);

        List<Order> GetOrders(string firstname = default(string), string secondname = default(string), bool? SortByDate = null,
            int? id = 0, int? Day = 0, int? Month = 0, int? Year = 0);
    }
}
