using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class OrderLogic : BaseCrudLogic<Order,IOrderRepository>, IOrderLogic
    {
        public OrderLogic(IOrderRepository Orderrepo, IUnitOfWork Unit) :base(Orderrepo,Unit)
        {
        }

        public List<Order> GetOrders(Expression<Func<Order, bool>> filter = null,
            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
            string includeProperties = "", int take = 0)
        {
            return Repo.Get(filter, orderBy, includeProperties, take).ToList();
        }

        public List<Order> GetOrders(string firstname = default(string), string secondname = default(string), bool? SortByDate = null, int? id = 0, int? Day = 0, int? Month = 0, int? Year = 0)
        {
            return Repo.Search(firstname, secondname, SortByDate, id, Day, Month, Year);
        }
    }
}
