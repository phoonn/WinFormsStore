using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Interfaces.Logic
{
    public interface IOrderLogic<T> : IDisposable,ICrudLogic<T>
    {
        List<T> GetOrders(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int take = 0);

        List<T> GetOrders(string firstname = default(string), string secondname = default(string), bool? SortByDate = null,
            int? id = 0, int? Day = 0, int? Month = 0, int? Year = 0);
    }
}
